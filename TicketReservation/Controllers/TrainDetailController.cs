using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{
    public class TrainDetailController : Controller
    {
        string Baseurl = "https://localhost:44372/";

        //public IActionResult searchTrain()
        //{
        //    return View();
        //}

        public async Task<ActionResult> Index()
        {
            List<TrainDetail> TrainInfo = new List<TrainDetail>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/TrainDetails");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TrainResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    TrainInfo = JsonConvert.DeserializeObject<List<TrainDetail>>(TrainResponse);

                }
                //returning the employee list to view  
                return View(TrainInfo);

            }
/*
            [HttpPost]

            public async Task<ActionResult> AddBookingDetail(Bookingdetails booking)
            {
                return RedirectToAction("", "BookingDetail");
            }*/




            }
    }
}
