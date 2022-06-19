using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PROJEKTU_SKRYPTU_EBAZA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Controllers
{
    public class HomeController : Controller
    {        
        //Wyświetlenie strony głównej
        public IActionResult Index()
        {
            return View();
        }
    
    }
}
