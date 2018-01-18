using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigAcess.Models;
using Microsoft.Extensions.Configuration;

namespace ConfigAcess.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration _configuration;

        public HomeController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IActionResult Index()
        {
            // Obtendo via Key
            ViewData["SectionConfig1"] = _configuration["Section:Config1"];

            // Obtendo via método GetSection 
            ViewData["SectionConfig2"] = _configuration.GetSection("Section").GetSection("Config2").GetSection("Subconfig1").Value;

            //Obtendo via médoto GetSection e via Key de forma mixada
            ViewData["SectionConfig3"] = _configuration.GetSection("Section")["Config2:Subconfig2"];

            return View();
        }
    }

}
