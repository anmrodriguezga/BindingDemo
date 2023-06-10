using Microsoft.AspNetCore.Mvc;
using WebApplication2.Queries;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/Parcel")]
    public class ParcelController : ApiController
    {
        [HttpGet("GetParcel")]
        public async Task<IActionResult> GetParcel(
            [FromQuery] GetParcelByParcelNumber.Query request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("GetParcelJson")]
        public async Task<IActionResult> GetParcelJson(
            [FromQuery] GetParcelJsonByParcelNumber.Query request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
