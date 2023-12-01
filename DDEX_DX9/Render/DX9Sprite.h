#pragma once
#include <Windows.h>

#include "..\DX9\Dx9Def.h"
#include <d3d9.h>
#include <d3dx9.h>
#include <DxErr.h>
#pragma comment(lib, "dxerr.lib")

#include <Render\RenderDeclares.h>
#include <Render\ISprite.h>

using namespace DDEX;
class DX9Sprite : public Render::ISprite
{

public:


	DX9Sprite(LPDIRECT3DDEVICE9 dev, LPD3DXSPRITE sprite) {
		this->sprite = sprite;
		this->dev = dev;
	}

	void Draw(void * resource, int x, int y, RECT * rect, Render::RenderColor * color, int angle) {

		if (angle != 0) {
			this->DrawRotation(resource, x, y, rect, color, angle);
		}
		else
		{
			HRESULT hr;

			D3DXVECTOR3 vPos((float)x, (float)y, 0.0f);
			hr = this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
				rect,
				NULL,
				&vPos,
				*((D3DCOLOR *)color));
		}
	}

	void DrawRotation(void * resource, int x, int y, RECT * rect, Render::RenderColor * color, int angle) {

		D3DSURFACE_DESC surfaceDesc;

		int level = 0;

		((LPDIRECT3DTEXTURE9)resource)->GetLevelDesc(level, &surfaceDesc);

		D3DXMATRIX matRot2;

		D3DXMATRIX matRot;

		D3DXVECTOR2 vPos((float)x, (float)y);

		D3DXVECTOR2 vCenter(
			(float)(rect->right - rect->left) / 2,
			(float)(rect->bottom - rect->top) / 2);


		D3DXVECTOR2 vScale((float)(rect->right - rect->left) / (float)surfaceDesc.Width, (float)(rect->bottom - rect->top) / (float)surfaceDesc.Height);

		D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, &vCenter, D3DXToRadian(angle), &vPos);

		this->sprite->GetTransform(&matRot);

		this->sprite->SetTransform(&matRot2);

		HRESULT hr;

		hr = this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
			NULL,
			NULL,
			NULL,
			*((D3DCOLOR *)color));

		this->sprite->SetTransform(&matRot);

	}
	void DrawRaw(void * resource, RECT * rect, Render::RenderColor * color_, void * extra) {
		D3DXMATRIX matRot;

		this->sprite->GetTransform(&matRot);

		this->sprite->SetTransform((D3DXMATRIX*)extra);

		this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
			rect,
			NULL,
			NULL,
			*((D3DCOLOR *)color_));
		this->sprite->SetTransform(&matRot);
	}
	void DrawRaw(void * resource, RECT * rect, Render::RenderColor * color_) {
		this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
			rect,
			NULL,
			NULL,
			*((D3DCOLOR *)color_));
	}

	void Draw(void * resource, Render::Vector2 * position, Render::Vector2 * scaling, Render::Vector2 * center, Render::Vector2 * centerScaling, Render::RenderColor * color, int angle) {

		D3DSURFACE_DESC surfaceDesc;

		int level = 0;

		((LPDIRECT3DTEXTURE9)resource)->GetLevelDesc(level, &surfaceDesc);

		D3DXMATRIX matRot2;

		D3DXMATRIX matRot;

		D3DXVECTOR2 vPos(position->x, position->y);
		/*
		D3DXVECTOR2 vCenter(
			(float)scaleRect->right ,
			(float)scaleRect->bottom );
		*/
		D3DXVECTOR2 *vCenter = NULL;

		//D3DXVECTOR2 vScale((float)(rect->right - rect->left) / (float)surfaceDesc.Width, (float)(rect->bottom - rect->top) / (float)surfaceDesc.Height);

		D3DXVECTOR2 * vScale = NULL;

		D3DXVECTOR2 *vCenterScale = NULL;

		if (center != NULL) {
			vCenter = &D3DXVECTOR2(center->x, center->y);
		}
		if (centerScaling != NULL) {
			vCenterScale = &D3DXVECTOR2(centerScaling->x, centerScaling->y);
		}
		if (scaling != NULL) {
			vScale = &D3DXVECTOR2(scaling->x, scaling->y);
		}

		D3DXMatrixTransformation2D(&matRot2, vCenterScale, 0.0, vScale, vCenter, (float)angle / 1000.0f, &vPos);
		//D3DXMatrixTransformation2D(&matRot2, vCenterScale, 0.0, vScale, vCenter, D3DXToRadian(angle), &vPos);

		//D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, NULL, (float)angle / 1000.0f, &vPos);
		//D3DXMatrixTransformation2D(&matRot2, vCenterScale, 0.0, vScale, vCenter, (float)angle / 1000.0f, &vPos);
		//D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, &vCenter, (float)angle / 1000.0f, &vPos);
		//D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, &vCenter, (float)angle / 1000.0f, &vPos);
		//D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, &vCenter, D3DXToRadian(angle), &vPos);

		this->sprite->GetTransform(&matRot);

		this->sprite->SetTransform(&matRot2);

		HRESULT hr;

		hr = this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
			NULL,
			NULL,
			NULL,
			*((D3DCOLOR *)color));

		this->sprite->SetTransform(&matRot);

	}

	void DrawLight(void * resource, int x, int y, RECT * rect, Render::RenderColor * color, int angle) {

		D3DSURFACE_DESC surfaceDesc;

		int level = 0;

		((LPDIRECT3DTEXTURE9)resource)->GetLevelDesc(level, &surfaceDesc);

		D3DXMATRIX matRot2;

		D3DXMATRIX matRot;

		D3DXVECTOR2 vPos((float)x, (float)y);

		D3DXVECTOR2 vCenter(
			(float)(rect->right - rect->left) / 2,
			(float)(rect->bottom - rect->top) / 2);

		D3DXVECTOR2 vScale((float)(rect->right - rect->left) / (float)surfaceDesc.Width, (float)(rect->bottom - rect->top) / (float)surfaceDesc.Height);

		D3DXMatrixTransformation2D(&matRot2, NULL, 0.0, &vScale, &vCenter, D3DXToRadian(angle), &vPos);

		this->sprite->GetTransform(&matRot);

		this->sprite->SetTransform(&matRot2);

		HRESULT hr;

		hr = this->sprite->Draw((LPDIRECT3DTEXTURE9)resource,
			NULL,
			NULL,
			NULL,
			*((D3DCOLOR *)color));

		this->sprite->SetTransform(&matRot);

		/*

		*/
	}

	virtual void End() {
		this->sprite->End();
		//this->dev->EndScene();
	}

	~DX9Sprite() {

	}
protected:
	LPD3DXSPRITE sprite;
	LPDIRECT3DDEVICE9 dev;
};

