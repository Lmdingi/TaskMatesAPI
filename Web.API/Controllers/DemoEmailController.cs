using DataAccess.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoEmailController : ControllerBase
    {
        private readonly TaskmatesDbContext _dbContext;

        public DemoEmailController(TaskmatesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _dbContext.DemoEmailLists.ToListAsync();

                if (list.Count > 0)
                {
                    return Ok(list);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
