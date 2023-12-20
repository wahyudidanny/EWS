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

        [HttpGet("PdfEws")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GeneratePdfContent()
        {

            byte[]? pdfContent = await _MsEwsServices.GenerateContentPdf();

            if (pdfContent != null) {
            
                return File(pdfContent, "application/pdf",  "Dummy_TestEWS.pdf"); 

            }else {
                
                return NotFound("Requested data not found");

            }
            
        }

    }
}