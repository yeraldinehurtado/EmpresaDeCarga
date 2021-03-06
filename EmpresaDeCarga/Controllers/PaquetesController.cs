using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteService _paqueteService;
        private readonly ITransportadoraService _transportadoraService;
        private readonly IEstadosService _estadosService;
        private readonly IMercanciaService _mercanciaService;
        private readonly IClienteService _clienteService;

        public PaquetesController(IPaqueteService paqueteService, ITransportadoraService transportadoraService, IEstadosService estadosService, IMercanciaService mercanciaService, IClienteService clienteService)
        {
            _paqueteService = paqueteService;
            _transportadoraService = transportadoraService;
            _estadosService = estadosService;
            _mercanciaService = mercanciaService;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task <IActionResult> IndexPaquetes()
        {
            var listaPaquetes = await _paqueteService.ObtenerPaquete();
            return View(await _paqueteService.ObtenerPaquete());
        }

        [HttpGet]
        public async Task<IActionResult> RegistrarPaquetes()
        {
            ViewData["ListaTransportadora"] = new SelectList(await _transportadoraService.ObtenerTransportadoras(), "TransportadoraId", "Nombre");
            ViewData["ListaEstados"] = new SelectList(await _estadosService.ObtenerEstados(), "EstadoId", "Nombre");
            ViewData["ListaMercancias"] = new SelectList(await _mercanciaService.ObtenerMercancia(), "MercanciaId", "TipoMercancia");
            ViewData["ListaClientes"] = new SelectList(await _clienteService.ObtenerCliente(), "CasilleroId", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> RegistrarPaquetes(Paquete paquete)
        {
            
            if (ModelState.IsValid) 
            {
                try
                {
                    await _paqueteService.GuardarPaquete(paquete);
                    return RedirectToAction("IndexPaquetes");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(paquete);
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> EditarPaquetes(int? id)
        {
            ViewData["ListaTransportadora"] = new SelectList(await _transportadoraService.ObtenerTransportadoras(), "TransportadoraId", "Nombre");
            ViewData["ListaEstados"] = new SelectList(await _estadosService.ObtenerEstados(), "EstadoId", "Nombre");
            ViewData["ListaMercancias"] = new SelectList(await _mercanciaService.ObtenerMercancia(), "MercanciaId", "TipoMercancia");
            ViewData["ListaClientes"] = new SelectList(await _clienteService.ObtenerCliente(), "CasilleroId", "Nombre");
            if (id == null)
            {
                return RedirectToAction("IndexPaquetes");
            }

            var paquete = await _paqueteService.ObtenerPaqueteId(id.Value);

            if (paquete == null)
                return NotFound();

            return View(paquete);
        }
        [HttpPost]
        public async Task<IActionResult> EditarPaquetes(int? id, Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _paqueteService.EditarPaquetes(paquete);
                    return RedirectToAction("IndexPaquetes");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return View(paquete);
            }

        }

        public async Task<IActionResult> DetallesPaquete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _paqueteService.ObtenerPaqueteId(id.Value));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPaquete(int id)
        {
            try
            {
                await _paqueteService.EliminarPaquete(id);
                return RedirectToAction(nameof(IndexPaquetes));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

    }
}
