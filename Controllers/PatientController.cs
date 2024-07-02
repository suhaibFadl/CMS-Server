﻿using ClinicsManagementSystem.Entities;
using ClinicsSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly CMSContext _context;

    public PatientsController(CMSContext context)
    {
        _context = context;
    }

    // GET: api/Patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    // GET: api/Patients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    [HttpGet("by-name")]
    public async Task<ActionResult<Patient?>> GetPatientByName(string name)
    {
        var patient = await _context.Patients
                                    .Include(p => p.PatientsClinics)
                                    .ThenInclude(pc => pc.Clinic)
                                    .FirstOrDefaultAsync(p => p.Name == name);
        return patient;
    }


// POST: api/Patients
[HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
    }

    // PUT: api/Patients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, Patient patient)
    {
        if (id != patient.PatientId)
        {
            return BadRequest();
        }

        _context.Entry(patient).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PatientExists(id))
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

    // DELETE: api/Patients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _context.Patients.Include(p => p.PatientsClinics).FirstOrDefaultAsync(p => p.PatientId == id);

        if (patient == null)
        {
            return NotFound();
        }

         if (patient.PatientsClinics.Any())
        {
            return Conflict("Cannot delete patient as it has related patients clinics.");
        }
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.PatientId == id);
    }
}
