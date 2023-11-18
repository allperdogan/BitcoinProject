using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitcoinsController : ControllerBase
    {
        IBitcoinValueService _bitcoinValueService;

        public BitcoinsController(IBitcoinValueService bitcoinValueService)
        {
            _bitcoinValueService = bitcoinValueService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bitcoinValueService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
