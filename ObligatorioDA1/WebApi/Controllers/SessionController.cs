using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic;
using APIDataModels;

namespace WebApi.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpPut]
        public IActionResult LogIn([FromBody] LogInRequest logInRequest)
        {
            if (logInRequest == null)
            {
                return BadRequest();
            }
            try
            {
                SessionLogic.Instance.LogIn(logInRequest.Username, logInRequest.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

