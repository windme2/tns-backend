using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNSBackend.Data;
using TNSBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DepartmentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        return await _context.Departments.Include(d => d.Users).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _context.Departments.Include(d => d.Users)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (department == null) return NotFound();
        return department;
    }

    [HttpPost]
    public async Task<ActionResult<Department>> Create(Department department)
    {
        if (string.IsNullOrWhiteSpace(department.Name))
            return BadRequest("Department name is required.");

        _context.Departments.Add(department);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while creating the department.");
        }

        return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Department department)
    {
        if (id != department.Id)
            return BadRequest();

        var existing = await _context.Departments.FindAsync(id);
        if (existing == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(department.Name))
            return BadRequest("Department name is required.");

        existing.Name = department.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the department.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null) return NotFound();

        _context.Departments.Remove(department);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the department.");
        }

        return NoContent();
    }
}
