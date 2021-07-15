using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<Poetry> Contend = new List<Poetry>() 
        { 
            new Poetry { Contend = " 忠于自己，热爱生活"},
            new Poetry{Contend = "人生用特写镜头来看是悲剧，长镜头来看则是喜剧"},
            new Poetry {Contend ="愿你多看书，走很远的路，如果你见过大海，就不会在意池塘里的是非 "},
            new Poetry {Contend ="我虽然走得很慢，但我确信自己一直在路上"},
            new Poetry {Contend ="每一天都是上帝赐给我们的礼物"},
            new Poetry {Contend ="在我看来，知识密度大于你的人，愿意俯下身来尊重，引导你，这便是温柔~"},
            new Poetry {Contend ="努力，不是为了感动谁，也不是为了做给哪个人看，而是为了让自己随时有能力跳出自己厌恶的圈子，并有选择的权力。"},
            new Poetry {Contend ="记住，用自己喜欢的方式过一生"}
        };
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("contend")]
        public Poetry GetContend()
        {
            var random = new Random();
            int length = Contend.Count;
            int Index = random.Next(0, length-1);
            Poetry potry = Contend[Index];
            List<string> list = new List<string>();
            list.Add("时间花叶不相伦，花入金盆叶做尘");
            list.Add("毕竟西湖六月中，风光不与四时同");
            list.Add("接天莲叶无穷碧，映日荷花别样红");
            list.Add("纷纷红紫已成尘，布谷声中夏令生");
            list.Add("夹路桑麻行不尽，始知身是太平人");
            list.Add("泉眼无声惜细流，树阴照水爱晴柔");
            list.Add("小河才露尖尖角，早有蜻蜓立上头");
            return potry;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
