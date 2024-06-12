using Core;
using Core.Data;
using Core.Queries;
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
    public class EmpresaTest
    {
        [Test]
        public async Task Handle_ReturnsEmpresa_WhenEmpresaExists()
        {
            // Arrange
            var empresaRepoMock = new Mock<IEmpresaRepo>();
            empresaRepoMock.Setup(repo => repo.GetEmpresaAsync(It.IsAny<int>()))
                           .ReturnsAsync(new Empresa { ID = 1, Nombre = "Empresa1", RazonSocial = "Razón Social 1", FechaRegistro = DateTime.Now, LogDetails = "Detalles de log 1" });

            var handler = new GetEmpresaHandler(empresaRepoMock.Object);
            var request = new GetEmpresa(1);

            Empresa result = await handler.Handle(request, CancellationToken.None);

            Assert.NotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [Test]
        public async Task Handle_ReturnsNull_WhenEmpresaDoesNotExist()
        {
            // Arrange
            var empresaRepoMock = new Mock<IEmpresaRepo>();
            empresaRepoMock.Setup(repo => repo.GetEmpresaAsync(It.IsAny<int>()))
                           .ReturnsAsync((Empresa)null);

            var handler = new GetEmpresaHandler(empresaRepoMock.Object);
            var request = new GetEmpresa(1);

            Empresa result = await handler.Handle(request, CancellationToken.None);
            Assert.Null(result);
        }
    }
}
