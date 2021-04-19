using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterApi.Models;

namespace RegisterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly TICKET_BOOKINGContext _context;
       
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(RegistersController));

        public RegistersController(TICKET_BOOKINGContext context)
        {
            _context = context;
        }

        // GET: api/Registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Register>>> GetRegisters()
        {
            return await _context.Registers.ToListAsync();
        }

        // GET: api/Registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Register>> GetRegister(string id)
        {
            _log4net.Info("Get Register by " + id + " is Invoked");

            var register = await _context.Registers.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }

        // PUT: api/Registers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegister(string id, Register register)
        {
            _log4net.Info("Put Register by " + id + " is Invoked");

            if (id != register.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(id))
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

        // POST: api/Registers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            _log4net.Info("Post Register is Invoked to add");

            _context.Registers.Add(register);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RegisterExists(register.EmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegister", new { id = register.EmailId }, register);
        }

        // DELETE: api/Registers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Register>> DeleteRegister(string id)
        {
            _log4net.Info("Delete Register is Invoked");

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();

            return register;
        }

        private bool RegisterExists(string id)
        {
            _log4net.Info("Register Exists method is Invoked");

            return _context.Registers.Any(e => e.EmailId == id);
        }
    }
}
