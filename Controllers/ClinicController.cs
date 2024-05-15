using ClinicsManagementSystem.Entities;
using ClinicsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly CMSContext _context;
        public ClinicController(CMSContext context)
        {
            _context = context;
        }

        // GET: api/<PaymentDetailController>


        // GET: api/PaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            return await _context.Clinics.ToListAsync();
        }

        // GET: api/PaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetClinic(int id)
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            var clinic = await _context.Clinics.FindAsync(id);

            if (clinic == null)
            {
                return NotFound();
            }

            return clinic;
        }

        // PUT: api/City/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, Clinic clinic)
        {
            Console.WriteLine("Updte aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            Console.WriteLine(clinic);
            if (id != clinic.ClinicId)
            {
                return BadRequest();
            }

            _context.Entry(clinic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClinicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.Clinics.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
        {
            if (_context.Clinics == null)
            {
                return Problem("Entity set 'CMSContext.Clinics' is null.");
            }

            // Turn on IDENTITY_INSERT
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Cities ON;");

            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();

            // Turn off IDENTITY_INSERT
            await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Cities OFF;");

            return Ok(await _context.Clinics.ToListAsync());
        }

        // POST: api/PaymentDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
        //{
        //    if (_context.Clinics == null)
        //    {
        //        return Problem("Entity set 'CMSContext.Clinics'  is null.");
        //    }
        //    _context.Clinics.Add(clinic);
        //    await _context.SaveChangesAsync();

        //    return Ok(await _context.Clinics.ToListAsync());
        //}

        // DELETE: api/PaymentDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinic(int id)
        {
            if (_context.Clinics == null)
            {
                return NotFound();
            }
            var clinic = await _context.Clinics.FindAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            _context.Clinics.Remove(clinic);
            await _context.SaveChangesAsync();

            return Ok(await _context.Clinics.ToListAsync());
        }

        private bool ClinicExists(int id)
        {
            return (_context.Clinics?.Any(e => e.ClinicId == id)).GetValueOrDefault();
        }
    }
}
