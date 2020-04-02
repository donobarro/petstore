using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

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
            return JsonConvert.DeserializeObject<List<Pet>>(queryresult.Content);
        }

        public Pet Post(Pet pet)
        {
            string json = JsonConvert.SerializeObject(pet);
            var request = new RestRequest("/pet", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Pet>(response.Content);
        }

        public Pet Put(Pet pet)
        {
            string json = JsonConvert.SerializeObject(pet);
            var request = new RestRequest("/pet", Method.PUT).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Pet>(response.Content);
        }

        public Pet Get(long id)
        {
            var request = new RestRequest("/pet/{id}", Method.GET).AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Pet>(response.Content);
        }

        public IRestResponse Post(long id, string name, string status)
        {
            var request = new RestRequest("/pet/{id}", Method.POST).AddHeader("Content-Type", "application/x-www-form-urlencoded").AddParameter("id", id, ParameterType.UrlSegment).AddParameter("name", name, ParameterType.GetOrPost).AddParameter("status", status, ParameterType.GetOrPost);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse Delete(long id)
        {
            var request = new RestRequest("/pet/{id}", Method.DELETE).AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse UploadImage(long id, string pathToImage)
        {
            
            var request = new RestRequest("/pet/{id}/uploadImage", Method.POST)
                .AddParameter("id", id, ParameterType.UrlSegment)
                .AddHeader("Accept",  "application/json")
                .AddHeader("Content-Type", "multipart/form-data")
                .AddFile("file", pathToImage);
            var response = client.Execute(request);
            return response;
        }
    }
}
