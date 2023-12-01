#pragma once
namespace DDEX {
	template <class T>
	class IIndexResourceFactory
	{
	public:

		virtual T * Make(unsigned __int32 resourceIndex) = 0;
		virtual void Destroy(T * resource) = 0;

		IIndexResourceFactory()
		{
		}

		virtual ~IIndexResourceFactory()
		{
		}
	};
}
