using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int CasilleroId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Column("NombreCliente", TypeName = "nvarchar(100)")]
        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string DireccionEntrega { get; set; }
    }
}
