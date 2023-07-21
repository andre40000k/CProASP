using CProASP.Interfaces.ServicesInterface;
using CProASP.MiniDateBase;
using Microsoft.AspNetCore.Mvc;
using CProASP.Filter;
using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;

namespace CProASP.Controllers
{
    // ОСНОВНЫЕ ИЗМИНЕНИЯ 
    [Route("api/[controller]")]
    [ApiController]
    [LogFilter]
    [ResourceFilter]
    public class TransportGetAddController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportGetAddController(ITransportService transportRegister)
        {
            _transportService = transportRegister;
        }

        [HttpPost("add")]
        public ActionResult AddTransport(BaseTransport baseTransport)
        {
            _transportService.AddTransport(baseTransport);
            return Ok(/*_transportRegister.TransportCount()*/);
        }

        [HttpPut]
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
        public ActionResult GetTransport(int id)
        {
            var transport = _transportService.GetTranspoert(id);
            if (transport == null) { return BadRequest("Error!\n404"); }
            return Ok(transport);
        }
    }
}
