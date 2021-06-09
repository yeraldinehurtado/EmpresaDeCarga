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
    public class EstadosService:IEstadosService
    {
        private readonly AppDbContext _context;
        public EstadosService(AppDbContext context)
        {
            _context = context;
                
        }
        public async Task<IEnumerable<Estado>> ObtenerEstados()
        {
            return await _context.estados.ToListAsync();
        }
    }
}
