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
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteSphere([FromBody] DeleteFigureRequest deleteFigure)
        {
            if (deleteFigure == null)
            {
                return BadRequest();
            }
            FigureLogic figureLogic = FigureLogic.Instance;
            try
            {
                figureLogic.RemoveFigure(deleteFigure.Name, deleteFigure.Username);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public IActionResult GetFiguresByClient([FromBody] ProprietaryRequest client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            FigureLogic figureLogic = FigureLogic.Instance;
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
