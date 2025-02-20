using DataAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataAPI.Controllers;

[Route("api/IndustryType")]
[ApiController]
public class IndustryTypeController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IndustryType>>> GetIndustryTypes()
    {
        return await context.IndustryTypes.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IndustryType>> GetIndustryType(int id)
    {
        var industryType = await context.IndustryTypes.FindAsync(id);
        if (industryType == null)
        {
            return NotFound();
        }
        return industryType;
    }

    [HttpPost]
    public async Task<ActionResult<IndustryType>> CreateIndustryType(IndustryType industryType)
    {
        context.IndustryTypes.Add(industryType);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetIndustryType), new { id = industryType.Id }, industryType);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateIndustryType(int id, IndustryType industryType)
    {
        if (id != industryType.Id)
        {
            return BadRequest();
        }

        context.Entry(industryType).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteIndustryType(int id)
    {
        var industryType = await context.IndustryTypes.FindAsync(id);
        if (industryType == null)
        {
            return NotFound();
        }

        context.IndustryTypes.Remove(industryType);
        await context.SaveChangesAsync();

        return NoContent();
    }
}
