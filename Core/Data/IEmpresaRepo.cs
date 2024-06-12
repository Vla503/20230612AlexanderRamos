using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IEmpresaRepo
    {
        /// <summary>
        /// metodo para extraer una empresa por su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Empresa> GetEmpresaAsync(int Id);
        /// <summary>
        /// agrego o modifica una empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        Task RegistrarUpdateEmpresaAsync(Empresa empresa);
    }
}
