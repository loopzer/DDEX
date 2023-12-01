#pragma once
#include <Windows.h>
#include <Render\RenderDeclares.h>
#include <Render\IImageFactory.h>
#include <Render\IPSManager.h>
#include <Render\IImageManager.h>
#include <Fonts\IFontFactory.h>
#include <Layers\ILayerFactory.h>
#include <UI\IHDCFactory.h>

#include <IScreenShotManager.h>

#include <ContextBase.h>
#include "Render\DX9ImageFactoy.h"
#include "Render\DX9PSManager.h"
#include "Render\DX9Sprite.h"
#include "Fonts\DX9FontFactory.h"
#include "Layers\DX9LayerFactory.h"
#include "ScreenShotManager.h"
#include <Render\Colors.h>

#include <cstdlib>
#include <stdlib.h>
#include <exception>
#include <time.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#include <math.h>
#pragma comment(lib, "dxerr.lib")
#include "DX9\Dx9Def.h"
#include "ScreenShotManager.h"
#include "Render\DX9PSManager.h"
#include "Render\DX9RenderPrimitive.h"
#include "UI\DX9HdcFactory.h"
using namespace DDEX;

class DX9Context : public ContextBase
{
protected:
	IFontFactory* fontFactoy;
	PSManager * psManager;
	Layers::ILayerFactory* layerFactory;
	DDExDx9ScreenShotManager * screenShotManager;
	Render::IImageFactory * imageFactory;
	Render::IRenderPrimitive * renderPrimitive;
	IHDCFactory * hdcFactory;
	RECT layerSize;

	HWND window;

	D3DFORMAT mainFormat;
	LPDIRECT3D9 d3d;
	LPDIRECT3DDEVICE9 dev;
	DWORD VerticeFVF;
	DWORD VerticeTexFVF;

