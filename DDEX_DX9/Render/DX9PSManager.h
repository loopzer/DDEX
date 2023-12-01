#pragma once
#include <Windows.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#include <math.h>

#include "..\Shaders\InvertColor.h"
#include "..\Shaders\Grey.h"
#include "..\Shaders\Red.h"
#include "..\Shaders\Green.h"
#include "..\Shaders\Blue.h"
#include "..\Shaders\InvertTexture.h"
#include "..\Shaders\Relief.h"
#include "..\Shaders\Custom.h"
#include "..\Shaders\Light.h"
#include "..\Shaders\Swap.h"
#include "..\Shaders\Swinging.h"
#include "..\Shaders\Wave.h"
#include "..\Shaders\Blur.h"
#include "..\Shaders\NegativeLight.h"
#include <Render\RenderDeclares.h>
#include <Render\IPSManager.h>
#include <Render\ISprite.h>
#include "DX9Sprite.h"

using namespace DDEX;
#define CreateShader(name, en) \
(this->dev->CreatePixelShader((DWORD *)name, &this->shaders[(int)Render::en]) )

class PSManager :public Render::IPSManager
{

public:


	PSManager(LPDIRECT3DDEVICE9 dev) {
		this->dev = dev;

		if (FAILED(D3DXCreateSprite(this->dev, &this->sprite))) {
			//TODO Error
		}

		this->dxSprite = new DX9Sprite(this->dev, this->sprite);

		for (size_t i = 0; i < (int)Render::PSEffects::ENUMSIZE; i++)
		{
			this->shaders[i] = NULL;
		}
		this->LoadShaders();
	}

	void LoadShaders() {

		CreateShader(InvertColor_Shader, PSEffects::INVERTCOLOR);
		CreateShader(Grey_Shader, PSEffects::GREY);
		CreateShader(Red_Shader, PSEffects::RED);
		CreateShader(Green_Shader, PSEffects::GREEN);
		CreateShader(Blue_Shader, PSEffects::BLUE);
		CreateShader(InvertTexture_Shader, PSEffects::INVERTTEXTURE);
		CreateShader(Relief_Shader, PSEffects::RELIEF);
		CreateShader(Custom_Shader, PSEffects::CUSTOM);
		CreateShader(Light_Shader, PSEffects::LIGHT);
	//	CreateShader(Swap_Shader, PSEffects::SWAP);
		CreateShader(Swinging_Shader, PSEffects::SWINGING);
		CreateShader(Wave_Shader, PSEffects::WAVE);
		CreateShader(NegativeLight_Shader, PSEffects::NEGATIVELIGHT);
		CreateShader(Blur_Shader, PSEffects::BLUR);
	}
	Render::ISprite * Begin(Render::PSEffects effect, Render::EffectParameters * data) {

		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);

		this->SetPS(effect);
		this->SetEffectData(data);
		this->dev->SetTexture(0, NULL);
		return this->dxSprite;
	}

	Render::ISprite * Begin(void * resource, Render::PSEffects effect, Render::EffectParameters * data) {
		

		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);

		this->SetPS(effect);
		this->SetEffectData(data);
		this->dev->SetTexture(1, (LPDIRECT3DTEXTURE9)resource);
		return this->dxSprite;
	}

	Render::ISprite * BeginLight() {
		

		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);

		dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_ALPHABLENDENABLE, TRUE);

		dev->SetRenderState(D3DRS_SRCBLEND, D3DBLEND_SRCALPHA);
		dev->SetRenderState(D3DRS_DESTBLEND, D3DBLEND_DESTALPHA);

		this->SetPS(Render::PSEffects::DEFAULT);
		this->dev->SetTexture(0, NULL);
		return this->dxSprite;
	}

	void SetPS(Render::PSEffects effect) {
		if (effect >= Render::PSEffects::ENUMSIZE) {
			effect = Render::PSEffects::DEFAULT;
		}

		if (effect == Render::PSEffects::DEFAULT) {
			this->dev->SetPixelShader(NULL);
		}
		else
		{
			this->dev->SetPixelShader(this->shaders[(int)effect]);
		}
	}

	void SwapWithEffect(LPDIRECT3DTEXTURE9  base, LPDIRECT3DTEXTURE9  light, RECT * r, Render::PSEffects effect) {

	}
	void SwapLight(void * base, void * light, RECT * layerSize) {
		this->SwapLight((LPDIRECT3DTEXTURE9)base, (LPDIRECT3DTEXTURE9)light, layerSize);
	}
	void SwapLight(LPDIRECT3DTEXTURE9  base, LPDIRECT3DTEXTURE9  light, RECT * r) {
		

		this->sprite->Begin(D3DXSPRITE_ALPHABLEND);

		this->dev->SetTexture(1, light);

		this->SetPS(Render::PSEffects::LIGHT);

		HRESULT hr;

		D3DXVECTOR3 vPos((float)0, (float)0, 0.0f);
		hr = this->sprite->Draw(base,
			r,
			NULL,
			&vPos,
			D3DCOLOR_ARGB(255, 255, 255, 255));

		this->sprite->End();
		this->dev->EndScene();
		this->dev->SetPixelShader(NULL);
		this->dev->SetTexture(1, NULL);
	}

	void SetEffectData(void * data) {
		if (data == NULL) {
			return;
		}

		this->dev->SetPixelShaderConstantF(0, (const float*)data, 1);
	}

	~PSManager() {

		for (size_t i = 0; i < (int)Render::PSEffects::ENUMSIZE; i++)
		{
			if (this->shaders[i] != NULL) {
				this->shaders[i]->Release();
			}
		}

		this->sprite->Release();
		delete this->dxSprite;
	}

	LPD3DXSPRITE GetSprite() {
		return this->sprite;
	}

protected:

	LPDIRECT3DDEVICE9 dev;

	LPDIRECT3DPIXELSHADER9 shaders[(int)Render::PSEffects::ENUMSIZE];

	LPD3DXSPRITE  sprite;

	DX9Sprite * dxSprite;
};

