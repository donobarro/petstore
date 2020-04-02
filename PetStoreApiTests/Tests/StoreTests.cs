using NUnit.Framework;
using RestSharp;
using System;

namespace PetStoreApiTests.Tests
{
    class StoreTests : TestBase
    {

        const long idToDelete = 112233;
        [SetUp]
        public void OnSetUp()
        {
            RestApiHelper.Store().Post(new RestHelper.Order()
                .SetId(idToDelete)
                .SetPetId(332211)
                .SetQuantity(1)
                .SetShipDate(new DateTime(2020, 02, 02))
                .SetStatus("available")
                .SetComplete(false));
        }

        [Test]
        public void CreateOrder()
        {
            IRestResponse response = RestApiHelper.Store().Post(new RestHelper.Order()
                .SetId(12311)
                .SetPetId(321)
                .SetQuantity(1)
                .SetShipDate(new DateTime(2020, 02, 02))
                .SetStatus("available")
                .SetComplete(false));

            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(321, RestApiHelper.Store().Get(12311).GetPetId());
        }
        [Test]
        public void DeleteOrder()
        {
            IRestResponse response = RestApiHelper.Store().Delete(idToDelete);

            Assert.IsTrue(response.IsSuccessful);
        }

    }
}
