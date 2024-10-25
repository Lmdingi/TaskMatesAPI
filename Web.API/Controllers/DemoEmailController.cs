using DataAccess.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoEmailController : ControllerBase
    {
        private readonly IDemoEmailListService _demoEmailListService;

        public DemoEmailController(IDemoEmailListService demoEmailListService)
        {
            _demoEmailListService = demoEmailListService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var emailList = await _demoEmailListService.GetAllAsync();

                if (emailList == null)
                {
                    return BadRequest();
                }

                return Ok(emailList);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
