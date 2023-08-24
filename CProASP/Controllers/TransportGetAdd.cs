using CProASP.Interfaces.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using FluentValidation;
using CProASP.Validations;

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
        private IValidator<BaseTransport> _validatorBase;

        public TransportGetAddController(
            ITransportService transportRegister,
            ILogger<TransportGetAddController> logger,
            IValidator<BaseTransport> validator)
        {
            _transportService = transportRegister;
            _logger = logger;
            _validatorBase = validator;
        }

        [HttpPost("add")]
        [Authorize(Roles = "User")]
        public IActionResult AddTransport(BaseTransport baseTransport)
        {

            ValidationResult results = _validatorBase.Validate(baseTransport);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            _logger.LogInformation("Add transport {0}", baseTransport.Type);
            _transportService.AddTransport(baseTransport);
            return Ok(/*_transportRegister.TransportCount()*/);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult/*<BaseTransportRequest>*/> ChangeTransport(int id, [FromBody] BaseTransportRequest baseTransportRequest)
        {
            //ValidationResult result = await _validator.ValidateAsync(baseTransportRequest);


            //if (!result.IsValid)
            //{
            //    result.AddToModelState(this.ModelState);

            //    return ("Create", baseTransportRequest);
            //}

            bool check = _transportService.UpdateTransport(id, baseTransportRequest);

            if(!check) { return BadRequest("Error!\n404"); }
            
            return RedirectToAction("Index");
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
