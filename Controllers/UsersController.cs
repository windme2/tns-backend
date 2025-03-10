using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNSBackend.Data;
using TNSBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.Include(u => u.Department).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.Include(u => u.Department)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FullName))
            return BadRequest("FullName is required.");

        if (!_context.Departments.Any(d => d.Id == user.DepartmentId))
            return BadRequest("Invalid DepartmentId.");

        _context.Users.Add(user);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while saving the user.");
        }

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existing = await _context.Users.FindAsync(id);
        if (existing == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(user.FullName))
            return BadRequest("FullName is required.");

        if (!_context.Departments.Any(d => d.Id == user.DepartmentId))
            return BadRequest("Invalid DepartmentId.");

        existing.FullName = user.FullName;
        existing.DepartmentId = user.DepartmentId;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while updating the user.");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while deleting the user.");
        }

        return NoContent();
    }
}
