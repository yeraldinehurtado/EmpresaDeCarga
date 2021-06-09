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

        public async Task GuardarPaquete(Paquete paquete)
        {
            _context.Add(paquete);
            await _context.SaveChangesAsync();
        }
        public async Task EditarPaquete(Paquete paquete)
        {
            _context.Update(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task<Paquete> ObtenerPaquetePorId(string id)
        {
            return await _context.paquetes.FindAsync(id);
        }
        public async Task EliminarPaquete(string id)
        {
            var paquete = await ObtenerPaquetePorId(id);
            _context.Remove(paquete);
            await _context.SaveChangesAsync();
        }
    }
}
