using CProASP.Interfaces.ServicesInterface;
using CProASP.Transport;
using Microsoft.AspNetCore.Mvc;

namespace CProASP.Controllers
{
    // 
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportRegister;
        private readonly ITransportChang _transportChang;

        public TransportController(ITransportService transportRegister,
            ITransportChang transportChang)
        {
            _transportRegister = transportRegister;
            _transportChang = transportChang;
        }


        [HttpGet]
        public ActionResult Getvalue()
        {
            if (_transportChang.CountList() == 0) return NotFound(new { Code = 404, Date = "The list is empety" });

            return Ok(/*new { Code = 200, Date = _transportRegister.GetTranspoert() }*/);
        }

        [HttpGet("{id}")]
        public ActionResult GetPeople(int id)
        {
            var obj = _transportRegister.GetTranspoert(id);
            if (obj == null)
                return BadRequest(400);

            return Ok(obj);
        }

        [HttpPost]
        public ActionResult AddTransport([FromBody] BaseTransporRequest request)
        {
            var transport = new BaseTransport(100, request.Type,
                request.Weight, request.Speed, request.Status);

            _transportRegister.AddTransport(transport);
            return new OkObjectResult(transport);
        }

        [HttpPut("{id}")]
        public ActionResult<BaseTransport?> ChangTransport(int id, [FromBody] BaseTransporRequest request)
        {
            var changTransport = _transportRegister.GetTranspoert(id);

            if (changTransport == null) return NotFound(404);

            changTransport.Type = request.Type;
            changTransport.Speed = request.Speed;
            changTransport.Weight = request.Weight;
            changTransport.Status = request.Status;

            return Ok(changTransport);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransport(int id)
        {

            _transportChang.RemoveTransport(id);
            return Ok(200);
        }
    }
}
