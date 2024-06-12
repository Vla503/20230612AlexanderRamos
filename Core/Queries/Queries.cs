using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    /// <summary>
    /// querie para poder extraer una empresa
    /// </summary>
    /// <param name="Id"></param>
    public record GetEmpresa(int Id) : IRequest<Empresa>;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IdEmpresa"></param>
    public record GetDepartamentosByIdEmpresa(int IdEmpresa):IRequest<List<Departamento>>;
}
