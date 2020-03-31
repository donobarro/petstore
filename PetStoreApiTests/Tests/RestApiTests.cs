using NUnit.Framework;
using PetStoreApiTests.RestHelper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.Tests
{
    [TestFixture]
    class RestApiTests
    {
        private RestApiHelper restApiHelper = new RestApiHelper();
        [Test]
        public void PostPet()
        {
            IRestResponse response = restApiHelper.Pet().Post(new Pet()
                .setId(123)
                .setCategory(new Category()
                    .setId(321)
                    .setName("name_of_category"))
                .setName("name_of_pet")
                .addPhotoUrl("photourl1")
                .addTag(new Tag()
                    .setId(456)
                    .setName("tag_name"))
                .setStatus("available"));

            Assert.AreEqual("200", response.StatusCode.ToString());

        }

        [Test]
        public void FindAvailablePets()
        {
            List<Pet> availablePets = restApiHelper.Pet().FindByStatus("available");
            Console.WriteLine(availablePets[0].getId());
        }


    }
}
