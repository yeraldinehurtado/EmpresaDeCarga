using EmpresaDeCarga.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Abstract
{
    public interface ITransportadoraService
    {
        Task<IEnumerable<Transportadora>> ObtenerTransportadoras();
        Task GuardarTransportadora(Transportadora transportadora);
        Task<Transportadora> ObtenerTransportadoraId(int id);
        Task EditarTransportadoras(Transportadora transportadora);
        Task EliminarTransportadora(int id);

    }
}
