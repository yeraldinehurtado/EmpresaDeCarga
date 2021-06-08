using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.Entities;
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

        [HttpGet]
        public IActionResult RegistrarPaquetes()
        {
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
        public async Task <IActionResult> EditarPaquetes(string? id)
        {
            if(id == null)
            {
                return RedirectToAction("IndexPaquetes");
            }

            var paquete = await _paqueteService.ObtenerPaquetePorId(id);

            if (paquete == null)
                return NotFound();

            return View(paquete);
        }
        [HttpPost]
        public async Task<IActionResult> EditarPaquetes(string? id,Paquete paquete)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _paqueteService.EditarPaquete(paquete);
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

        public async Task<IActionResult> DetallesPaquete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _paqueteService.ObtenerPaquetePorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPaquete(string id)
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
