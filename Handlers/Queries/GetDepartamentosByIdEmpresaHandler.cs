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
    public class GetDepartamentosByIdEmpresaHandler : IRequestHandler<GetDepartamentosByIdEmpresa, List<Departamento>>
    {
        private readonly IDepartamentoRepo _departamentoRepo;
        public GetDepartamentosByIdEmpresaHandler(IDepartamentoRepo departamentoRepo)
        {
            _departamentoRepo = departamentoRepo;
        }
        public async Task<List<Departamento>> Handle(GetDepartamentosByIdEmpresa request, CancellationToken cancellationToken)
        {
            return await _departamentoRepo.GetDepartamentosByIdEmpresa(request.IdEmpresa);
        }
    }
}
