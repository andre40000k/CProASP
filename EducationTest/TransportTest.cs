using CProASP.Interfaces.RepositoryInterface;
using CProASP.MiniDateBase.EFCore;
using CProASP.Repository;
using CProASP.Services.RegisterObjects;
using CProASP.Transport.Cargo;
using CProASP.Transport.Transport;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.CodeCoverage;
using Moq;

namespace EducationTest
{
    public class TransportTest
    {
        [Fact]
        public void AddTransportToRepository_Success()
        {
            //var option = new DbContextOptions();
            //var context = new ApplicationContext(option);
            var repository = new Mock<ITransportRepository>();
            BaseTransport savedTransport = null;
            repository.Setup(x => x.AddTransport(It.IsAny<BaseTransport>()))
                .Callback((BaseTransport baseTransport) => savedTransport = baseTransport);

            var service = new TransportService(repository.Object);
            var transport = new BaseTransport
            {
                Type = "transportTest",
                Speed = 0,
                Weight = 0,
                Status = "swim",
                Cargos = new List<CharacteristicCargo>
                { 
                    new CharacteristicCargo
                    {
                        Name = "âìöèö³ö³èâì",
                        Weight= 0
                    }
                }
            };

            service.AddTransport(transport);

            repository.Verify(transportRep => transportRep.AddTransport(It.IsAny<BaseTransport>()),
                Times.Once());

            Assert.Same(savedTransport, transport);
 
        }

        [Fact]
        public void GetTransport_Success()
        {
            var transport = new BaseTransport
            {
                Type = "transportTest",
                Speed = 0,
                Weight = 0,
                Status = "swim",
                Cargos = new List<CharacteristicCargo>
                {
                    new CharacteristicCargo
                    {
                        Name = "âìöèö³ö³èâì",
                        Weight= 0
                    }
                }
            };

            var repository = new Mock<ITransportRepository>();

            repository.Setup(x => x.GetTranspoert(It.IsAny<int>()))
                .Returns(transport);

            var service = new TransportService(repository.Object);
            

            var transportBase = service.GetTranspoert(transport.Id);

            repository.Verify(transportRep => transportRep.GetTranspoert(It.IsAny<int>()),
                Times.Once());

            transportBase.Should().BeEquivalentTo(transport);

        }
    }
}