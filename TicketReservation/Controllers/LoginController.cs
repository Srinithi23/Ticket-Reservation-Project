using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TicketReservation.Models;

namespace TicketReservation.Controllers
{
    public class LoginController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginController));
        //Get Login

        public IActionResult Login(string email)
        {
            TempData["mail"] = email;
            TempData.Peek("mail");
            _log4net.Info("Http Login Request Initiated");
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Login(Login user)
        {
            string token = "";
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("https://localhost:44351/");
                var postData = httpclient.PostAsJsonAsync<Login>("/api/LoginAuthentication/AuthenicateUser", user);
                var res = postData.Result;
                if (res.IsSuccessStatusCode)
                {
                    token = await res.Content.ReadAsStringAsync();
                    TempData["token"] = token;
                    if (token != null)
                    {
                        return RedirectToAction("SearchTrain", "SearchTrain");
                    }
                }
            }
            return View("Login");

        }
    }

}

