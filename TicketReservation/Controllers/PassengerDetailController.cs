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
    public class PassengerDetailController : Controller
    {
        string Baseurl = "https://localhost:44337/";

        public static PassengerDetail passobj = new PassengerDetail();

        public ActionResult BookedPassenger()
        {
            return View(passobj);
        }

            public async Task<ActionResult> Index()
        {
            List<PassengerDetail> PassengerInfo = new List<PassengerDetail>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/PassengerDetails");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var PassengerResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    PassengerInfo = JsonConvert.DeserializeObject<List<PassengerDetail>>(PassengerResponse);

                }
                //returning the employee list to view  
                return View(PassengerInfo);
            }

          
            }

        [HttpGet]

        public ActionResult Success()
        {
            return View();
        }


        [HttpGet]

        public ActionResult AddPassenger(int id, string email)
        {
            TempData["Tno"] = id;
            TempData["mail"] = email;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPassenger(PassengerDetail e, Bookingdetails booking)
        {
            int id = (int)TempData.Peek("Tno");
            string email = (string)TempData.Peek("mail");
            e.TrainNo = id;
            e.EmailId = email;

            PassengerDetail Passobj = new PassengerDetail();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44337/api/PassengerDetails", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        Passobj = JsonConvert.DeserializeObject<PassengerDetail>(apiResponse);
                    }
                   
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> UpdatePassenger(int sno)
        {
            PassengerDetail passengers = new PassengerDetail();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44337/api/PassengerDetails" + sno))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    passengers = JsonConvert.DeserializeObject<PassengerDetail>(apiResponse);
                }
            }
            return View(passengers);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePassenger(PassengerDetail p)
        {
            PassengerDetail pass = new PassengerDetail();

            using (var httpClient = new HttpClient())
            {

                var id = p.SerialNo;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44337/api/PassengerDetails" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    pass = JsonConvert.DeserializeObject<PassengerDetail>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
