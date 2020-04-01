using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
            return JsonConvert.DeserializeObject<List<Pet>>(queryresult.Content);
        }

        public IRestResponse Post(Pet pet)
        {
            string json = JsonConvert.SerializeObject(pet);
            var request = new RestRequest("/pet", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse Put(Pet pet)
        {
            string json = JsonConvert.SerializeObject(pet);
            var request = new RestRequest("/pet", Method.PUT).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        public Pet Get(long id)
        {
            var request = new RestRequest("/pet/{id}", Method.GET).AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Pet>(response.Content);
        }

        public IRestResponse Post(long id)
        {
            var request = new RestRequest("/pet/{id}", Method.POST).AddParameter("id", id, ParameterType.UrlSegment).AddParameter("name", "tralala", ParameterType.GetOrPost).AddParameter("status", "available", ParameterType.GetOrPost);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse Delete(long id)
        {
            var request = new RestRequest("/pet/{id}", Method.DELETE).AddParameter("id", id, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse UploadImage(long id)
        {
            
            var request = new RestRequest("/pet/{id}/uploadImage", Method.POST)
                .AddParameter("id", id, ParameterType.UrlSegment)
                .AddHeader("Accept",  "application/json")
                .AddHeader("Content-Type", "multipart/form-data")
                .AddFile("file", AppDomain.CurrentDomain.BaseDirectory + "/image.jpg");
            var response = client.Execute(request);
            return response;
        }
    }
}
