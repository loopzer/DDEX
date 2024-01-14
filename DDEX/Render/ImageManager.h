#pragma once
#ifndef _IMAGEMANAGER_H
#define _IMAGEMANAGER_H
#define NOMINMAX

#include <stdio.h>
#include <Windows.h>
#include <cstddef>
#include "RenderDeclares.h"
#include "IImageManager.h"
#include "IImageFactory.h"
#define MAX_INDEX 0xFFFF
#define MAX_IMAGES 1500

namespace DDEX {
	namespace Render {
		class ImageManager : public IImageManager
		{
		protected:
			IImageFactory* factory;

			struct TImage {
				unsigned __int32 lastTouch;
				void* img;
				__int32 index;
			};

			struct TControl {
				__int32 index;
				__int8	erase;
			};

			unsigned __int32 actualTime;
			int way;

			FuncGetFileBytes GetFileBytes;

			char imageFolder[255];

			struct TControl Index[MAX_INDEX];
			struct TImage Image[MAX_IMAGES];

		public:

			void Tick() {
				this->actualTime = GetTickCount();
			}

			ImageManager(IImageFactory* factory, char* imageFolder) {
				this->factory = factory;
				this->way = 0;

				__int32 i;

				strcpy(this->imageFolder, imageFolder);

				this->GetFileBytes = NULL;
				for (i = 0; i < MAX_INDEX; i++) {
					this->Index[i].index = -1;
					this->Index[i].erase = FALSE;
				}
				for (i = 0; i < MAX_IMAGES; i++) {
					this->Image[i].index = -1;
					this->Image[i].lastTouch = 0;
					this->Image[i].img = NULL;
				}
			}

			void SetGetFileBytes(FuncGetFileBytes func) {
				this->GetFileBytes = func;
			};

			void* Make(__int32 imageNum) {

				if (this->GetFileBytes == NULL) {
					char file[MAX_PATH];

					sprintf(file, "%s\\%d.bmp", this->imageFolder, imageNum);
					if (!exists(file)) {
						sprintf(file, "%s\\%d.png", this->imageFolder, imageNum);
						if (!exists(file)) {
							return NULL;
						}
					}

					return this->factory->Make(file);
				}
				else
				{
					FileData fileData;

					fileData.fileType = 0;
					fileData.size = 255;
					fileData.bytes = 0;
					fileData.fileNum = imageNum;

					this->GetFileBytes(&fileData);

					if (fileData.fileType == -1 || fileData.size <= 4 || fileData.bytes == NULL) {
						char file[MAX_PATH];

						sprintf(file, "%s\\%d.bmp", this->imageFolder, imageNum);
						if (!exists(file)) {
							sprintf(file, "%s\\%d.png", this->imageFolder, imageNum);
							if (!exists(file)) {
								return NULL;
							}
						}

						return this->factory->Make(file);
					}
					else
					{
						fileData.size++;
						return this->factory->Make(fileData.bytes, fileData.size);
					}
				}

				return NULL;
			}

			void* GetImage(__int32 imageNum) {
				__int32 i;
				i = 0;
				void* t = NULL;
				if (this->Index[imageNum].index == -1) {//si no esta lo cargamos
					t = Make(imageNum);
					if (t == NULL) {
						return NULL;
					}

					i = this->GetFree();
					if (this->Image[i].img != NULL) {
						this->factory->Free(this->Image[i].img);
						this->Index[this->Image[i].index].index = -1;
					}
					this->Index[imageNum].index = i;
					this->Image[i].index = imageNum;
					this->Image[i].img = t;
					this->Image[i].lastTouch = this->actualTime + 1000;

					return t;
				}
				else {
					this->Image[this->Index[imageNum].index].lastTouch = this->actualTime;
					return this->Image[this->Index[imageNum].index].img;
				}

			}

			int GetFree() {
				__int32 i;

				this->way = !this->way;

				if (this->way == 0) {
					for (i = 0; i < MAX_IMAGES; i++) {
						if (this->Image[i].img == NULL) {
							return i;
						}
					}
				}
				else {
					for (i = MAX_IMAGES - 1; i >= 0; i--) {
						if (this->Image[i].img == NULL) {
							return i;
						}
					}
				}

				return this->GetLastUsed();
			}

			int GetLastUsed() {

				__int32 i;
				__int32 winner;
				unsigned __int32 tiempo = this->Image[0].lastTouch;

				winner = 0;
				for (i = 0; i < MAX_IMAGES; i++) {
					if (this->Image[i].img != NULL) {
						if (this->Image[i].lastTouch <= tiempo) {
							winner = i;
							tiempo = this->Image[i].lastTouch;
						}
					}
				}

				return winner;
			}

			inline bool exists(char* fileName) {

				if (FILE* file = fopen(fileName, "r")) {
					fclose(file);
					return true;
				}
				else {
					return false;
				}
			}

			inline bool exists(wchar_t* fileName) {

				if (FILE* file = _wfopen(fileName, L"r")) {
					fclose(file);
					return true;
				}
				else {
					return false;
				}
			}

			~ImageManager() {
				__int32 i;
				for (i = 0; i < MAX_IMAGES; i++) {
					if (this->Image[i].img != NULL) {
						this->factory->Free(this->Image[i].img);
						this->Image[i].img = NULL;
					}
				}
			}
		};
	};
};
#endif