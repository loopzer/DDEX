#include "stdafx.h"
#include "CppUnitTest.h"
#include <DDEX\Resource\IIndexResourceFactory.h>
#include <DDEX\Resource\IndexResourceManager.h>

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace DDEX;
namespace DDEXTest
{
	typedef struct {
		unsigned __int32 some;
	} Ts;

	class DummyFactory : public IIndexResourceFactory<Ts> {

		virtual Ts * Make(unsigned __int32 resourceIndex) override
		{
			Ts * resource;
			resource = new Ts();
			resource->some = resourceIndex;
			return resource;
		}

		virtual void Destroy(Ts * resource) override
		{
			delete resource;
		}
	};

	TEST_CLASS(IndexResourceManagerTest)
	{
	public:
		TEST_METHOD(IndexResourceManagerLoad)
		{
			Ts * resource;
			DummyFactory  * factory = new DummyFactory();
			IndexResourceManager<Ts> * manager;

			manager = new IndexResourceManager<Ts>(factory, 100, 5);
			resource = manager->Get(1);
			Assert::AreEqual<unsigned __int32>(1, resource->some);
			resource = manager->Get(2);
			Assert::AreEqual<unsigned __int32>(2, resource->some);
			resource = manager->Get(3);
			Assert::AreEqual<unsigned __int32>(3, resource->some);
			resource = manager->Get(4);
			Assert::AreEqual<unsigned __int32>(4, resource->some);
			resource = manager->Get(5);
			Assert::AreEqual<unsigned __int32>(5, resource->some);
			manager->Tick();

			resource = manager->Get(1);
			Assert::AreEqual<unsigned __int32>(1, resource->some);
			resource = manager->Get(2);
			Assert::AreEqual<unsigned __int32>(2, resource->some);
			resource = manager->Get(4);
			Assert::AreEqual<unsigned __int32>(4, resource->some);
			resource = manager->Get(5);
			Assert::AreEqual<unsigned __int32>(5, resource->some);
			resource = manager->Get(6);
			Assert::AreEqual<unsigned __int32>(6, resource->some);
			resource = manager->Get(6);
			Assert::AreEqual<unsigned __int32>(6, resource->some);

			delete manager;
			delete factory;

		}

	};
}