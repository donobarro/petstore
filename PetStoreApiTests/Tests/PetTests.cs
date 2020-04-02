using NUnit.Framework;
using PetStoreApiTests.RestHelper;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PetStoreApiTests.Tests
{
    [TestFixture]
    class PetTests : TestBase
    {
        const long referencePetId = 111222333;
        const long petToDeleteId = 333222111;

        [SetUp]
        public void OnSetUp()
        {
            Pet createdPet = RestApiHelper.Pet().Post(new Pet()
                .SetId(referencePetId)
                .SetCategory(new Category()
                    .setId(321)
                    .setName("name_of_category"))
                .SetName("name_of_pet")
                .AddPhotoUrl("photourl1")
                .AddTag(new Tag()
                    .setId(456)
                    .setName("tag_name"))
                .SetStatus("sold"));

            Pet petToDelete = RestApiHelper.Pet().Post(new Pet()
                .SetId(petToDeleteId)
                .SetCategory(new Category()
                    .setId(321)
                    .setName("todelete"))
                .SetName("PetToDelete")
                .AddPhotoUrl("string")
                .AddTag(new Tag()
                    .setId(456)
                    .setName("tag_name"))
                .SetStatus("available"));
        }
        [Test]
        public void PostPet()
        {
            Pet createdPet = RestApiHelper.Pet().Post(new Pet()
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

            Assert.AreEqual("name_of_pet", createdPet.GetName());
            Assert.AreEqual(123, createdPet.GetId());
            Assert.AreEqual("available", createdPet.GetStatus());

        }

        [Test]
        public void FindAvailablePets()
        {
            List<Pet> availablePets = RestApiHelper.Pet().FindByStatus("sold");
            Assert.GreaterOrEqual(availablePets.Count, 1);
        }

        [Test]
        public void PutPet()
        {
            Pet updatedPet = RestApiHelper.Pet().Put(new Pet()
                .SetId(referencePetId)
                .SetCategory(new Category()
                    .setId(321)
                    .setName("PutCategory"))
                .SetName("PutPet")
                .AddPhotoUrl("photourl2")
                .AddTag(new Tag()
                    .setId(456)
                    .setName("PutTag"))
                .SetStatus("available"));

            Assert.AreEqual("PutPet", updatedPet.GetName());
            Assert.AreEqual("photourl2", updatedPet.GetPhotoUrls()[0]);
        }

        [Test]
        public void GetPetById()
        {
            Pet pet = RestApiHelper.Pet().Get(referencePetId);

            Assert.AreEqual(referencePetId, pet.GetId());
            Assert.AreEqual("sold", pet.GetStatus());
        }

        [Test]
        public void PostPetNameAndStatusById()
        {
            IRestResponse response = RestApiHelper.Pet().Post(referencePetId, "Lucy", "sold");

            Pet updatedPet = RestApiHelper.Pet().Get(referencePetId);
            Assert.AreEqual("Lucy", updatedPet.GetName());
            Assert.AreEqual("sold", updatedPet.GetStatus());
        }

        [Test]
        public void DeletePetById()
        {
            IRestResponse response = RestApiHelper.Pet().Delete(petToDeleteId);
            Assert.IsTrue(response.IsSuccessful);
        }

        [Test]
        public void UploadImage()
        {
            IRestResponse response = RestApiHelper.Pet().UploadImage(referencePetId, AppDomain.CurrentDomain.BaseDirectory + "/image.jpg");
            Assert.IsTrue(response.IsSuccessful);
        }

        [TearDown]
        public void CleanUp()
        {
            RestApiHelper.Pet().Delete(referencePetId);
        }


    }
}
