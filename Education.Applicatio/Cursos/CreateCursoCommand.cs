using AutoMapper;
using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;

namespace Education.Application.Cursos
{
    public class CreateCursoCommand
    {
        public class CreateCursoCommandRequest : IRequest
        {
            public Guid CursoId { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public decimal Precio { get; set; }
        }

        public class CreateCursoCommandRequestValidation: AbstractValidator<CreateCursoCommandRequest>
        {
            public CreateCursoCommandRequestValidation()
            {
                RuleFor(x => x.Descripcion);
                RuleFor(x => x.Titulo);
            }
        }

        public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly EducationDbContext _context;

            public CreateCursoCommandHandler(EducationDbContext context, IMapper mapper)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                var curso = new Curso
                {
                    CursoId = request.CursoId,
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                    Precio = request.Precio
                };

                _context.Add(curso);
                var valor = await _context.SaveChangesAsync();

                if (valor > 0)
                    return Unit.Value;

                throw new Exception("No se pudo insertar el curso");
            }
        }
    }
}
