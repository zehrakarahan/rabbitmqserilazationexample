using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherForecast.CommonData.Models;
using WeatherForecast.CommonData.RabbitQueue;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBus _busControl;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBus busControl)
        {
            _logger = logger;
            _busControl = busControl;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<WeatherForecastRequest> request)
        {
            if (request == null)
            {
                _logger.LogDebug("BadRequest - ConfigurationDto is null or empty");
                return BadRequest();
            }
            Order order = new Order();
            order.ID = 1;
            order.NAme = "deneme";
            order.Quantity = Convert.ToDecimal("5.4");
            await _busControl.SendAsync(Queue.Processing, request);
            await _busControl.SendAsync(Queue.Processing1, order);

            return Ok();
        }

    }
}
