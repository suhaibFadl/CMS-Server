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
    [HttpGet("by-id/{id}")]
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

    [HttpGet("by-patientId-and-clinicId")]
    public async Task<PatientsClinics?> GetPatientsClinics(int patientId, int clinicId)
    {
        var patientsClinics = await _context.PatientsClinics
                                            .Include(pc => pc.Patient)
                                            .Include(pc => pc.Clinic)
                                            .FirstOrDefaultAsync(pc => pc.Patient!.PatientId == patientId && pc.Clinic!.ClinicId == clinicId);

        return patientsClinics; // Will return null if no match is found
    } 

    [HttpGet("by-name")]
    public async Task<ActionResult<List<PatientsClinics>>> GetPatientsClinics(string name)
    {
        var patientsClinics = await _context.PatientsClinics
                                        .Include(pc => pc.Patient)
                                        .Include(pc => pc.Clinic)
                                        .Where(pc => pc.Patient!.Name == name)
                                        .ToListAsync();
  
        return patientsClinics; // Will return null if no match is found
    }

    // POST: api/PatientsClinics
   [HttpPost]
    public async Task<ActionResult<PatientsClinics>> PostPatientsClinics(PatientsClinics patientsClinics)
    {
        // Check if an entry with the same PatientId and ClinicId already exists
        var existingEntry = await _context.PatientsClinics
                                          .FirstOrDefaultAsync(pc => pc.PatientId == patientsClinics.PatientId && pc.ClinicId == patientsClinics.ClinicId);

        if (existingEntry != null)
        {
            // If such an entry exists, return a conflict response
            return Conflict("A record with the same PatientId and ClinicId already exists.");
        }

        _context.PatientsClinics.Add(patientsClinics);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPatientsClinics), new { id = patientsClinics.FileNo }, patientsClinics);
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
