using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Departamento
    {
        public Departamento()
        {
            
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroEmpleados { get; set; }
        public string NivelOrganizacion { get; set; }
        public int IdEmpresa { get; set; } 

    }
}
