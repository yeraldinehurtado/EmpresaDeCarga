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
    public class MercanciaService : IMercanciaService
    {
        private readonly AppDbContext _context;
        public MercanciaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mercancia>> ObtenerMercancia()
        {
            return await _context.mercancias.ToListAsync();
        }
        public async Task GuardarMercancia(Mercancia mercancia)
        {
            _context.Add(mercancia);
            await _context.SaveChangesAsync();
        }
        public async Task<Mercancia> ObtenerMercanciaId(int id)
        {
            return await _context.mercancias.FirstOrDefaultAsync(x => x.MercanciaId == id);
        }
        public async Task EditarMercancia(Mercancia mercancia)
        {
            _context.Update(mercancia);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarMercancia(int id)
        {
            var mercancia = await ObtenerMercanciaId(id);
            _context.Remove(mercancia);
            await _context.SaveChangesAsync();
        }
    }
}
