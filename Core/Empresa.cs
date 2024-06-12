using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Empresa
    {
        public Empresa()
        {
        }
        [Required(ErrorMessage = "El campo ID es requerido.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Razón Social es requerido.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Registro es requerido.")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El campo Detalles de Log es requerido.")]
        public string LogDetails { get; set; }
    }
}
