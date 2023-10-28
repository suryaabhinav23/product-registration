using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentsBusiness _equipmentsBusiness;
        

        public EquipmentsController(IEquipmentsBusiness equipmentsBusiness)
        {
            _equipmentsBusiness = equipmentsBusiness;
        }

        [HttpGet("GetEquipments")]
        public async Task<IActionResult> GetEquipments()
        {
            try
            {
                List<EquipmentsModel> result = await _equipmentsBusiness.GetEquipments();
                return result.Count > 0
                    ? Ok(new ResponseInfo(HttpStatusCode.OK, "Equipments fetched successfully", result))
                    : NotFound(new ResponseInfo(HttpStatusCode.NotFound, "Equipments not found", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "Exception", ex.Message));
            }
        }
    }
}