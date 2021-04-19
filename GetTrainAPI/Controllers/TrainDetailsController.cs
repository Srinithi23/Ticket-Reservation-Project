using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetTrainAPI.Models;

namespace GetTrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainDetailsController : ControllerBase
    {
        private readonly TICKET_BOOKINGContext _context;

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TrainDetailsController));


        public TrainDetailsController(TICKET_BOOKINGContext context)
        {
            log.Info("TrainDetails is Invoked");
            _context = context;
        }

        // GET: api/TrainDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainDetail>>> GetTrainDetails()
        {
            log.Info("GetTrainDetails is Invoked");
            return await _context.TrainDetails.ToListAsync();
        }

        // GET: api/TrainDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainDetail>> GetTrainDetail(int id)
        {
            log.Info("GetTrainDetails is Invoked");

            var trainDetail = await _context.TrainDetails.FindAsync(id);

            if (trainDetail == null)
            {
                return NotFound();
            }

            return trainDetail;
        }

        // PUT: api/TrainDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainDetail(int id, TrainDetail trainDetail)
        {
            log.Info("GetTrainDetails is Invoked");

            if (id != trainDetail.TrainNo)
            {
                return BadRequest();
            }

            _context.Entry(trainDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TrainDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainDetail>> PostTrainDetail(TrainDetail trainDetail)
        {
            log.Info("PostTrainDetails is Invoked");

            _context.TrainDetails.Add(trainDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainDetail", new { id = trainDetail.TrainNo }, trainDetail);
        }

        // DELETE: api/TrainDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainDetail(int id)
        {
            log.Info("DeleteTrainDetails is Invoked");

            var trainDetail = await _context.TrainDetails.FindAsync(id);
            if (trainDetail == null)
            {
                return NotFound();
            }

            _context.TrainDetails.Remove(trainDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainDetailExists(int id)
        {
            return _context.TrainDetails.Any(e => e.TrainNo == id);
        }
    }
}
