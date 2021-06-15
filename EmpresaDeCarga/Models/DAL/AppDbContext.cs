using EmpresaDeCarga.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)      
        {
            base.OnModelCreating(modelBuilder); //esto se ejecuta al momento que se está creando la base de datos
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Paquete> paquetes { get; set; }
        public DbSet<Transportadora> transportadoras { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Mercancia> mercancias { get; set; }
    }
}
