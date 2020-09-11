using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace TowerDefense.Server
{
    public sealed class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> m_logger = default;

        public HomeController(ILogger<HomeController> logger)
        {
            m_logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("Hello world!");
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            string location = System.Reflection.Assembly.GetEntryAssembly()?.Location;
            string directory = Path.GetDirectoryName(location);
            string filePath = Path.Combine(directory, "GameConfiguration.json");
            string json = System.IO.File.ReadAllText(filePath);
            return Content(json);
        }
    }
}