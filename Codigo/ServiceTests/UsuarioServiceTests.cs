using Core.Service;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace Service.Tests
{
    [TestClass()]
    public class UsuarioServiceTests
    {
        private MaisTransporteContext _context;
        private IUsuarioService? _usuarioService;

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
            var passageiro = new List<Passageiro>
                {
                    new Passageiro { Id = 1, Email = "edantas241@gmail.com", Telefone = "79999131145", Nome = "Eliane Dantas",
                    DataNascimento = DateTime.Parse("1980-08-01"), Cpf = "55566611189" },
                    new Passageiro { Id = 3, Email = "e241@gmail.com", Telefone = "79945131145", Nome = "Maria Dantas",
                    DataNascimento = DateTime.Parse("1984-01-03"), Cpf = "45766611189" },
                };

            _context.AddRange(passageiro);
            _context.SaveChanges();

            _usuarioService = new UsuarioService(_context);
        }

        [TestMethod()]
        public void CreateTest()
        {
            //Act
            _usuarioService.Create(new Passageiro()
            {
                Id = 2,
                Email = "liondantas241@gmail.com",
                Telefone = "79999131147",
                Nome = "Lion Dantas",
                DataNascimento = DateTime.Parse("2016-12-01"),
                Cpf = "55566611191"
            });
            //Assert
            Assert.AreEqual(3, _usuarioService.GetAll().Count());
            var usuario = _usuarioService.Get(2);
            Assert.AreEqual("liondantas241@gmail.com", usuario.Email);
            Assert.AreEqual("79999131147", usuario.Telefone);
            Assert.AreEqual("Lion Dantas", usuario.Nome);
            Assert.AreEqual(DateTime.Parse("2016-12-01"), usuario.DataNascimento);
            Assert.AreEqual("55566611191", usuario.Cpf);
        }

        [TestMethod()]
        public void DeleteTest()
        {   
            // Act
            _usuarioService.Delete(1);
            // Assert
            Assert.AreEqual(1, _usuarioService.GetAll().Count());
            var usuario = _usuarioService.Get(1);
            Assert.AreEqual(null, usuario);
        }

        [TestMethod()]
        public void EditTest()
        {
            //Act 
            var usuario = _usuarioService.Get(1);
            usuario.Nome = "Joaninha Coelho";
            usuario.DataNascimento = DateTime.Parse("1912-11-26");
            _usuarioService.Edit(usuario);
            //Assert
            usuario = _usuarioService.Get(1);
            Assert.IsNotNull(usuario);
            Assert.AreEqual("Joaninha Coelho", usuario.Nome);
            Assert.AreEqual(DateTime.Parse("1912-11-26"), usuario.DataNascimento);
        }


        [TestMethod()]
        public void GetTest()
        {
            var usuario = _usuarioService.Get(1);
            Assert.IsNotNull(usuario);
            Assert.AreEqual("edantas241@gmail.com", usuario.Email);
            Assert.AreEqual("79999131145", usuario.Telefone);
            Assert.AreEqual("Eliane Dantas", usuario.Nome);
            Assert.AreEqual(DateTime.Parse("1980-08-01"), usuario.DataNascimento);
            Assert.AreEqual("55566611189", usuario.Cpf);
        }
    }
}