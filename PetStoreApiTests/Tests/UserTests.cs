using NUnit.Framework;
using PetStoreApiTests.RestHelper;
using RestSharp;
using System.Collections.Generic;

namespace PetStoreApiTests.Tests
{
    class UserTests : TestBase
    {
        const long loginUserId = 111222333;
        const long logoutUserId = 333222111;

        [SetUp]
        public void OnSetUp()
        {
            RestApiHelper.User().Post(new User()
                .SetId(loginUserId)
                .SetUserName("TestUser111222333")
                .SetFirstName("TU_FN")
                .SetLastName("TU_LN")
                .SetEmail("testuser@example.com")
                .SetPassword("pass")
                .SetPhone("+48 222111")
                .SetUserStatus(0));

            RestApiHelper.User().Post(new User()
                .SetId(logoutUserId)
                .SetUserName("TestUser333222111")
                .SetFirstName("TU_FN")
                .SetLastName("TU_LN")
                .SetEmail("testuser@example.com")
                .SetPassword("pass")
                .SetPhone("+48 222111")
                .SetUserStatus(0));
        }
        [Test]
        public void GetUserByUsername()
        {
            User user = RestApiHelper.User().Get("TestUser111222333");

            Assert.AreEqual("testuser@example.com", user.GetEmail());
        }

        [Test]
        public void CreateWithArray()
        {
            //GIVEN
            User[] users = new User[2];
            users[0] = new User()
                .SetId(01011)
                .SetUserName("array_user1")
                .SetFirstName("Array_FN1")
                .SetLastName("Array_LN1")
                .SetEmail("array1@array.com")
                .SetPassword("arraypass1")
                .SetPhone("+44 123456 1")
                .SetUserStatus(0);
            users[1] = new User()
                .SetId(02021)
                .SetUserName("array_user2")
                .SetFirstName("Array_FN2")
                .SetLastName("Array_LN2")
                .SetEmail("array2@array.com")
                .SetPassword("arraypass2")
                .SetPhone("+44 123456 2")
                .SetUserStatus(0);

            //WHEN
            IRestResponse response = RestApiHelper.User().CreateWithArray(users);

            //THEN
            User createdArrayUser1 = RestApiHelper.User().Get("array_user1");
            User createdArrayUser2 = RestApiHelper.User().Get("array_user2");

            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual("array1@array.com", createdArrayUser1.GetEmail());
            Assert.AreEqual(02021, createdArrayUser2.GetId());

        }
        [Test]
        public void LogIn()
        {
            Dictionary<string, string> loginResponse = RestApiHelper.User().Login("TestUser111222333", "pass");

            Assert.IsTrue(loginResponse["message"].Contains("logged in"));
        }
        public void LogOut()
        {
            RestApiHelper.User().Login("TestUser333222111", "pass");

            Dictionary<string, string> logoutResponse = RestApiHelper.User().Logout();

            Assert.IsTrue(logoutResponse["message"].Contains("ok"));

        }

    }
}
