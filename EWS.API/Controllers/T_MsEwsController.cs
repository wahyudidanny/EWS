using EWS.API.Services;
using EWS.API.Entities;
using EWS.API.Responses;
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
            {

                return Ok("Successfull Generate PDF");

            }
            else
            {

                return NotFound("Generate PDF Failed!! Please Check Your Log");
            }

        }


        [HttpGet("LevelRekapKebun")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GenerateLevelRekapKebun(string company, string location)
        {


            bool? generatePdf = await _MsEwsServices.GenerateLevelRekapKebun(company, location);
            if (generatePdf != null)
            {

                return Ok("Successfull Generate PDF");

            }
            else
            {

                return NotFound("Generate PDF Failed!! Please Check Your Log");
            }
            
        }


    }
}