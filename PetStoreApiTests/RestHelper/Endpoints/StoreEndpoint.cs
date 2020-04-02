using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace PetStoreApiTests.RestHelper
{
    class StoreEndpoint : Endpoint
    {
        public StoreEndpoint(RestClient client) : base (client)
        {

        }
        public IRestResponse Post(Order order)
        {
            string json = JsonConvert.SerializeObject(order);
            var request = new RestRequest("/store/order", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public Order Get(long id)
        {
            var request = new RestRequest("/store/order/" + id, Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Order>(response.Content);
        }
        public IRestResponse Delete(long id)
        {
            var request = new RestRequest("/store/order/" + id, Method.DELETE);
            var response = client.Execute(request);
            return response;
        }
        public Dictionary<string, string> GetInventory()
        {
            var request = new RestRequest("/store/inventory", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }
    }
}
