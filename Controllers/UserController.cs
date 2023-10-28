using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                List<UserModel> result = await _userBusiness.GetUsers();
                return result.Count > 0
                    ? Ok(new ResponseInfo(HttpStatusCode.OK, "Users fetched successfully", result))
                    : NotFound(new ResponseInfo(HttpStatusCode.NotFound, "Users not found", null));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "Exception", ex.Message));
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            try
            {
                int result = await _userBusiness.CreateUser(createUserRequest);
                return result > 0
                    ? Ok(new ResponseInfo(HttpStatusCode.OK, "User saved successfully", result))
                    : BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "User save failed", result));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "Exception", ex.Message));
            }
        }

            [HttpPost("ValidateUser")]
            public async Task<IActionResult> ValidateUser(UserModel userModel)

            {
                try
                {
                    bool result = await _userBusiness.ValidateUser(userModel);
                        return result
                        ? Ok(new ResponseInfo(HttpStatusCode.OK, "true", result))
                        : BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "false", result));
                }
                catch (Exception ex)
                {
                    return BadRequest(new ResponseInfo(HttpStatusCode.BadRequest, "Exception", ex.Message));
                }
            }

        
    }
}