	LPDIRECT3DSURFACE9 backBufferSurface;
	LPDIRECT3DTEXTURE9 backBufferTexture;

public:
	DX9Context() {
		this->hdcFactory = NULL;
	}
	HRESULT	InitDX(Render::Configuration* cfg) {
		this->d3d = Direct3DCreate9(D3D_SDK_VERSION);
		int configs = 0;
		HRESULT result;
		D3DCAPS9 d3dCaps;

		this->d3d->GetDeviceCaps(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, &d3dCaps);

		D3DDISPLAYMODE d3ddm;
		this->d3d->GetAdapterDisplayMode(D3DADAPTER_DEFAULT, &d3ddm);

		D3DPRESENT_PARAMETERS d3dpp;
		ZeroMemory(&d3dpp, sizeof(d3dpp));

		d3dpp.Windowed = TRUE;

		if (cfg->vsync == 1) {
			d3dpp.SwapEffect = D3DSWAPEFFECT_COPY;
			d3dpp.PresentationInterval = D3DPRESENT_INTERVAL_ONE;
		}
		else {
			d3dpp.PresentationInterval = D3DPRESENT_INTERVAL_IMMEDIATE;
			d3dpp.SwapEffect = D3DSWAPEFFECT_DISCARD;
		}

		this->mainFormat = d3ddm.Format;
		d3dpp.BackBufferFormat = d3ddm.Format;
		d3dpp.BackBufferCount = 1;
		d3dpp.BackBufferWidth = this->layerSize.right;
		d3dpp.BackBufferHeight = this->layerSize.bottom;
		d3dpp.EnableAutoDepthStencil = TRUE;
		d3dpp.AutoDepthStencilFormat = D3DFMT_D16;

		__int32 modo_vertice;
		if (cfg->modo2 == DX9_HV) //usar vertices hard
			modo_vertice = D3DCREATE_HARDWARE_VERTEXPROCESSING;
		else
			modo_vertice = D3DCREATE_SOFTWARE_VERTEXPROCESSING;

		switch (cfg->modo) {

		case DX9_HARD:
			result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, window, modo_vertice, &d3dpp, &this->dev);
			break;
		case DX9_REF:
			result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_REF, window, modo_vertice, &d3dpp, &this->dev);
			break;
		case DX9_SOFT:
			result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_SW, window, modo_vertice, &d3dpp, &this->dev);
			break;
		default:
			result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_SW, window, modo_vertice, &d3dpp, &this->dev);
		}

		while (FAILED(result)) {
			switch (configs)
			{
			case 0:
				modo_vertice = D3DCREATE_SOFTWARE_VERTEXPROCESSING;
				result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 1:
				modo_vertice = D3DCREATE_HARDWARE_VERTEXPROCESSING;
				result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_SW, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 2:
				modo_vertice = D3DCREATE_SOFTWARE_VERTEXPROCESSING;
				result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_SW, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 3:
				modo_vertice = D3DCREATE_HARDWARE_VERTEXPROCESSING;
				result = this->d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_REF, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 4:
				modo_vertice = D3DCREATE_SOFTWARE_VERTEXPROCESSING;
				result = d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_REF, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 5:
				modo_vertice = D3DCREATE_HARDWARE_VERTEXPROCESSING;
				result = d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_NULLREF, window, modo_vertice, &d3dpp, &this->dev);
				break;
			case 6:
				modo_vertice = D3DCREATE_SOFTWARE_VERTEXPROCESSING;
				result = d3d->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_NULLREF, window, modo_vertice, &d3dpp, &this->dev);
				break;
			default:
				return result;
				break;
			}
			configs++;
		}

		return result;
	}
	void ConfigureDX() {


		D3DXMATRIX matRot2;
		D3DXMATRIX matRot4;
		D3DXMATRIX matRot3;
		D3DXVECTOR2 vPos(0.0f, 0.0f);
		D3DXVECTOR2 vCentro((float)(this->layerSize.right - this->layerSize.left) / 2, (float)(this->layerSize.bottom - this->layerSize.top) / 2);
		D3DXVECTOR2 vEscala(1.0f, 1.0f);

		D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vEscala, &vCentro, D3DXToRadian(0), &vPos);
		this->dev->GetTransform(D3DTS_WORLD, &matRot3);

		D3DXMATRIX prueba = matRot2 * matRot3;
		this->dev->SetTransform(D3DTS_WORLD, &prueba);

		this->backBufferSurface = 0;
		this->backBufferTexture = NULL;

		VerticeFVF = (D3DFVF_XYZRHW | D3DFVF_DIFFUSE);
		VerticeTexFVF = (D3DFVF_XYZRHW | D3DFVF_DIFFUSE | D3DFVF_TEX1);

		this->dev->SetRenderState(D3DRS_ZENABLE, FALSE);
		this->dev->SetRenderState(D3DRS_CULLMODE, D3DCULL_CCW);

		this->dev->SetFVF(VerticeFVF);
		// :( yo quiero luces :( malditos!!!!!!!! XD 

		this->dev->SetRenderState(D3DRS_LIGHTING, FALSE);
		this->dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_ALPHABLENDENABLE, TRUE);

		this->dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_SRCBLEND, D3DBLEND_SRCALPHA);
		this->dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_DESTBLEND, D3DBLEND_INVSRCALPHA);

		this->dev->SetSamplerState(0, D3DSAMP_MINFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(0, D3DSAMP_MAGFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(0, D3DSAMP_MIPFILTER, D3DTEXF_NONE);

		this->dev->SetSamplerState(1, D3DSAMP_MINFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(1, D3DSAMP_MAGFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(1, D3DSAMP_MIPFILTER, D3DTEXF_NONE);

		this->dev->SetSamplerState(2, D3DSAMP_MINFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(2, D3DSAMP_MAGFILTER, D3DTEXF_NONE);
		this->dev->SetSamplerState(2, D3DSAMP_MIPFILTER, D3DTEXF_NONE);

		this->dev->GetRenderTarget(0, &this->backBufferSurface);

		this->dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_SRCBLEND, D3DBLEND_ONE);
		this->dev->SetRenderState(D3DRENDERSTATETYPE::D3DRS_DESTBLEND, D3DBLEND_ONE);
		this->dev->SetRenderState(D3DRS_BLENDOP, D3DBLENDOP_ADD);
	}
	__int32 Init(HWND window, char * grafPath, Render::Configuration * cfg) {

		RECT mainRect;

		GetWindowRect(window, &mainRect);
		this->window = window;
		int screenWidth = abs(mainRect.right - mainRect.left);
		int screenHeight = abs(mainRect.top - mainRect.bottom);

		this->layerSize.top = 0;
		this->layerSize.left = 0;
		this->layerSize.right = screenWidth;
		this->layerSize.bottom = screenHeight;

		this->InitDX(cfg);
		this->ConfigureDX();

		this->imageFactory = new DX9ImageFactoy(this->dev, cfg->memoryMode);

		this->psManager = new PSManager(this->dev);

		this->screenShotManager = new DDExDx9ScreenShotManager(this->dev);

		this->layerFactory = new DX9LayerFactory(this->dev, this->mainFormat, this->layerSize);

		this->fontFactoy = new DX9FontFactory(this->dev, this->psManager->GetSprite());

		this->renderPrimitive = new DX9RenderPrimitive(this->dev, this->psManager->GetSprite());

		return 0;
	}

	void InitFrame() {
		this->dev->BeginScene();
	}
	void EndFrame(Layers::ILayer *layer, HWND window_, RECT * source, RECT * dest) {
		this->dev->SetRenderTarget(0, this->backBufferSurface);

		this->dev->Clear(0, NULL, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
			D3DCOLOR_COLORVALUE(0, 0, 0, 1.0f), 1.0f, 0);

		Render::RenderColor c;

		c.a = 255;
		c.r = 255;
		c.g = 255;
		c.b = 255;

		Render::ISprite * sp = this->psManager->Begin(Render::PSEffects::SWAP, NULL);

		sp->Draw(layer->Get(), 0, 0, &this->layerSize, &c, 0);

		sp->End();
		this->dev->EndScene();
		if (FAILED(this->dev->Present(source, dest, window_, NULL))) {
		}
	}
	void EndFrame(Layers::ILayer *layer) {
		this->dev->SetRenderTarget(0, this->backBufferSurface);

		this->dev->Clear(0, NULL, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
			D3DCOLOR_COLORVALUE(0, 0, 0, 1.0f), 1.0f, 0);

		Render::RenderColor c;

		c.a = 255;
		c.r = 255;
		c.g = 255;
		c.b = 255;

		Render::ISprite * sp = this->psManager->Begin(Render::PSEffects::SWAP, NULL);

		sp->Draw(layer->Get(), 0, 0, &this->layerSize, &c, 0);

		sp->End();
		this->dev->EndScene();
		if (FAILED(this->dev->Present(&this->layerSize, &this->layerSize, this->window, NULL))) {
		}
	}

	Render::IImageFactory * GetImageFactory() {
		return this->imageFactory;
	}
	Render::IPSManager * GetPSManager() {
		return this->psManager;
	}
	IFontFactory * GetFontFactory() {
		return this->fontFactoy;
	}
	Layers::ILayerFactory * GetLayerFactory() {
		return this->layerFactory;
	}
	IScreenShotManager * GetScreenShotManager() {
		return this->screenShotManager;
	}

	Render::IRenderPrimitive * GetRenderPrimitive() {
		return this->renderPrimitive;
	}

	//TODO fix this bad aprouch
	IHDCFactory * GetHdcFactory(Render::IImageManager * imageManager) {
		if (this->hdcFactory == NULL) {
			this->hdcFactory = new DX9HdcFactory(imageManager);
		}

		return this->hdcFactory;
	}

	~DX9Context() {
		delete this->imageFactory;
		delete this->psManager;
		delete this->fontFactoy;
		delete this->layerFactory;
		delete this->screenShotManager;
		delete this->renderPrimitive;
		if (this->hdcFactory != NULL) {
			delete this->hdcFactory;
		}
		if (this->dev != NULL) {
			this->dev->Release();
			this->dev = NULL;
		}

		if (this->d3d != NULL) {
			this->d3d->Release();
			this->d3d = NULL;
		}
	}
};

