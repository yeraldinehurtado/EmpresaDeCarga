using EmpresaDeCarga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Abstract
{
    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> ObtenerPaquetes();
    }
}
