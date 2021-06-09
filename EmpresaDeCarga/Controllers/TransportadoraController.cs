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

        [HttpGet]
        public async Task<IActionResult> EditarTransportadoras(int id = 0)
        {
            return View(await _transportadoraService.ObtenerTransportadoraId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarTransportadoras(int? id, Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _transportadoraService.GuardarTransportadora(transportadora);
                    return RedirectToAction("IndexTransportadoras");
                }
                else
                {
                    if (id != transportadora.TransportadoraId)
                    {
                        return NotFound();
                    }
                    try
                    {
                        await _transportadoraService.EditarTransportadoras(transportadora);
                        return RedirectToAction("IndexTransportadoras");
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else
            {
                return View(transportadora);
            }

        }
        public async Task<IActionResult> EliminarTransportadora(int id)
        {
            try
            {
                await _transportadoraService.EliminarTransportadora(id);
                return RedirectToAction(nameof(IndexTransportadoras));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}
