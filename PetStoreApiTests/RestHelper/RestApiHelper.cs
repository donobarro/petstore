using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.RestHelper
{
    class RestApiHelper
    {
        private RestClient client = new RestClient("http://petstore.swagger.io/v2");
        

        public PetEndpoint Pet()
        {
            return new PetEndpoint(client);
        }
    }
}
