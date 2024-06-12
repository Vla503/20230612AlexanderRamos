using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IDepartamentoRepo
    {
        /// <summary>
        /// extrae una lista de departamentos por su id de empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        Task<List<Departamento>> GetDepartamentosByIdEmpresa(int idEmpresa);
    }
}
