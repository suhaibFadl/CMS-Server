using ClinicsManagementSystem.Entities;
using ClinicsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly CMSContext _context;

    public ClinicsController(CMSContext context)
    {
        _context = context;
    }

    // GET: api/Clinics
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Clinic>>> GetClinics()
    {
        return await _context.Clinics.Include(c => c.City).ToListAsync();
    }

    // GET: api/Clinics/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clinic>> GetClinic(int id)
    {
        var clinic = await _context.Clinics.Include(c => c.City).FirstOrDefaultAsync(c => c.ClinicId == id);

        if (clinic == null)
        {
            return NotFound();
        }

        return clinic;
    }

    // PUT: api/Clinics/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClinic(int id, Clinic clinic)
    {
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

        return NoContent();
    }

    // POST: api/Clinics
    [HttpPost]
    public async Task<ActionResult<Clinic>> PostClinic(Clinic clinic)
    {
        _context.Clinics.Add(clinic);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetClinic", new { id = clinic.ClinicId }, clinic);
    }

    // DELETE: api/Clinics/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinic(int id)
    {
        var clinic = await _context.Clinics.FindAsync(id);
        if (clinic == null)
        {
            return NotFound();
        }

        _context.Clinics.Remove(clinic);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClinicExists(int id)
    {
        return _context.Clinics.Any(e => e.ClinicId == id);
    }
}
