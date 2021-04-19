using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterApi.Models;
using RegisterApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginAuthenticationController : Controller
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoginAuthenticationController));
        private readonly IAuthenticationManager manager;

        
        public LoginAuthenticationController(IAuthenticationManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [AllowAnonymous]
        [HttpPost("AuthenicateUser")]
        public IActionResult AuthenticateUser([FromBody] Register user)
        {
            _log4net.Info(" Http Authentication request Initiated");
            var token = manager.Authenticate(user.EmailId, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
