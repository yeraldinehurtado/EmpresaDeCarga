using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class TransportadoraController : Controller
    {
        private readonly ITransportadoraService _transportadoraService;

        public TransportadoraController(ITransportadoraService transportadoraService)
        {
            _transportadoraService = transportadoraService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexTransportadoras()
        {
            var listaTransportadora = await _transportadoraService.ObtenerTransportadoras();
            return View(await _transportadoraService.ObtenerTransportadoras());
        }

        [HttpGet]
        public IActionResult RegistrarTransportadoras()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarTransportadoras(Transportadora transportadora)
        {
            await _transportadoraService.GuardarTransportadora(transportadora);
            return RedirectToAction("IndexTransportadoras");
        }
    }
}
