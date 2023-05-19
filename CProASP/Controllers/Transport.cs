using CProASP.MiniDateBase;
using CProASP.Transport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CProASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        public static List<BaseTransport> Transports { get; set; } = new List<BaseTransport> { };
        public static int samecheck = 0;

        [HttpGet]
        public ActionResult<List<BaseTransport>> Getvalue()
        {
            if(samecheck == 0)
            {
                samecheck = 1;
                Transports = GetDateBase.ReadFile();
            }

            if (Transports.Count == 0) return NotFound(new { Code = 404, Date = "The list is empety" });
               
            return Ok(new { Code = 200, Date = Transports });
        }

        [HttpGet("{id}")]
        public ActionResult<BaseTransport?> GetPeople(int id)
        {      
            var obj = Transports.FirstOrDefault(x => x.Id == id);
            if (obj == null)
                return BadRequest(400);

            return Ok(obj);
        }

        [HttpPost]
        public ActionResult<BaseTransport> AddTransport([FromBody] BaseTransporRequest request)
        {
            var transport = new BaseTransport
            {
                Id = Transports.Count + 1,
                Type = request.Type,
                Speed = request.Speed,
                Weight = request.Weight,
                Status = request.Status
            };
            Transports.Add(transport);
            return new OkObjectResult(transport);
        }

        [HttpPut("{id}")]
        public ActionResult<BaseTransport?> ChangTransport(int id, [FromBody] BaseTransporRequest request)
        {
            var changTransport =  Transports.FirstOrDefault(x => x.Id == id);
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
            var removeTransport = Transports.FirstOrDefault(x => x.Id == id);
            if (removeTransport == null) return NotFound(new { Code = 404, Date = "The object not found or deleted earlier" });
            Transports.Remove(removeTransport);
            return Ok(200);
        }
    }
}
