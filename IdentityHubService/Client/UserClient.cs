using DataService.Data;
using DataService.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdentityHubService.Client
{
    public class UserClient
    {
        APIClient APIClient;


        public UserClient()
        {
            APIClient = new APIClient("https://localhost:7197/api/User/Register");
            //APIClient = new APIClient();
        }
        public HttpResponseMessage Register(User User)
        {
            string RegisterURL = "Register";
            return APIClient.MakePostCall(RegisterURL,User);
        }
        public string GetAttribute(string url,string key)
        {
            Console.WriteLine(APIClient.MakeGetAPICall(url));
            return "Hi";
        }
    }
}
