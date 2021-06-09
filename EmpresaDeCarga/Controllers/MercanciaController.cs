using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class MercanciaController : Controller
    {
        private readonly IMercanciaService _mercanciaService;
        public MercanciaController(IMercanciaService mercanciaService)
        {
            _mercanciaService = mercanciaService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexMercancia()
        {
            var listMercancia = await _mercanciaService.ObtenerMercancia();
            return View(await _mercanciaService.ObtenerMercancia());
        }

        [HttpGet]
        public IActionResult RegistrarMercancia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarMercancia(Mercancia mercancia)
        {
            await _mercanciaService.GuardarMercancia(mercancia);
            TempData["Accion"] = "GuardarMercancia";
            TempData["Mensaje"] = "Mercancia guardada con éxito.";

            return RedirectToAction("IndexMercancia");
        }

        [HttpGet]
        public async Task<IActionResult> EditarMercancia(int id = 0)
        {
            return View(await _mercanciaService.ObtenerMercanciaId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarMercancia(int? id, Mercancia mercancia)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _mercanciaService.GuardarMercancia(mercancia);
                    return RedirectToAction("IndexMercancia");
                }
                else
                {
                    if (id != mercancia.MercanciaId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexMercancia");
                    }
                    try
                    {
                        await _mercanciaService.EditarMercancia(mercancia);
                        TempData["Accion"] = "EditarMercancia";
                        TempData["Mensaje"] = "Mercancia editada con éxito.";
                        return RedirectToAction("IndexMercancia");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexMercancia");
                    }
                }
            }
            else
            {
                return View(mercancia);
            }
        }

        public async Task<IActionResult> DetallesMercancia(int? id)
        {
            if (id != null)
            {
                return View(await _mercanciaService.ObtenerMercanciaId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexMercancia");

        }

        [HttpPost]
        public async Task<IActionResult> EliminarMercancia(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _mercanciaService.EliminarMercancia(id);
                return RedirectToAction(nameof(IndexMercancia));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexMercancia");
            }

        }


    
    }
}
