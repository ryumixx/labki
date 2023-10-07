using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;
        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Вот информационное сообщение от нашего контроллеразначений.");
           
            _logger.LogDebug("Вот отладочное сообщение от нашего контроллеразначений.");
           
            _logger.LogWarn("Вот сообщение предупреждения от нашего контроллеразначений.");
           
            _logger.LogError("Вот сообщение об ошибке от нашего контроллеразначений.");
        return new string[] { "value1", "value2" };
        }
    }
}