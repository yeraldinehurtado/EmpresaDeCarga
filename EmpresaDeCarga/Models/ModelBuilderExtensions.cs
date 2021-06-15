using EmpresaDeCarga.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Estado>().HasData(
                new Estado
                {
                    EstadoId = 1,
                    Nombre = "En bodega Miami",
                },
                new Estado
                {
                    EstadoId = 2,
                    Nombre = "En tránsito a Colombia",
                },
                new Estado
                {
                    EstadoId = 3,
                    Nombre = "En bodega Colombia",
                },
                new Estado
                {
                    EstadoId = 4,
                    Nombre = "En tránsito a dirección del cliente",
                },
                new Estado
                {
                    EstadoId = 5,
                    Nombre = "Entregado",
                }


            );
        }
    }
}
