using Microsoft.AspNetCore.Mvc;
using Logic;
using APIDataModels;
using Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/material")]
    public class MaterialController : Controller
    {
        [HttpPost]
        public IActionResult CreateMaterial([FromBody] CreateMaterialRequest materialRequest)
        {
            if (materialRequest == null)
            {
                return BadRequest();
            }
            MaterialLogic materialLogic = MaterialLogic.Instance;
            try
            {
                if(materialRequest.Type.ToLower() == "lambertian")
                {
                    var RequestProprietary = materialRequest.Proprietary.ToObject();
                    var RequestColor = materialRequest.Color.ToObject();
                    materialLogic.CreateLambertian(RequestProprietary, materialRequest.Name, RequestColor);
                    return Ok();
                }
                else if (materialRequest.Type.ToLower() == "metallic")
                {
                    var metallicMaterial = materialRequest.ToObject();
                    materialLogic.CreateMetallic(metallicMaterial as Metallic);
                    return Ok();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetMaterialsByProprietary([FromBody] ProprietaryRequest getMaterialsByClientRequest)
        {
            if (getMaterialsByClientRequest == null)
            {
                return BadRequest();
            }
            MaterialLogic materialLogic = MaterialLogic.Instance;
            try
            {
                var RequestProprietary = getMaterialsByClientRequest.ToObject();
                var materials = materialLogic.GetClientMaterials(RequestProprietary);
                return Ok(materials);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteMaterial([FromBody] DeleteMaterialRequest deleteMaterialRequest)
        {
            if (deleteMaterialRequest == null)
            {
                return BadRequest();
            }
            MaterialLogic materialLogic = MaterialLogic.Instance;
            try
            {
                var RequestMaterial = deleteMaterialRequest.ToObject();
                materialLogic.DeleteMaterial(RequestMaterial);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
