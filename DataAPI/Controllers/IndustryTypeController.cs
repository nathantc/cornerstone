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
}
