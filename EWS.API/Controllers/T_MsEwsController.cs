using EWS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EWS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class T_MsEwsController : ControllerBase
    {
        private readonly T_MsEwsServices _MsEwsServices;

        public T_MsEwsController(T_MsEwsServices MsEwsServices)
        {
            _MsEwsServices = MsEwsServices;
        }

        [HttpGet("LevelRekapAfdeling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GenerateLevelRekapAfdeling(string company, string location)
        {

            bool? generatePdf = await _MsEwsServices.GenerateLevelRekapAfdeling(company, location);
            if (generatePdf != null)
                return Ok("Successfull Generate PDF Afdeling");
            else
                return NotFound("Generate PDF Failed!! Please Check Your Log");
        }

        [HttpGet("LevelRekapKebun")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GenerateLevelRekapKebun()
        {

            bool? generatePdf = await _MsEwsServices.GenerateLevelRekapKebun();
            if (generatePdf != null)
                return Ok("Successfull Generate PDF Kebun");
            else
                return NotFound("Generate PDF Failed!! Please Check Your Log");
        }

        [HttpGet("LevelRekapGroup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GenerateLevelRekapGroup()
        {

            bool? generatePdf = await _MsEwsServices.GenerateLevelRekapGroup();
            if (generatePdf != null)
                return Ok("Successfull Generate PDF Group");
            else
                return NotFound("Generate PDF Failed!! Please Check Your Log");

        }


        [HttpGet("GenerateAllRegion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GenerateAllRegion()
        {

            try
            {
                await _MsEwsServices.GenerateEWSAllRegion();
                return Ok("Successfull Execute All Region");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

    }
}