using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestArrayOrganizedChallenge.Interfaz;
using TestArrayOrganizedChallenge.Request;
using TestArrayOrganizedChallenge.Response;

namespace TestArrayOrganizedChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReOrganizedArrayController : ControllerBase
    {
        public readonly IReOrganizedArray _reOrganizedArray;

        public ReOrganizedArrayController(IReOrganizedArray reOrganizedArray)
        {
            _reOrganizedArray = reOrganizedArray;
        }

        [HttpGet]
        [Route("ArrayReOrganized")]
        public IActionResult ArrayReOrganized([FromBody] ReOrganizedArrayRequest reOrganizedArrayRequest)
        {
            ReOrganizedArrayResponse reOrganizedArrayResponse = new ReOrganizedArrayResponse();
            reOrganizedArrayResponse.reorganizedname = _reOrganizedArray.ReOrganizedArrayNames(reOrganizedArrayRequest);

            var result = JsonConvert.SerializeObject(reOrganizedArrayResponse);

            return Ok(result);
        }
    }
}
