using AutoFixture;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTest
    {
        private CreateCursoCommand.CreateCursoCommandHandler _handlerCreateCurso;

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

            _handlerCreateCurso = new CreateCursoCommand.CreateCursoCommandHandler(educationDbContextFake);
        }

        [Test]
        public async Task CreateCursoCommandHandler_InputCurso_ReturnsInt()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new CreateCursoCommand.CreateCursoCommandRequest
            {
                CursoId = Guid.NewGuid(),
                FechaPublicacion = DateTime.UtcNow.AddDays(59),
                Descripcion = "Aprende a crear unit test desde cero",
                Titulo = "Libro de Pruebas automaticas en NET",
                Precio = 50
            };

            var resultado = await _handlerCreateCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resultado, Is.EqualTo(Unit.Value));
        }
    }
}
