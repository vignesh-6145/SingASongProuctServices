﻿using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Data
{
    public class APIClient
    {
        HttpClient client;
        public APIClient(string BaseAddress) { 
            client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);  

        }  
        public HttpStatusCode MakePutCall(string url, Track obj)
        {
            HttpResponseMessage response = client.PutAsJsonAsync(url, obj).GetAwaiter().GetResult();
            Console.WriteLine(response.Content); 
            return response.StatusCode;
        }
        public HttpStatusCode MakePostCall(string url, Track obj)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(url,obj).GetAwaiter().GetResult();
            Console.WriteLine(response.StatusCode);
            return response.StatusCode;
        }
        public string MakeGetAPICall(string url)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();
                if(response.IsSuccessStatusCode) {
                    var resposneStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //need to send along with the response code
                    return resposneStr;
                }
                else
                {
                    Console.WriteLine("Some with went wrong");
                }
                return "<null>";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't Make a call to {client.BaseAddress+url}");   
                Console.WriteLine(ex.Message);
            }
                
            return "<null>";
        }
        
        public HttpStatusCode MakeDeleteCall(string url)
        {
            HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();
            return response.StatusCode;

        }
    }
}