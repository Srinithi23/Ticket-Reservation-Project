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
    public class SearchTrainController : Controller
    {
        string Baseurl = "https://localhost:44330";

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
        }


      
        public ActionResult ErrorView()
        {
            return View();
        }



        [HttpGet]
        public IActionResult SearchTrain()
        {
           // ViewBag.FromList = ToSelectList(_dt, "fr", "CityName");
            return View();
        }
        [HttpPost]
        public  IActionResult SearchTrain(SearchTrain SD)
        {
            return RedirectToAction("SearchedTrain", "SearchTrain", new { from=SD.FromStation,to=SD.ToStation});
        }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }

        [HttpGet]
        public async Task<ActionResult> SearchedTrain(string from, string to)
        {

            List<TrainDetail> Train = new List<TrainDetail>();
            
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.GetAsync("https://localhost:44330/api/TrainDetails/" + from + "," + to))
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Train = JsonConvert.DeserializeObject<List<TrainDetail>>(apiResponse);
              
                    }


                }
                if(Train.Count==0)
                {
                    return RedirectToAction("ErrorView");

                }
            return View(Train);
            
          

        }
            
        
       
           // return View();
        


       /* [HttpPost]
        public async Task<ActionResult> SearchTrain(SearchTrain e)
        {
            SearchTrain Passobj = new SearchTrain();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44372/api/TrainDetails ", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Passobj = JsonConvert.DeserializeObject<SearchTrain>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }*/


    }
}
