using Core;
using Core.Data;
using Core.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Queries
{
    public class GetEmpresaHandler : IRequestHandler<GetEmpresa, Empresa>
    {
        private readonly IEmpresaRepo _empresaRepo;
        public GetEmpresaHandler(IEmpresaRepo empresaRepo)
        {
            _empresaRepo = empresaRepo;
        }
        public async Task<Empresa> Handle(GetEmpresa request, CancellationToken cancellationToken)
        {
            return await _empresaRepo.GetEmpresaAsync(request.Id);
        }
    }
}
