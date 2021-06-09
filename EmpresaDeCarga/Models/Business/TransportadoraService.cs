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
    public class TransportadoraService : ITransportadoraService
    {
        private readonly AppDbContext _context;
        public TransportadoraService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Transportadora>> ObtenerTransportadoras()
        {
            return await _context.transportadoras.ToListAsync();
        }

        public async Task GuardarTransportadora(Transportadora transportadora)
        {
            _context.Add(transportadora);
            await _context.SaveChangesAsync();
        }

        public async Task<Transportadora> ObtenerTransportadoraId(int id)
        {
            return await _context.transportadoras.FindAsync(id);
        }

        public async Task EditarTransportadoras(Transportadora transportadora)
        {
            _context.Update(transportadora);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarTransportadora(int id)
        {
            var transportadora = await ObtenerTransportadoraId(id);
            _context.Remove(transportadora);
            await _context.SaveChangesAsync();
        }

    }
}

