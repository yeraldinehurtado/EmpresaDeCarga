using EmpresaDeCarga.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

        [HttpGet]
        public async Task <IActionResult> IndexPaquetes()
        {
            var listaPaquetes = await _paqueteService.ObtenerPaquetes();
            return View(await _paqueteService.ObtenerPaquetes());
        }
    }
}
