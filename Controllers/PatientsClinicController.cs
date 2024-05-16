using ClinicsManagementSystem.Entities;
using ClinicsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PatientsClinicsController : ControllerBase
{
    private readonly CMSContext _context;

    public PatientsClinicsController(CMSContext context)
    {
        _context = context;
    }

    // GET: api/PatientsClinics
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientsClinics>>> GetPatientsClinics()
    {
        return await _context.PatientsClinics
                             .Include(pc => pc.Patient)
                             .Include(pc => pc.Clinic)
                             .ToListAsync();
    }

    // GET: api/PatientsClinics/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PatientsClinics>> GetPatientsClinics(int id)
    {
        var patientsClinics = await _context.PatientsClinics
                                            .Include(pc => pc.Patient)
                                            .Include(pc => pc.Clinic)
                                            .FirstOrDefaultAsync(pc => pc.FileNo == id);

        if (patientsClinics == null)
        {
            return NotFound();
        }

        return patientsClinics;
    }

    // POST: api/PatientsClinics
    [HttpPost]
    public async Task<ActionResult<PatientsClinics>> PostPatientsClinics(PatientsClinics patientsClinics)
    {
        var patientExists = await _context.Patients.AnyAsync(p => p.PatientId == patientsClinics.PatientId);
        var clinicExists = await _context.Clinics.AnyAsync(c => c.ClinicId == patientsClinics.ClinicId);

        if (!patientExists)
        {
            return NotFound($"Patient with ID {patientsClinics.PatientId} not found.");
        }

        if (!clinicExists)
        {
            return NotFound($"Clinic with ID {patientsClinics.ClinicId} not found.");
        }

        _context.PatientsClinics.Add(patientsClinics);
        await _context.SaveChangesAsync();

        // Reload the patientsClinics object to include the related entities
        _context.Entry(patientsClinics).Reference(pc => pc.Patient).Load();
        _context.Entry(patientsClinics).Reference(pc => pc.Clinic).Load();

        return CreatedAtAction("GetPatientsClinics", new { id = patientsClinics.FileNo }, patientsClinics);
    }

    // PUT: api/PatientsClinics/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatientsClinics(int id, PatientsClinics patientsClinics)
    {
        if (id != patientsClinics.FileNo)
        {
            return BadRequest();
        }

        _context.Entry(patientsClinics).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientsClinicsExists(id))
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

    // DELETE: api/PatientsClinics/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatientsClinics(int id)
    {
        var patientsClinics = await _context.PatientsClinics.FindAsync(id);
        if (patientsClinics == null)
        {
            return NotFound();
        }

        _context.PatientsClinics.Remove(patientsClinics);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientsClinicsExists(int id)
    {
        return _context.PatientsClinics.Any(e => e.FileNo == id);
    }
}
