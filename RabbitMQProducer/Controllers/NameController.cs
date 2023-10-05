using Microsoft.AspNetCore.Mvc;
using RabbitMQProducer.Services;

namespace RabbitMQProducer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : Controller
    {
        private readonly IRabbitMqService _rabbitMqService;

        public NameController(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }
        [HttpGet]
        public IActionResult Get(string name)
        {
            _rabbitMqService.SendNameToQueue(name);
            return Ok("Success");
        }

    }
}
