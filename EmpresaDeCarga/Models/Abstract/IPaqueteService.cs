using EmpresaDeCarga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Abstract
{
    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> ObtenerPaquete();
        Task GuardarPaquete(Paquete paquete);
        Task<Paquete> ObtenerPaqueteId(int id);
        Task EditarPaquetes(Paquete paquete);
        Task EliminarPaquete(int id);
    }
}
