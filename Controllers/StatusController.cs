using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusBusiness _statusBusiness;


        public StatusController(IStatusBusiness statusBusiness)
        {
            _statusBusiness = statusBusiness;
        }

        [HttpGet("GetStatus")]
        public async Task<IActionResult> GetStatus()
        {
            try
            {
                List<StatusModel> result = await _statusBusiness.GetStatus();
                return result.Count > 0
                    ? Ok(new ResponseInfo(HttpStatusCode.OK, "Registered", result))
                    : NotFound(new ResponseInfo(HttpStatusCode.NotFound, "not registered", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "Exception", ex.Message));
            }
        }
    }
}
