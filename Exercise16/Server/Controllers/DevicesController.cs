using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise16.Server.Controllers
{
    [Route("api/devices")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class DevicesController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string Get(string id)
        {
            return "value";
        }

        [HttpPost]
        [Consumes("appliction/json", "application/xml")]
        public void Post([FromBody] string value)
        {
        }

        //[HttpPatch("{id}")]
        // public async Task<ActionResult<DeviceDto>> PatchEvent(string id, JsonPatchDocument<DeviceDto> patchDocument)
        //{
        //return Ok(mapper.Map<DeviceDto>(device));
        //}
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
