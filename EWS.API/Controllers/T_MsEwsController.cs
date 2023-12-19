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
        public async Task<ActionResult> GeneratePdfContent()
        {

            byte[] pdfContent = await _MsEwsServices.GenerateContentPdf();
            string filename = "Dummy_TestEWS.pdf";
            return File(pdfContent, "application/pdf", filename);

        }

    }
}