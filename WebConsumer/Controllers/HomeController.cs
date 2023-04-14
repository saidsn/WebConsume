using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using WebConsumer.Models;

namespace WebConsumer.Controllers
{
    public class HomeController : Controller
    {

        string baseUrl = "https://jsonplaceholder.typicode.com/";
        public async Task<IActionResult> Index()
        {
            List<User> user= new List<User>();

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage acceptedData = await client.GetAsync("users/1/posts");


                string results = acceptedData.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(results);


            }

            return View(user);
        }

   
    }
}