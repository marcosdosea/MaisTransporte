using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service.Tests
{
    [TestClass()]
    public class SugestaovagemServiceTests
    {
        private MaisTransporteContext _context;
        private ISugestaoviagemService _sugestaoviagemService;

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
            var sugestoes = new List<Sugestaoviagem>
                {
                    new Sugestaoviagem { Id = 1, Titulo = "Fest Verão", LocalOrigem = "Itabaiana",
                               LocalDestino = "Aracaju", ValorPassagem = 30, TotalVagas = 15, DataPartida = DateTime.Parse("2023-08-01"),
                               DataChegada = DateTime.Parse("2023-08-02"), Descricao = "Viagem com segurança, conforto e preço baixo.",
                               Visibilidade = "Pública", IdPassageiro = 1}
                };

            _context.AddRange(sugestoes);
            _context.SaveChanges();

            _sugestaoviagemService = new SugestaoviagemService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _sugestaoviagemService.Create(new Sugestaoviagem()
            {
                Id = 2,
                Titulo = "Festa dos Caretas",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Ribeirópolis",
                ValorPassagem = 15,
                TotalVagas = 25,
                DataPartida = DateTime.Parse("2023-04-10"),
                DataChegada = DateTime.Parse("2023-04-10"),
                Descricao = "Viagem com segurança e conforto.",
                Visibilidade = "Pública",
                IdPassageiro = 2
            });
            //Assert
            Assert.AreEqual(2, _sugestaoviagemService.GetAll().Count());
            var sugestao = _sugestaoviagemService.Get(2);
            Assert.AreEqual("Festa dos Caretas", sugestao.Titulo);
            Assert.AreEqual("Itabaiana", sugestao.LocalOrigem);
            Assert.AreEqual("Ribeirópolis", sugestao.LocalDestino);
            Assert.AreEqual(15, sugestao.ValorPassagem);
            Assert.AreEqual(25, sugestao.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), sugestao.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), sugestao.DataChegada);
            Assert.AreEqual("Viagem com segurança e conforto.", sugestao.Descricao);
            Assert.AreEqual("Pública", sugestao.Visibilidade);
            Assert.AreEqual(2, sugestao.IdPassageiro);
        }

        [TestMethod()]
        public void GetTest()
        {
            var sugestao = _sugestaoviagemService.Get(1);
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
            var listaSugestao = _sugestaoviagemService.GetAll();
            //Assert
            Assert.IsInstanceOfType(listaSugestao, typeof(IEnumerable<Sugestaoviagem>));
            Assert.IsNotNull(listaSugestao);
            Assert.AreEqual(1, listaSugestao.Count());
            Assert.AreEqual(1, listaSugestao.First().Id);
            Assert.AreEqual("Aracaju", listaSugestao.First().LocalDestino);
        }

        [TestMethod()]
        public void GetByLocalDestino()
        {
            //Act
            var sugestoes = _sugestaoviagemService.GetByLocalDestino("Aracaju");
            //Assert
            Assert.IsNotNull(sugestoes);
            Assert.AreEqual(1, sugestoes.Count());
            Assert.AreEqual("Aracaju", sugestoes.First().LocalDestino);
        }
    }
}
