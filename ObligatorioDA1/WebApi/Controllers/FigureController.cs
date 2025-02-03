using Microsoft.AspNetCore.Mvc;
using Logic;
using APIDataModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/figure")]
    public class FigureController : Controller
    {
        [HttpPost]
        public IActionResult CreateSphere([FromBody] CreateFigureRequest newFigure)
        {
            if (newFigure == null)
            {
                return BadRequest();
            }
            FigureLogic figureLogic = FigureLogic.Instance;
            try
            {
                figureLogic.CreateFigure(newFigure.ToObject());
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteSphere([FromQuery] string name, string username)
        {
            if (name == null || username == null)
            {
                return BadRequest();
            }
            FigureLogic figureLogic = FigureLogic.Instance;
            
            try
            {
                figureLogic.RemoveFigure(name, username);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public IActionResult GetFiguresByClient([FromQuery] string username)
        {
            if (username == null)
            {
                return BadRequest();
            }
            FigureLogic figureLogic = FigureLogic.Instance;
            ProprietaryRequest client = new ProprietaryRequest { Username = username };
            try
            {
                var proprietary = client.ToObject();
                return Ok(figureLogic.GetFiguresByClient(proprietary));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
