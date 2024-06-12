using Core.Data;
using Core.Queries;
using Core;
using Handlers.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestFixture]
    public class DepartamentoTest
    {
        [Test]
        public async Task Handle_WhenDepartamentosExist_ReturnsListOfDepartamentos()
        {
            // Arrange
            int idEmpresa = 1;
            var mockDepartamentoRepo = new Mock<IDepartamentoRepo>();
            mockDepartamentoRepo.Setup(repo => repo.GetDepartamentosByIdEmpresa(idEmpresa))
                                .ReturnsAsync(new List<Departamento>
                                {
                                new Departamento { Id = 1, Nombre = "Departamento 1", NivelOrganizacion = "nivel 1", IdEmpresa = 1, NumeroEmpleados = 10 },
                                new Departamento { Id = 2, Nombre = "Departamento 2", NivelOrganizacion = "nivel 2", IdEmpresa = 1, NumeroEmpleados = 50 }
                                });
            var handler = new GetDepartamentosByIdEmpresaHandler(mockDepartamentoRepo.Object);

            // Act
            var result = await handler.Handle(new GetDepartamentosByIdEmpresa(idEmpresa), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Departamento>>(result);
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public async Task Handle_WhenNoDepartamentosExist_ReturnsEmptyList()
        {
            // Arrange
            int idEmpresa = 2;
            var mockDepartamentoRepo = new Mock<IDepartamentoRepo>();
            mockDepartamentoRepo.Setup(repo => repo.GetDepartamentosByIdEmpresa(idEmpresa))
                                .ReturnsAsync(new List<Departamento>());
            var handler = new GetDepartamentosByIdEmpresaHandler(mockDepartamentoRepo.Object);

            // Act
            var result = await handler.Handle(new GetDepartamentosByIdEmpresa(idEmpresa), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Departamento>>(result);
            Assert.IsEmpty(result);
        }
    }
}
