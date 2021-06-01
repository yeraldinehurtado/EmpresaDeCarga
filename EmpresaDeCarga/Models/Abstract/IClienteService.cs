using EmpresaDeCarga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Abstract
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObtenerCliente();
        Task GuardarCliente(Cliente cliente);
        Task<Cliente> ObtenerClienteId(int id);
        Task EditarClientes(Cliente cliente);
        Task EliminarCliente(int id);
    }
}
