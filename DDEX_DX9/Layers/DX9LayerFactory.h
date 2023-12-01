#pragma once
#include <Windows.h>
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")

#include <Layers\LayerDeclares.h>
#include "DX9Layer.h"
#include <Layers\ILayerFactory.h>

class DX9LayerFactory : public Layers::ILayerFactory {
public:

	DX9LayerFactory(LPDIRECT3DDEVICE9  dev, D3DFORMAT format, RECT layerSize) {
		this->dev = dev;
		this->format = format;
		this->layerSize = layerSize;
	}

	virtual Layers::ILayer * Make(Layers::LAYERTYPE layerType) {
		return new DX9Layer(this->dev, this->format, layerType, this->layerSize);
	}

	~DX9LayerFactory() {

	}
protected:
	LPDIRECT3DDEVICE9  dev;
	D3DFORMAT format;
};

