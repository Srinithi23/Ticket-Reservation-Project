using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{
    public class RegisterController : Controller
    {
        /*public IActionResult Index()
        {
            return View();
        }*/
        string Baseurl = "https://localhost:44351/";
        public async Task<ActionResult> Index()
        {
            List<Register> RegInfo = new List<Register>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Registers");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var RegResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    RegInfo = JsonConvert.DeserializeObject<List<Register>>(RegResponse);

                }
                //returning the employee list to view  
                return View(RegInfo);
            }
        }

        public ActionResult RegisterPassenger()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPassenger(Register e)
        {
            if (ModelState.IsValid)
            {

                Register Passobj = new Register();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44351/api/Registers", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Passobj = JsonConvert.DeserializeObject<Register>(apiResponse);
                    }
                }
                ViewBag.Message = "Registration successful";

                return RedirectToAction("Login", "Login");
            }
            return View();

        }



    }
}
