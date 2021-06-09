using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Entities
{
    public class Paquete
    {
        [Key]
        public int PaqueteId { get; set; }
        [Required(ErrorMessage = "El código es requerido.")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El peso es requerido.")]
        public double PesoLibras { get; set; }
        [Required(ErrorMessage = "El número de casillero es requerido.")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "El estado es requerido.")]
        public int EstadoId { get; set; }
        [Required(ErrorMessage = "El número de guía es requerido.")]
        public int NoGuiaUsa { get; set; }
        [Required(ErrorMessage = "La empresa es requerida.")]
        public int EmpresaUsa { get; set; }
        [Required(ErrorMessage = "El tipo de mercancia es requerida.")]
        public string TipoMercancia { get; set; }
        [Required(ErrorMessage = "El número de guía es requerido.")]
        public int NoGuiaCol { get; set; }
        [Required(ErrorMessage = "La empresa es requerida.")]
        public int EmpresaCol { get; set; }
        
        public double ValorPago { get; set; }
        
    }
}
