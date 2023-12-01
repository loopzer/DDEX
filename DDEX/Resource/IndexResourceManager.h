#pragma once
#include <Windows.h>
#include "IIndexResourceFactory.h"
namespace DDEX {
	template <class T>
	class IndexResourceManager
	{
	private:
		IIndexResourceFactory<T> * factory;

		typedef struct {
			unsigned __int32 lastTouch;
			unsigned __int32 index;
			T * resource;
		} ResourceEntry;

		unsigned __int32 currentTime;
		bool way;

		ResourceEntry ** index;
		ResourceEntry * resource;

		unsigned __int32 maxResourceIndex;
		unsigned __int32 resourcePoolSize;

		void DestroyAll() {
			for (size_t i = 0; i < this->resourcePoolSize; i++)
			{
				if (this->resource[i].resource != NULL) {
					this->factory->Destroy(this->resource[i].resource);
				}
			}
		}

		int GetFree() {
			unsigned __int32 i;

			this->way = !this->way;

			if (this->way == 0) {
				for (i = 0; i < this->resourcePoolSize; i++)
				{
					if (this->resource[i].resource == NULL) {
						return i;
					}
				}
			}
			else {
				for (i = this->resourcePoolSize - 1; i < this->resourcePoolSize; i--) {
					if (this->resource[i].resource == NULL) {
						return i;
					}
				}
			}

			return this->GetLessUsed();
		}

		unsigned __int32 GetLessUsed() {

			unsigned __int32 winner;
			unsigned __int32 touch = -1;

			winner = 0;
			for (unsigned __int32 i = 0; i < this->resourcePoolSize; i++) {
				if (this->resource[i].resource != NULL) {
					if (this->resource[i].lastTouch <= touch) {
						winner = i;
						touch = this->resource[i].lastTouch;
					}
				}
			}

			return winner;
		}

	public:
		T * Get(unsigned __int32 resourceIndex) {

			unsigned __int32 freeResourceIndex;
			freeResourceIndex = 0;
			T * resource = NULL;
			if (this->index[resourceIndex] == NULL) {//si no esta lo cargamos
				resource = this->factory->Make(resourceIndex);
				if (resource == NULL) {
					return NULL;
				}

				freeResourceIndex = this->GetFree();
				if (this->resource[freeResourceIndex].resource != NULL) {
					this->factory->Destroy(this->resource[freeResourceIndex].resource);
					this->index[this->resource[freeResourceIndex].index] = NULL;
				}

				this->resource[freeResourceIndex].index = resourceIndex;
				this->resource[freeResourceIndex].resource = resource;
				this->resource[freeResourceIndex].lastTouch = this->currentTime + 1000;

				this->index[resourceIndex] = &this->resource[freeResourceIndex];

				return resource;
			}
			else {
				this->index[resourceIndex]->lastTouch = this->currentTime;
				return this->index[resourceIndex]->resource;
			}
		}

		void Tick() {
			this->currentTime = GetTickCount();
		}

		void Tick(unsigned __int32 ticks) {
			this->currentTime = ticks;
		}

		IndexResourceManager(IIndexResourceFactory<T> * _factory, unsigned __int32 _maxResourceIndex, unsigned __int32 _resourcePoolSize)
		{
			//plus one for array addressable
			this->maxResourceIndex = _maxResourceIndex + 1;
			this->resourcePoolSize = _resourcePoolSize;
			this->way = true;
			this->currentTime = 0;
			this->index = new ResourceEntry*[this->maxResourceIndex]();
			this->resource = new ResourceEntry[this->resourcePoolSize]();

			for (size_t i = 0; i < this->maxResourceIndex; i++)
			{
				this->index[i] = NULL;
			}

			for (size_t i = 0; i < this->resourcePoolSize; i++)
			{
				this->resource[i].resource = NULL;
			}

			this->factory = _factory;
		}

		virtual ~IndexResourceManager()
		{
			this->DestroyAll();
			delete[] this->index;
			delete[] this->resource;
		}
	};
}