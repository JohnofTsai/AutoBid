using AutoBid.Calc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AutoBid.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesComputingController : ControllerBase
    {
        private readonly IBiddingFeesCalculator _calc;
        private readonly ILogger<FeesComputingController> _logger;

        public FeesComputingController(IBiddingFeesCalculator calc, ILogger<FeesComputingController> logger)
        {
            this._calc = calc;
            this._logger = logger;   
        }

        [HttpPost(Name = "ComputeBiddingFee")]
        public ActionResult<AutoBidFees> CalculatePriceDetails([FromBody] Vehicle vehicle)
        {
            if (vehicle != null)
            {
                var details =  _calc.CalcBiddingFees(vehicle);
                return Ok(details);
            }
            else
            {
                return BadRequest("Invalid request");
            }
        }
 
    }
}
