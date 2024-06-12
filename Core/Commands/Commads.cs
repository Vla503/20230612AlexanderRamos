using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Commands
{
    /// <summary>
    /// commando que sirve para agregar o modificar una empresa
    /// </summary>
    /// <param name="Empresa"></param>
    public record AddUpdateEmpresa(Empresa Empresa) : IRequest;
}
