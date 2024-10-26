using DataAccess.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interfaces;
using System.Text.Json;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoEmailController : ControllerBase
    {
        private readonly IDemoEmailListService _demoEmailListService;
        private readonly ILogger<DemoEmailController> _logger;

        public DemoEmailController(IDemoEmailListService demoEmailListService, ILogger<DemoEmailController> logger)
        {
            _demoEmailListService = demoEmailListService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _logger.LogInformation("'Get' all emails list Action Method was invoked");

                var emailList = await _demoEmailListService.GetAllAsync();

                if (emailList == null)
                {
                    _logger.LogInformation($"'Get' all emails list Action Method finished: no emails found");
                    return BadRequest();
                }

                _logger.LogInformation($"'Get' all emails list Action Method finished with data: {JsonSerializer.Serialize(emailList, new JsonSerializerOptions { WriteIndented = true })}");

                return Ok(emailList);                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
