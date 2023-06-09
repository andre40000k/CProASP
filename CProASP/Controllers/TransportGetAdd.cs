﻿using CProASP.Interfaces.ServicesInterface;
using CProASP.Transport;
using CProASP.MiniDateBase;
using Microsoft.AspNetCore.Mvc;

namespace CProASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportGetAddController : ControllerBase
    {
        private readonly ITransportRegister _transportRegister;

        public TransportGetAddController(ITransportRegister transportRegister)
        {
            _transportRegister = transportRegister;
        }

        [HttpPost]
        public ActionResult AddTransport(BaseTransport baseTransport)
        {
            _transportRegister.AddTransport(baseTransport);
            return Ok(_transportRegister.TransportCount());
        }

        [HttpGet("Id")]
        public ActionResult GetTransportWithBase(int id)
        {
            var transport = GetDateBase.ReadFile(id);
            if (transport == null) { return BadRequest("Error!\n404"); }
            _transportRegister.AddTransport(transport);
            return Ok(_transportRegister.TransportCount());
        }


        [HttpGet]
        public ActionResult GetTransport(int id)
        {
            var transport = _transportRegister.GetTranspoert(id);
            if (transport == null) { return BadRequest("Error!\n404"); }
            return Ok(transport);
        }
    }
}
