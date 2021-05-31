using EmpresaDeCarga.Models.Abstract;
using EmpresaDeCarga.Models.DAL;
using EmpresaDeCarga.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Business
{
    public class ClienteService: IClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObtenerCliente()
        {
            return await _context.clientes.ToListAsync();
        }

        public async Task GuardarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
