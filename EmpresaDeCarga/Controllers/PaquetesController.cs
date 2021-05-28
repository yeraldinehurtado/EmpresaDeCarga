using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class PaquetesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
