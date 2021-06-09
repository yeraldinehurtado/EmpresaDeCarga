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

        public async Task<IEnumerable<Paquete>> ObtenerPaquete()
        {
            return await _context.paquetes.ToListAsync();
        }

        public async Task GuardarPaquete(Paquete paquete)
        {
            _context.Add(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task<Paquete> ObtenerPaqueteId(int id)
        {
            return await _context.paquetes.FindAsync(id);
        }

        public async Task EditarPaquetes(Paquete paquete)
        {
            _context.Update(paquete);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarPaquete(int id)
        {
            var paquete = await ObtenerPaqueteId(id);
            _context.Remove(paquete);
            await _context.SaveChangesAsync();
        }
    }
}
