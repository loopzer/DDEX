#define NOMINMAX
// dllmain.cpp : Defines the entry point for the DLL application.
#include <Windows.h>
#include <stdio.h>
#include <time.h>
#include "Render\RenderDeclares.h"
#include "Render\Render.h"
#include "ColorAnimation.h"
#include "ContextBase.h"
#include "Render\Colors.h"
#include "Resource\IIndexResourceFactory.h"
#include "Resource\IndexResourceManager.h"
#include "Audio.h"
#include "OPENAL_LIB_INCLUDES/AudioFile/AudioFile.h"
#include "OPENAL_LIB_INCLUDES/AL/al.h"
#include "OPENAL_LIB_INCLUDES/AL/alc.h"

#define COLORREF2RGB(Color) (Color & 0xff00) | ((Color >> 16) & 0xff) \
                 | ((Color << 16) & 0xff0000)

//AGUS; OpenAL error checking
#define OpenAL_ErrorCheck(message)\
{\
	ALenum error = alGetError();\
	if( error != AL_NO_ERROR)\
	{\
		std::cerr << "DOAL Error: " << error << " with call for " << #message << std::endl;\
	}\
}

#define alec(FUNCTION_CALL)\
FUNCTION_CALL;\
OpenAL_ErrorCheck(FUNCTION_CALL)

ALCdevice* device = nullptr;
ALCcontext* context = nullptr;

using namespace DDEX;

void __stdcall DDEXMensajeDebugW(wchar_t* texto) {
	wchar_t dateStr[19];
	wchar_t timeStr[19];
	_wstrdate_s(dateStr);
	_wstrtime_s(timeStr);

	FILE* f;
	wchar_t out[0xFFFF];
	f = fopen("DDEXGeneral.log", "a");

	if (f == NULL) return;

	wsprintf(out, L"%s %s->%s\n", dateStr, timeStr, texto);
	fputws(out, f);

	fclose(f);

}

void __stdcall DDEXMensajeDebug(char * texto) {
	char dateStr[19];
	char timeStr[19];
	_strdate_s(dateStr);
	_strtime_s(timeStr);

	FILE * f;
	char out[0xFFFF];
	f = fopen("DDEXGeneral.log", "a");

	if (f == NULL) return;

	sprintf(out, "%s %s->%s\n", dateStr, timeStr, texto);
	fputs(out, f);

	fclose(f);

}

void __stdcall Test(wchar_t * data) {
	DDEXMensajeDebugW(data);
}

//@Agus: SoundEngine initialize
void __stdcall initSoundEngine() {

	//Audio device
	const ALCchar* defaultDeviceString = alcGetString(/*device*/nullptr, ALC_DEFAULT_DEVICE_SPECIFIER);
	device = alcOpenDevice(defaultDeviceString);

	if (!device)
	{
		DDEXMensajeDebug("DOAL> failed to get the devault device for OpenAL");
		return;
	}

	std::cout << "OpenAL Device: " << alcGetString(device, ALC_DEVICE_SPECIFIER) << std::endl;

	//Create an OpenAL audio context from the device
	context = alcCreateContext(device, /*attrlist*/ nullptr);

	//Activate this context so that OpenAL state modifications are applied to the context
	if (!alcMakeContextCurrent(context))
	{
		DDEXMensajeDebug("failed to make the OpenAL context the current context");
		return;
	}

	//Create a listener in 3d space (ie the player); (there always exists as listener, you just configure data on it)
	alec(alListener3f(AL_POSITION, 0.f, 0.f, 0.f));
	alec(alListener3f(AL_VELOCITY, 0.f, 0.f, 0.f));
	ALfloat forwardAndUpVectors[] = {
		/*forward = */ 1.f, 0.f, 0.f,
		/* up = */ 0.f, 1.f, 0.f
	};
	alec(alListenerfv(AL_ORIENTATION, forwardAndUpVectors));

}

void __stdcall playWave(const std::string& path, ALuint& soundBuffer, ALuint& soundSource) {
	AudioFile<float> soundFile;

	if (!soundFile.load(path)) {
		DDEXMensajeDebug("Failed to load the sound file");
		return;
	}

	std::vector<uint8_t> pcmDataBytes;
	soundFile.writePCMToBuffer(pcmDataBytes);

	auto convertFileToOpenALFormat = [](const AudioFile<float>& audioFile) {
		int bitDepth = audioFile.getBitDepth();
		if (bitDepth == 16)
			return audioFile.isStereo() ? AL_FORMAT_STEREO16 : AL_FORMAT_MONO16;
		else if (bitDepth == 8)
			return audioFile.isStereo() ? AL_FORMAT_STEREO8 : AL_FORMAT_MONO8;
		else
			return -1; // this shouldn't happen!
		};

	alec(alGenBuffers(1, &soundBuffer));
	alec(alBufferData(soundBuffer, convertFileToOpenALFormat(soundFile), pcmDataBytes.data(), pcmDataBytes.size(), soundFile.getSampleRate()));

	alec(alGenSources(1, &soundSource));
	alec(alSource3f(soundSource, AL_POSITION, 1.f, 0.f, 0.f));
	alec(alSource3f(soundSource, AL_VELOCITY, 0.f, 0.f, 0.f));
	alec(alSourcef(soundSource, AL_PITCH, 1.f));
	alec(alSourcef(soundSource, AL_GAIN, 1.f));
	alec(alSourcei(soundSource, AL_LOOPING, AL_FALSE));
	alec(alSourcei(soundSource, AL_BUFFER, soundBuffer));

	alec(alSourcePlay(soundSource));
}

