using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace TestAPIController.Controllers;
[Route("automatapi/v1/")]
[ApiController]
public class AutomatAPIController : ControllerBase
{
    [HttpGet("sendMessage")]
    public async Task<IActionResult> SendMessage()
    {
        try
        {
            var HostName = Environment.GetEnvironmentVariable("RABBITMQHOST");
            var UserName = Environment.GetEnvironmentVariable("RABBITUSERNAME");
            var Password = Environment.GetEnvironmentVariable("RABBITPASSWORD");
            Console.WriteLine(HostName);
            Console.WriteLine(UserName);
            var factory = new ConnectionFactory() { 
                    HostName = HostName,
                    UserName = UserName,
                    Password = Password
            };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                    routingKey: "hello",
                                    basicProperties: null,
                                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
            return Ok("Message was published");    
        }
        catch (System.Exception e)
        {
            return Ok(e.Message);
        }
        
    }
}