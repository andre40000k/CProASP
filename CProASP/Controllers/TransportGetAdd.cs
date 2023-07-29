using CProASP.Interfaces.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using CProASP.Filter;
using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;
using Microsoft.AspNetCore.Authorization;

namespace CProASP.Controllers
{
    // ОСНОВНЫЕ ИЗМИНЕНИЯ 
    [Route("api/[controller]")]
    [ApiController]
    //[LogFilter]
    //[ResourceFilter]
    public class TransportGetAddController : ControllerBase
    {
        private readonly ILogger<TransportGetAddController> _logger;
        private readonly ITransportService _transportService;

        public TransportGetAddController(
            ITransportService transportRegister,
            ILogger<TransportGetAddController> logger)
        {
            _transportService = transportRegister;
            _logger = logger;
        }

        [HttpPost("add")]
        [Authorize(Roles = "User")]
        public ActionResult AddTransport(BaseTransport baseTransport)
        {
            _logger.LogInformation("Add transport {0}", baseTransport.Type);
            _transportService.AddTransport(baseTransport);
            return Ok(/*_transportRegister.TransportCount()*/);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public ActionResult<BaseTransportRequest> ChangeTransport(int id, [FromBody] BaseTransportRequest baseTransportRequest)
        {
            bool check = _transportService.UpdateTransport(id, baseTransportRequest);

            if(!check) { return BadRequest("Error!\n404"); }

            return Ok();
        }
        //[HttpGet("Id")]
        //public ActionResult GetTransportWithBase(int id)
        //{
        //    var transport = GetDateBase.ReadFile(id);
        //    if (transport == null) { return BadRequest("Error!\n404"); }
        //    _transportRegister.AddTransport(transport);
        //    return Ok(/*_transportRegister.TransportCount()*/);
        //}


        [HttpGet]
        [Authorize]
        public ActionResult GetTransport(int id)
        {
            _logger.LogInformation($"Get id {id} of the transport");
            var transport = _transportService.GetTranspoert(id);
            if (transport == null) { return BadRequest("Error!\n404"); }
            return Ok(transport);
        }
    }
}
