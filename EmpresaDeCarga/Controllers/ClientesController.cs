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
        public async Task<IActionResult> Index()
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
            return RedirectToAction("IndexClientes");
        }

        [HttpGet]
        public IActionResult EditarClientes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditarClientes(Cliente cliente)
        {
            await _clienteService.GuardarCliente(cliente);
            return RedirectToAction("IndexClientes");
        }
    }
}
