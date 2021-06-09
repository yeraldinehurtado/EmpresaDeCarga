using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexClientes()
        {
            var listClientes = await _clienteService.ObtenerCliente();
            return View(await _clienteService.ObtenerCliente());
        }

        [HttpGet]
        public IActionResult RegistrarClientes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarClientes(Cliente cliente)
        {
            await _clienteService.GuardarCliente(cliente);
            TempData["Accion"] = "GuardarCliente";
            TempData["Mensaje"] = "Cliente guardado con éxito.";

            return RedirectToAction("IndexClientes");
        }

        [HttpGet]
        public async Task<IActionResult> EditarClientes(int id = 0)
        {
            return View(await _clienteService.ObtenerClienteId(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditarClientes(int? id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _clienteService.GuardarCliente(cliente);
                    return RedirectToAction("IndexClientes");
                }
                else
                {
                    if (id != cliente.CasilleroId)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexClientes");
                    }
                    try
                    {
                        await _clienteService.EditarClientes(cliente);
                        TempData["Accion"] = "EditarCliente";
                        TempData["Mensaje"] = "Cliente editado con éxito.";
                        return RedirectToAction("IndexClientes");
                    }
                    catch (Exception)
                    {
                        TempData["Accion"] = "Error";
                        TempData["Mensaje"] = "Hubo un error realizando la operación";
                        return RedirectToAction("IndexClientes");
                    }
                }
            }
            else
            {
                return View(cliente);
            }

        }

        public async Task<IActionResult> DetallesCliente(int? id)
        {
            if (id != null)
            {
                return View(await _clienteService.ObtenerClienteId(id.Value));
            }

            TempData["Accion"] = "Error";
            TempData["Mensaje"] = "Hubo un error realizando la operación";
            return RedirectToAction("IndexClientes");
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            try
            {
                TempData["Accion"] = "Confirmación";
                await _clienteService.EliminarCliente(id);
                return RedirectToAction(nameof(IndexClientes));
            }
            catch (Exception)
            {
                TempData["Accion"] = "Error";
                TempData["Mensaje"] = "Hubo un error realizando la operación";
                return RedirectToAction("IndexClientes");
            }

        }
    }
}