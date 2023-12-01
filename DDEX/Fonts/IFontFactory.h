#pragma once
#include <Windows.h>
#include "IFont.h"
namespace DDEX{
	class IFontFactory
	{

	public:

		virtual IFont * Make(char * name, int size, bool bold, bool italic) = 0;
		virtual ~IFontFactory(){
		}
	};

}