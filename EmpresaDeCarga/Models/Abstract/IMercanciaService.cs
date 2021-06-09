using EmpresaDeCarga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Abstract
{
    public interface IMercanciaService
    {
        Task<IEnumerable<Mercancia>> ObtenerMercancia();
        Task GuardarMercancia(Mercancia mercancia);
        Task<Mercancia> ObtenerMercanciaId(int id);
        Task EditarMercancia(Mercancia mercancia);
        Task EliminarMercancia(int id);
    }
}
