using Core.Commands;
using Core.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Commads
{
    public class AddUpdateEmpresaHandler : IRequestHandler<AddUpdateEmpresa>
    {
        private readonly IEmpresaRepo _empresaRepo;
        public AddUpdateEmpresaHandler(IEmpresaRepo empresaRepo)
        {
            _empresaRepo = empresaRepo;
        }
        public async Task<Unit> Handle(AddUpdateEmpresa request, CancellationToken cancellationToken)
        {
            await _empresaRepo.RegistrarUpdateEmpresaAsync(request.Empresa);
            return Unit.Value;
        }
    }
}
