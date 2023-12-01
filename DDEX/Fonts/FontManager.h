#pragma once
#include <Windows.h>
#include "FontDeclares.h"
#include "IFontFactory.h"
#include "IFont.h"
namespace DDEX{
	class FontManager
	{
	public:

		FontManager(IFontFactory * factory) {
			this->factory = factory;
			for (int i = 0; i < MAX_FONTS - 1; i++) {
				this->fonts[i] = NULL;
			}
		}

		__int32 Make(char * name, int size, bool bold, bool italic, __int32 forcedId = -1) {

			IFont * f = this->factory->Make(name, size, bold, italic);

			if (forcedId == -1) {
				for (int i = 0; i < MAX_FONTS; i++) {
					if (this->fonts[i] == NULL) {
						this->fonts[i] = f;
						return i;
					}
				}
			}
			else {
				if (this->fonts[forcedId] == NULL) {
					this->fonts[forcedId] = f;
					return forcedId;
				}
				else {
					delete this->fonts[forcedId];
					this->fonts[forcedId] = f;
					return forcedId;
				}
			}

			return -1;
		}

		IFont * Get(__int32 id) {
			return this->fonts[id];
		}


		~FontManager() {
			int i;
			for (i = 0; i < MAX_FONTS - 1; i++) {
				if (this->fonts[i] != NULL) {
					delete this->fonts[i];
				}
			}
		}
		wchar_t *GetWC(char *c)
		{
			const size_t cSize = strlen(c) + 1;
			wchar_t* wc = new wchar_t[cSize];
			mbstowcs(wc, c, cSize);

			return wc;
		}

	protected:
		IFontFactory * factory;
		IFont * fonts[MAX_FONTS];

	};

}