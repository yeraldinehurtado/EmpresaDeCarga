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
    public class PaqueteService: IPaqueteService
    {
        private readonly AppDbContext _context;
        public PaqueteService(AppDbContext context)
        {
            _context = context;         
        }

        public async Task <IEnumerable<Paquete>> ObtenerPaquetes()
        {
            return await _context.paquetes.ToListAsync();
        }
    }
}
