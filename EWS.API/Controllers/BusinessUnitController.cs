using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EWS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessUnitController : ControllerBase
    {
        public BusinessUnitController()
        {

        }

        public async Task<IActionResult> GetDataByRegionGroup(string region, string group)
        {

            return Ok(new
            {
                message = "success"
            });
        }
    }
}