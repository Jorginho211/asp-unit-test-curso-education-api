using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTest
    {
        private GetCursoQuery.GetCursoQueryHandler _handlerAllCursos;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();
            cursoRecords.Add(
                fixture.Build<Curso>()
                    .With(tr => tr.CursoId, Guid.Empty)
                    .Create()
            );

            var options = new DbContextOptionsBuilder<EducationDbContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            _handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            // 1. Emular al Context que representa la entidad de ef.

            // 2. Emular al Mapping Profile

            // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandlers
            // Como parametros los objetos context y mapping
            // GetCursoQueryHandler(context, mapping) => handle

            GetCursoQuery.GetCursoQueryRequest request = new GetCursoQuery.GetCursoQueryRequest();
            var resultados = await _handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);
        }
    }
}
