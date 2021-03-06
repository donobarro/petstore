﻿using RestSharp;

namespace PetStoreApiTests.RestHelper
{
    class RestApiHelper
    {
        private RestClient client = new RestClient("https://petstore.swagger.io/v2");
        

        public PetEndpoint Pet()
        {
            return new PetEndpoint(client);
        }
        public StoreEndpoint Store()
        {
            return new StoreEndpoint(client);
        }

        public UserEndpoint User()
        {
            return new UserEndpoint(client);
        }
    }
}
