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
    public class BookingDetailController : Controller
    {

        string Baseurl = "https://localhost:44381/";

        public static Bookingdetails book = new Bookingdetails();
        public ActionResult BookingDetails()
        {
            /* List<Bookingdetails> BookingInfo = new List<Bookingdetails>();

             using (var client = new HttpClient())
             {
                 //Passing service base url  
                 client.BaseAddress = new Uri(Baseurl);

                 client.DefaultRequestHeaders.Clear();
                 //Define request data format  
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                 //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                 HttpResponseMessage Res = await client.GetAsync("/api/BookingDetails");

                 //Checking the response is successful or not which is sent using HttpClient  
                 if (Res.IsSuccessStatusCode)
                 {
                     //Storing the response details recieved from web api   
                     var bookingResponse = Res.Content.ReadAsStringAsync().Result;

                     //Deserializing the response recieved from web api and storing into the Employee list  
                     BookingInfo = JsonConvert.DeserializeObject<List<Bookingdetails>>(bookingResponse);

                 }
                 //returning the employee list to view  
                 return View(BookingInfo);
             }*/
            return View(book);
        }
        
    
    [HttpGet]
    public async Task<ActionResult> GetBookById(int id)
        {
            
            List<Bookingdetails> book = new List<Bookingdetails>();

            using (var httpClient = new HttpClient())
        {
                
                using (var response = await httpClient.GetAsync("https://localhost:44381/api/BookingDetails/" + id))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<List<Bookingdetails>>(apiResponse);

                }
            }
            return View(book);
        }


        //[HttpGet]
        //public async Task<ActionResult> BookedPassenger(int BookId)
        //{


        //    using (var httpClient = new HttpClient())
        //    {

        //        using (var response = await httpClient.GetAsync("https://localhost:44330/api/TrainDetails/" + BookId ))
        //        {

        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //          //  Train = JsonConvert.DeserializeObject<List<TrainDetail>>(apiResponse);

        //        }


        //    }
        //    return View(Train);



        //}






        public ActionResult AddBookingDetail(int  id,string from,string to,int ClassA, int ClassB, int ClassC,string email)
        {
            TempData["Email"] = email;
            TempData["Tno"] = id;
            TempData["Tf"] = from;
            TempData["Tt"] = to;
            TempData["classA"] = ClassA;
            TempData["classB"] = ClassB;
            TempData["classC"] = ClassC;

            //   Bookingdetails=

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddBookingDetail(Bookingdetails booking,TrainDetail train,Register register)
        {

            string email = (string)TempData.Peek("mail");
            int id = (int)TempData.Peek("Tno");
            string from = (string)TempData.Peek("Tf");
            string to = (string)TempData.Peek("Tt");
            int ClassA = (int)TempData.Peek("classA");
            int ClassB = (int)TempData.Peek("classB");
            int ClassC = (int)TempData.Peek("classC");
            
            booking.FromStation = from;
            booking.TrainNo = id;
            booking.ToStation = to;
            train.SeatAvailA = ClassA - booking.NoOfSeats;
            train.SeatAvailB = ClassB - booking.NoOfSeats;
            train.SeatAvailC = ClassC - booking.NoOfSeats;

            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44381/api/BookingDetails", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Bookingdetails>(apiResponse);
                }
               
            }
            return RedirectToAction("BookingDetails");
           
        }
        public bool DateCheck(Bookingdetails book)
        {
            if (book.JourneyDate < DateTime.Today)
            {

                return false;
                
            }
            else
            {
                return true;
            }
        }
        [HttpGet]
        public async Task<ActionResult> CancelTicket(int id)
        {
            TempData["BookingId"] = id;
            Bookingdetails e = new Bookingdetails();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44381/api/BookingDetails" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    e = JsonConvert.DeserializeObject<Bookingdetails>(apiResponse);
                }
            }
            return View(e);
        }


        [HttpPost]
        // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> CancelTicket(Bookingdetails book)
        {
            int BookingId = Convert.ToInt32(TempData["BookingId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44381/api/BookingDetails/" + BookingId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
