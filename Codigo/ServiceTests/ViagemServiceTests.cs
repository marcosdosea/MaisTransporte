using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class ViagemServiceTests
    {
        private MaisTransporteContext _context;
        private IViagemService _viagemService;

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
            var viagens = new List<Viagem>
                {
                    new Viagem { Id = 1, Titulo = "Fest Verão 2023.1", LocalOrigem = "Itabaiana",
                               LocalDestino = "Aracaju", ValorPassagem = 25, TotalVagas = 20, DataPartida = DateTime.Parse("2023-10-15"),
                               DataChegada = DateTime.Parse("2023-10-18"), Descricao = "Conforto e segurança em um só lugar!",
                               IdMotorista = 1},
                    new Viagem { Id = 2, Titulo = "Fest Verão 2023.2", LocalOrigem = "Itabaiana",
                               LocalDestino = "Aracaju", ValorPassagem = 25, TotalVagas = 20, DataPartida = DateTime.Parse("2023-12-05"),
                               DataChegada = DateTime.Parse("2023-12-10"), Descricao = "Conforto e segurança em um só lugar!",
                               IdMotorista = 1},
                };

            _context.AddRange(viagens);
            _context.SaveChanges();

            _viagemService = new ViagemService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _viagemService.Create(new Viagem()
            {
                Id = 3,
                Titulo = "Micarana",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Ribeirópolis",
                ValorPassagem = 12,
                TotalVagas = 18,
                DataPartida = DateTime.Parse("2023-09-17"),
                DataChegada = DateTime.Parse("2023-09-19"),
                Descricao = "Se você não for, só você não vai!",
                IdMotorista = 2
            });
            //Assert
            Assert.AreEqual(3, _viagemService.GetAll().Count());
            var viagem = _viagemService.Get(3);
            Assert.AreEqual("Micarana", viagem.Titulo);
            Assert.AreEqual("Itabaiana", viagem.LocalOrigem);
            Assert.AreEqual("Ribeirópolis", viagem.LocalDestino);
            Assert.AreEqual(12, viagem.ValorPassagem);
            Assert.AreEqual(18, viagem.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-09-17"), viagem.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-09-19"), viagem.DataChegada);
            Assert.AreEqual("Se você não for, só você não vai!", viagem.Descricao);
            Assert.AreEqual(2, viagem.IdMotorista);
        }

        [TestMethod()]
        public void GetTest()
        {
            var viagem = _viagemService.Get(1);
            Assert.IsNotNull(viagem);
            Assert.AreEqual("Fest Verão 2023.1", viagem.Titulo);
            Assert.AreEqual("Itabaiana", viagem.LocalOrigem);
            Assert.AreEqual("Aracaju", viagem.LocalDestino);
            Assert.AreEqual(25, viagem.ValorPassagem);
            Assert.AreEqual(20, viagem.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-10-15"), viagem.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-10-18"), viagem.DataChegada);
            Assert.AreEqual("Conforto e segurança em um só lugar!", viagem.Descricao);
            Assert.AreEqual(1, viagem.IdMotorista);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaViagem = _viagemService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaViagem, typeof(IEnumerable<Viagem>));
            Assert.IsNotNull(listaViagem);
            Assert.AreEqual(2, listaViagem.Count());
            Assert.AreEqual(1, listaViagem.First().Id);
            Assert.AreEqual("Aracaju", listaViagem.First().LocalDestino);
        }

        [TestMethod()]
        public void GetByLocalDestino()
        {
            //Act
            var viagens = _viagemService.GetByLocalDestino("Aracaju");
            //Assert
            Assert.IsNotNull(viagens);
            Assert.AreEqual(2, viagens.Count());
            Assert.AreEqual("Aracaju", viagens.First().LocalDestino);
        }
    }
}
