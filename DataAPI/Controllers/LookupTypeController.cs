using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class LookTypeController<T> : ControllerBase where T : class, ILookupType
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    protected LookTypeController(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        await Console.Out.WriteLineAsync("retrieving list of entities.");
        return await _dbSet.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<T>> GetType(int id)
    {
        var type = await _dbSet.FindAsync(id);
        if (type == null)
        {
            return NotFound();
        }
        return type;
    }

    [HttpPost]
    public async Task<ActionResult<T>> CreateType(T type)
    {
        _dbSet.Add(type);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetType), new { id = type.Id }, type);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateType(int id, T type)
    {
        if (id != type.Id)
        {
            return BadRequest();
        }

        _context.Entry(type).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteType(int id)
    {
        var type = await _dbSet.FindAsync(id);
        if (type == null)
        {
            return NotFound();
        }

        _dbSet.Remove(type);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

public class LicenseTypeController(AppDbContext context) : LookTypeController<LicenseType>(context);

public class FilingTypeController(AppDbContext context) : LookTypeController<FilingType>(context);

public class IndustryTypeController(AppDbContext context) : LookTypeController<IndustryType>(context);
