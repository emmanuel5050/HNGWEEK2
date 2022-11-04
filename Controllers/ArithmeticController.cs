using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArithmeticOperation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArithmeticController : ControllerBase
    {
        

        private readonly ArithmeticService _service;
        private readonly ILogger<ArithmeticController> _logger;

        public ArithmeticController(ILogger<ArithmeticController> logger, ArithmeticService service)
        {
            _logger = logger;
            _service = service;
        }

        

        [HttpPost]
        public IActionResult GetArithmeticResult([FromBody]ArithmeticDTO dto)
        {
            try
            {
                return Ok(_service.PerformArithmeticOperation(dto));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
