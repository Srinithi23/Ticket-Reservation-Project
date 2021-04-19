using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassengerApi.Models;
using PassengerApi.Repository;

namespace PassengerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerDetailsController : ControllerBase
    {
        //private readonly TICKET_BOOKINGContext _context;
        private readonly IPassenger _context;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(PassengerDetailsController));

        public PassengerDetailsController(IPassenger context)
        {
            _context = context;
        }
        

        // GET: api/PassengerDetails
        [HttpGet]
        public IEnumerable<PassengerDetail> GetPassengerDetails()
        {
            log.Info("Get Method is invoked");
            return _context.GetPassengerDetail();
        }

        // GET: api/PassengerDetails/5
        [HttpGet("{id}")]
        public IActionResult GetPassengerById(int sno)
        {
            log.Info("Get by id is called!");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var passenger = _context.GetPassengerById(sno);
            log.Info("Data of the id returned!");

            if (passenger == null)
            {
                return NotFound();
            }

            return Ok(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassenger(PassengerDetail passenger)
        {
            log.Info("Add Passenger method is called!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temp = await _context.AddPassenger(passenger);

            return Ok(passenger);
        }
        [HttpPut("{sno}")]
        public async Task<IActionResult> UpdatePassengerDetail(PassengerDetail passenger,int sno)
        {
            
            log.Info("Update Passenger method is called!");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedpassenger =  _context.UpdatePassengerDetail(passenger,sno );
            return Ok(editedpassenger);
        }
        /*private bool PersonExists(int sno)
        {
            log.Info("SerialNo Exists method is Invoked");

            return _context.Pass.Any(e => e.S == id);
        }*/
    }
}