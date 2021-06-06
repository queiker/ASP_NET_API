using Microsoft.AspNetCore.Mvc;
using RequestCounter.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("API/RequestCounter")]
    public class RequestCounterController : Controller
    {
        private readonly IRequestCountStatsService _reqcountservice;

        // GET
        public RequestCounterController(IRequestCountStatsService reqcountservice)
        {
            _reqcountservice = reqcountservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _reqcountservice.IncreaseCounter("GET");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            _reqcountservice.IncreaseCounter("Post");
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            _reqcountservice.IncreaseCounter("Put");
            return Ok();
        }

        [HttpPatch]
        public IActionResult Patch()
        {
            _reqcountservice.IncreaseCounter("Patch");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            _reqcountservice.IncreaseCounter("Delete");
            return Ok();
        }
    }
}