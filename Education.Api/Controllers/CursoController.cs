using Education.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Education.Application.Cursos.CreateCursoCommand;
using static Education.Application.Cursos.GetCursoQuery;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            return await _mediator.Send(new GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] CreateCursoCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
