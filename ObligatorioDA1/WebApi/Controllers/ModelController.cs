using Microsoft.AspNetCore.Mvc;
using Logic;
using APIDataModels;
using static APIDataModels.CreateMaterialRequest;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/model")]
    public class ModelController : Controller
    {
        [HttpPost]
        public IActionResult CreateModel([FromBody] CreateModelRequest newModel)
        {
            if (newModel == null)
            {
                return BadRequest();
            }
            ModelLogic modelLogic = ModelLogic.Instance;
            try
            {
                if(newModel.HasPreview)
                    modelLogic.CreateModelWithPreview(newModel.Name, newModel.Proprietary.ToObject(), newModel.Figure.ToObject(), newModel.Material.ToObject());
                else
                    modelLogic.CreateModel(newModel.Name, newModel.Proprietary.ToObject(), newModel.Figure.ToObject(), newModel.Material.ToObject());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetModelsByClient([FromBody] ProprietaryRequest proprietary)
        {
            if (proprietary == null)
            {
                return BadRequest();
            }
            ModelLogic modelLogic = ModelLogic.Instance;
            try
            {
                return Ok(modelLogic.GetClientModels(proprietary.ToObject()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteModel([FromBody] CreateModelRequest model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            ModelLogic modelLogic = ModelLogic.Instance;
            try
            {
                modelLogic.DeleteModel(model.ToObject());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
