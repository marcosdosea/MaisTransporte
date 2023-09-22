using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace ServiceTests
{
    [TestClass]
    public class VeiculoServiceTests
    {
        private MaisTransporteContext _context;
        private IVeiculoService _veiculoService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<MaisTransporteContext>();
            builder.UseInMemoryDatabase("ModeloMaisTransporte");
            var options = builder.Options;

            _context = new MaisTransporteContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var sugestoes = new List<Veiculo>
                {
                    new Veiculo {
                        Id = 5,
                        Renavam = "123235212",
                        Placa = "OHD-2929",
                        DataEmissao = DateTime.Parse("2023-04-10"),
                        Expedidor = "SSP",
                        Estado = "SE",
                        IdMotoristaPassageiro = 1,
                    }
                };

            _context.AddRange(sugestoes);
            _context.SaveChanges();

            _veiculoService = new VeiculoService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _veiculoService.Create(new Veiculo()
            {
                Id = 9,
                Renavam = "123235212",
                Placa = "OHD-2929",
                DataEmissao = DateTime.Parse("2023-04-10"),
                Expedidor = "SSP",
                Estado = "SE",
                IdMotoristaPassageiro = 1,
            });
                //Assert
                Assert.AreEqual(2, _veiculoService.GetAll().Count());
                var veiculo = _veiculoService.Get(2);
                Assert.AreEqual("Renavam", veiculo.Renavam);
                Assert.AreEqual("Placa", veiculo.Placa);
                Assert.AreEqual(DateTime.Parse("2022-08-02"), veiculo.DataEmissao);
                Assert.AreEqual("Órgão Expedidor", veiculo.Expedidor);
                Assert.AreEqual("Estado", veiculo.Estado);
                Assert.AreEqual(1, veiculo.IdMotoristaPassageiro);

        }
        [TestMethod()]
        public void EditTest()
        {
            var veiculo = _veiculoService.Get(1);
            veiculo.Renavam = "92988383838";
            veiculo.Placa = "UHD-9099";
            veiculo.DataEmissao = DateTime.Parse("2023-04-10");
            veiculo.Expedidor = "SSP";
            veiculo.Estado = "SE";
            veiculo.IdMotoristaPassageiro = 1;
            _veiculoService.Edit(veiculo);
            //Assert
            veiculo = _veiculoService.Get(1);
            Assert.IsNotNull(veiculo);
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Renavam", veiculo.Renavam);
            Assert.AreEqual("Placa", veiculo.Placa);
            Assert.AreEqual(DateTime.Parse("2022-08-02"), veiculo.DataEmissao);
            Assert.AreEqual("Órgão Expedidor", veiculo.Expedidor);
            Assert.AreEqual("Estado", veiculo.Estado);
            Assert.AreEqual(1, veiculo.IdMotoristaPassageiro);
        }
        public void GetTest()
        {
            var veiculo = _veiculoService.Get(1);
            Assert.IsNotNull(veiculo);
            Assert.AreEqual("Renavam", veiculo.Renavam);
            Assert.AreEqual("Placa", veiculo.Placa);
            Assert.AreEqual(DateTime.Parse("2022-08-02"), veiculo.DataEmissao);
            Assert.AreEqual("Órgão Expedidor", veiculo.Expedidor);
            Assert.AreEqual("Estado", veiculo.Estado);
            Assert.AreEqual(1, veiculo.IdMotoristaPassageiro);
        }
    }
}