void __stdcall prepareSound(std::string sound) {

	ALuint soundBuffer;
	ALuint soundSource;

	playWave(sound, soundBuffer, soundSource);

	ALint sourceState;
	alec(alGetSourcei(soundSource, AL_SOURCE_STATE, &sourceState));

	//while (sourceState == AL_PLAYING) {
		alec(alGetSourcei(soundSource, AL_SOURCE_STATE, &sourceState));
	//}

	alec(alDeleteSources(1, &soundSource));
	alec(alDeleteBuffers(1, &soundBuffer));

}

void __stdcall playSound(char* str) {
	DDEXMensajeDebug(str);

	prepareSound(str);

	//std::thread t1(prepareSound, sound);

	//t1.join();

}

ContextBase * DDEXContextFromPlugin(char * plugin) {
	HINSTANCE hGetProcIDDLL = LoadLibraryA(plugin);

	if (!hGetProcIDDLL) {
		return NULL;
	}

	CreateContextFunc func = (CreateContextFunc)GetProcAddress(hGetProcIDDLL, "DDEX_Context");

	if (!func) {
		return NULL;
	}

	return func();
}

//Render::Render* __stdcall Render_Create(wchar_t* plugin, HWND v, wchar_t* imageFolder, Render::Configuration* cfg) {
Render::Render * __stdcall Render_Create(char * plugin, HWND v, char * imageFolder, Render::Configuration * cfg) {
	
	Render::Render * render = NULL;
	
	ContextBase * context;
	DDEXMensajeDebug("->Plugin");
	DDEXMensajeDebug(plugin);
	DDEXMensajeDebug("<-Plugin");
	DDEXMensajeDebug("->image folder");
	DDEXMensajeDebug(imageFolder);
	DDEXMensajeDebug("<-image folder");

	DDEXMensajeDebug("<-NotDefferal");

	context = DDEXContextFromPlugin(plugin);
	if (context == NULL) {
		DDEXMensajeDebug("Context is null");
	}
	else
	{
		context->Init(v, imageFolder, cfg);

		render = new Render::Render(context, v, imageFolder, cfg);

		DDEXMensajeDebug("Iniciar Motor");
	}

	
	return render;
}

void __stdcall Render_Clean(Render::Render * render) {
	render->CleanScreen();
}

void __stdcall Render_DrawImage(Render::Render * render, int imageNum, int x, int y, RECT * r, Render::RenderColor * color) {
	render->Draw(imageNum, x, y, r, color);
}
void __stdcall Render_DrawScaleImage(Render::Render * render, int imageNum, int x, int y, RECT * r, RECT * scale, Render::RenderColor * color) {
	render->Draw(imageNum, x, y, r, scale, color);
}
void __stdcall Render_Present(Render::Render * render) {
	render->Present();
}
void __stdcall Render_PresentWindow(Render::Render* render, HWND hwnd) {
	RECT windowRect;
	GetWindowRect(hwnd, &windowRect);

	windowRect.right = windowRect.right - windowRect.left;
	windowRect.bottom = windowRect.bottom - windowRect.top;
	windowRect.left = 0;
	windowRect.top = 0;

	render->Present(hwnd, &windowRect, &windowRect);
}
void __stdcall Render_FlushScreen(Render::Render * render) {
	render->FlushScreen();
}
void __stdcall Render_FlushBackground(Render::Render * render) {
	render->FlushBackground();
}

void __stdcall Render_Destroy(Render::Render * render) {
	delete render;
}

void __stdcall Render_CleanLight(Render::Render * render) {
	render->CleanLights();
}

void __stdcall Render_SetLight(Render::Render * render, Render::LightDraw *d) {
	render->SetLight(d);
}

void __stdcall Render_SetMasterLight(Render::Render * render, __int32 redLight, __int32 greenLight, __int32 blueLight) {
	render->SetMastherLight(redLight, greenLight, blueLight);
}

void __stdcall Render_SetRenderEffect(Render::Render * render, __int32 effect, Render::EffectParameters * data) {
	render->SetRenderEffect(effect, data);
}

void __stdcall Render_ClearPresentEffect(Render::Render * render, __int32 effect) {
	render->ClearPresentEffect(effect);
}

void __stdcall Render_SetPresentEffect(Render::Render * render, __int32 effect, Render::EffectParameters * data) {
	render->SetPresentEffect(effect, data);
}
__int32 __stdcall Render_MakeFont(Render::Render * render, char * fontName, __int32 size, bool bold, bool italic, __int32 forcedId) {
	return render->MakeFont(fontName, size, bold, italic, forcedId);
}
void __stdcall Render_DrawFont(Render::Render * render, char * text, int font, int x, int y, Render::RenderColor * color) {
	render->Draw(text, font, x, y, color);
}
void __stdcall Render_DrawImageWithRotation(Render::Render * render, int imageNum, int x, int y, RECT * r, Render::RenderColor * color, int angle) {
	render->Draw(imageNum, x, y, r, color, angle);
}

HDC __stdcall Render_GetFontHDC(Render::Render * render, int font) {
	return render->GetFontDC(font);
}

void __stdcall Render_SetImageProxy(Render::Render * render, Render::FuncGetFileBytes func) {
	render->ImageManager_SetGetFileBytes(func);
}


bool APIENTRY DllMain(HMODULE hModule, DWORD dwReason, LPVOID lpvReserved) {

	if (dwReason == DLL_PROCESS_ATTACH) {
		//	Particulas::InitParticles();
		remove("DDEXGeneral.log");
		remove("DDExDx9.log");
		Render::Colors::Init();
		DDEXMensajeDebug("DDEX Cargada");
		//	PM = new ParticleManager();
		//		PM->InitParticles();
	}
	if (dwReason == DLL_PROCESS_DETACH) {
		DDEXMensajeDebug("DDEX Descargada");
		//aca poner salida total :P
		//		PM->FreeParticles();
	}

	return true;
}
