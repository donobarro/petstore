using RestSharp;

namespace PetStoreApiTests.RestHelper
{
    internal class Endpoint
    {
        protected RestClient client;
        public Endpoint(RestClient client)
        {
            this.client = client;
        }
    }
}