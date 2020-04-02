using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace PetStoreApiTests.RestHelper
{
    class UserEndpoint : Endpoint
    {
        public UserEndpoint(RestClient client) : base(client)
        {

        }
        public IRestResponse CreateWithArray(User[] users)
        {
            string json = JsonConvert.SerializeObject(users);
            var request = new RestRequest("/user/createWithArray", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse CreateWithList(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users);
            var request = new RestRequest("/user/createWithList", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse Post(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var request = new RestRequest("/user", Method.POST).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public User Get(string username)
        {
            var request = new RestRequest("/user/{username}", Method.GET).AddParameter("username", username, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }
        public IRestResponse Put(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            var request = new RestRequest("/user/{username}", Method.POST).AddParameter("username", user.GetUsername(), ParameterType.UrlSegment).AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse Delete(string username)
        {
            var request = new RestRequest("/user/{username}", Method.DELETE).AddParameter("username", username, ParameterType.UrlSegment);
            var response = client.Execute(request);
            return response;
        }
        public Dictionary<string, string> Login(string username, string password)
        {
            var request = new RestRequest("/user/login", Method.GET).AddParameter("username", username).AddParameter("password", password);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }
        public Dictionary<string, string> Logout()
        {
            var request = new RestRequest("/user/logout", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
        }
    }
}
