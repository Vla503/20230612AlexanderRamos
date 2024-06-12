using Core.Queries;
using Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idEmpresa}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Departamento>))]
        public async Task<IActionResult> GetDepartamentos(int idEmpresa)
        {
            List<Departamento> departamentos = await _mediator.Send(new GetDepartamentosByIdEmpresa(idEmpresa));
            return Ok(departamentos);
        }
    }
}
