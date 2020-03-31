using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApiTests.RestHelper
{
    class PetEndpoint : Endpoint
    {
        public PetEndpoint(RestClient client) : base(client)
        {
            
        }

        public List<Pet> FindByStatus(string status)
        {
            var request = new RestRequest("/pet/findByStatus?status=" + status, Method.GET);
            var queryresult = client.Execute(request);
            List<Pet> pets = JsonConvert.DeserializeObject<List<Pet>>(queryresult.Content);
            return pets;
        }

        public IRestResponse Post(Pet pet)
        {
            string json = JsonConvert.SerializeObject(pet);
            var request = new RestRequest("/pet", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
    }
}
