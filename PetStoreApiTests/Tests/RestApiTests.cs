using NUnit.Framework;
using PetStoreApiTests.RestHelper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                .SetId(123)
                .SetCategory(new Category()
                    .setId(321)
                    .setName("name_of_category"))
                .SetName("name_of_pet")
                .AddPhotoUrl("photourl1")
                .AddTag(new Tag()
                    .setId(456)
                    .setName("tag_name"))
                .SetStatus("available"));

            Assert.IsTrue(response.IsSuccessful);

        }

        [Test]
        public void FindAvailablePets()
        {
            List<Pet> availablePets = restApiHelper.Pet().FindByStatus("sold");
            Assert.GreaterOrEqual(availablePets.Count(), 10);
        }

        [Test]
        public void PutPet()
        {
            IRestResponse response = restApiHelper.Pet().Put(new Pet()
                .SetId(123)
                .SetCategory(new Category()
                    .setId(321)
                    .setName("PutCategory"))
                .SetName("PutPet")
                .AddPhotoUrl("photourl2")
                .AddTag(new Tag()
                    .setId(456)
                    .setName("PutTag"))
                .SetStatus("available"));

            Assert.IsTrue(response.IsSuccessful);
        }

        [Test]
        public void GetPetById()
        {
            Pet pet = restApiHelper.Pet().Get(6);

            Assert.AreEqual(6, pet.GetId());
            Assert.AreEqual("available", pet.GetStatus());
        }

        [Test]
        public void PostPetNameAndStatusById()
        {
            IRestResponse response = restApiHelper.Pet().Post(1);
            Console.WriteLine(response.Content.ToString());
        }

        [Test]
        public void DeletePetById()
        {
            IRestResponse response = restApiHelper.Pet().Delete(1);
            Console.WriteLine(response.Content.ToString());
        }

        [Test]
        public void UploadImage()
        {
            IRestResponse response = restApiHelper.Pet().UploadImage(2);
            Console.WriteLine(response.Content.ToString());
        }


    }
}
