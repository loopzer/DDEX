#pragma once
#include <Windows.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")

#include <Layers\LayerDeclares.h>
#include <Layers\ILayer.h>

using namespace DDEX;
class DX9Layer :public Layers::ILayer
{

public:
	DX9Layer(LPDIRECT3DDEVICE9  dev, D3DFORMAT format, Layers::LAYERTYPE layerType, RECT layerSize) {
		this->dev = dev;
		this->layerType = layerType;
		this->layerSize = layerSize;
		this->Create();
	}

	void Bind(float red, float green, float blue, float alpha) {
		this->dev->SetRenderTarget(0, this->surface);

		this->dev->Clear(0, NULL, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER,
			D3DCOLOR_COLORVALUE(red, green, blue, alpha), 1.0f, 0);
	}
	void SaveToFile(wchar_t * filename) {
		D3DXSaveSurfaceToFile(filename, D3DXIMAGE_FILEFORMAT::D3DXIFF_BMP, this->surface, NULL, &this->layerSize);
	}
	~DX9Layer() {

		if (this->surface != NULL) {
			this->surface->Release();
		}
		if (this->texture != NULL) {
			this->texture->Release();
		}
	}

protected:

	LPDIRECT3DDEVICE9 dev;
	LPDIRECT3DTEXTURE9 texture;

	LPDIRECT3DSURFACE9 surface;

	D3DFORMAT format;

	void Create() {

		D3DXCreateTexture(this->dev, this->layerSize.right, this->layerSize.bottom, 0, D3DUSAGE_RENDERTARGET,
			this->format, D3DPOOL_DEFAULT, &this->texture);

		this->texture->GetSurfaceLevel(0, &this->surface);

		this->resource = this->texture;
	}

};
