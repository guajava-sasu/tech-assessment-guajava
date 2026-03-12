using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeChooz.TechAssessment.Web.Data;
using WeChooz.TechAssessment.Web.Dtos;

namespace WeChooz.TechAssessment.Web.Formations;

[ApiController]

public sealed class CoursApiController(TechAssessmentDbContext db) : ControllerBase
{
    [HttpGet]
    [Route("_api/formations")]
    public async Task<ActionResult<IReadOnlyList<CoursDto>>> GetAll(CancellationToken ct)
    {
        try
        {
            var items = await db.Cours
                .AsNoTracking()
                .SelectCoursDto()
                .ToListAsync(ct);

            return Ok(items);
        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while fetching formations.", ex);
        }

    }

    [HttpGet]
    [Route("_api/create/cours")]
    public async Task<ActionResult<IReadOnlyList<CoursDto>>> Create()
    {
        try
        {
            return Ok(null);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while fetching formations.", ex);
        }

    }
}