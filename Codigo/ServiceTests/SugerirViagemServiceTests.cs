using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class SugerirViagemServiceTests
    {
        private MaisTransporteContext _context;
        private ISugerirViagemService _sugerirViagemService;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            var builder = new DbContextOptionsBuilder<MaisTransporteContext>();
            builder.UseInMemoryDatabase("MaisTransporte");
            var options = builder.Options;

            _context = new MaisTransporteContext(options);
            // _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            var sugestoes = new List<Sugestaoviagem>
                {
                    new Sugestaoviagem { Id = 1, Titulo = "Fest Verão", LocalOrigem = "Itabaiana",
                               LocalDestino = "Aracaju", ValorPassagem = 30, TotalVagas = 15, DataPartida = DateTime.Parse("2023-08-01"),
                               DataChegada = DateTime.Parse("2023-08-02"), Descricao = "Viagem com segurança, conforto e com preço baixo.",
                               Visibilidade = "Pública", IdPassageiro = 1}
                };

            _context.AddRange(sugestoes);
            _context.SaveChanges();

            _sugerirViagemService = new SugerirViagemService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _sugerirViagemService.Create(new Sugestaoviagem()
            {
                Id = 3,
                Titulo = "Festa dos Caretas",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Ribeirópolis",
                ValorPassagem = 15,
                TotalVagas = 25,
                DataPartida = DateTime.Parse("2023-04-10"),
                DataChegada = DateTime.Parse("2023-04-10"),
                Descricao = "Viagem com segurança e conforto.",
                Visibilidade = "Pública",
                IdPassageiro = 1
            });
            //Assert
            Assert.AreEqual(3, _sugerirViagemService.GetAll().Count());
            var sugestao = _sugerirViagemService.Get(3);
            Assert.AreEqual("Festa dos Caretas", sugestao.Titulo);
            Assert.AreEqual("Itabaiana", sugestao.LocalOrigem);
            Assert.AreEqual("Ribeirópolis", sugestao.LocalDestino);
            Assert.AreEqual(15, sugestao.ValorPassagem);
            Assert.AreEqual(25, sugestao.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), sugestao.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), sugestao.DataChegada);
            Assert.AreEqual("Viagem com segurança e conforto.", sugestao.Descricao);
            Assert.AreEqual("Pública", sugestao.Visibilidade);
            Assert.AreEqual(1, sugestao.IdPassageiro);
        }

        [TestMethod()]
        public void GetTest()
        {
            var sugestao = _sugerirViagemService.Get(1);
            Assert.IsNotNull(sugestao);
            Assert.AreEqual("Fest Verão", sugestao.Titulo);
            Assert.AreEqual("Itabaiana", sugestao.LocalOrigem);
            Assert.AreEqual("Aracaju", sugestao.LocalDestino);
            Assert.AreEqual(30, sugestao.ValorPassagem);
            Assert.AreEqual(15, sugestao.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-08-01"), sugestao.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-08-02"), sugestao.DataChegada);
            Assert.AreEqual("Viagem com segurança, conforto e preço baixo.", sugestao.Descricao);
            Assert.AreEqual("Pública", sugestao.Visibilidade);
            Assert.AreEqual(1, sugestao.IdPassageiro);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            //Act
            var listaSugestao = _sugerirViagemService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaSugestao, typeof(IEnumerable<Sugestaoviagem>));
            Assert.IsNotNull(listaSugestao);
            Assert.AreEqual(3, listaSugestao.Count());
            Assert.AreEqual(1, listaSugestao.First().Id);
            Assert.AreEqual("Aracaju", listaSugestao.First().LocalDestino);
        }

        [TestMethod()]
        public void GetByLocalDestino()
        {
            //Act
            var sugestoes = _sugerirViagemService.GetByLocalDestino("Aracaju");
            //Assert
            Assert.IsNotNull(sugestoes);
            Assert.AreEqual(1, sugestoes.Count());
            Assert.AreEqual("Aracaju", sugestoes.First().LocalDestino);
        }
    }
}
