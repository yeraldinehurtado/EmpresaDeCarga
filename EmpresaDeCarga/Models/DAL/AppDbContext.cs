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
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Paquete> paquetes { get; set; }
        public DbSet<Transportadora> transportadoras { get; set; }
        public DbSet<Estado> estados { get; set; }
    }
}
