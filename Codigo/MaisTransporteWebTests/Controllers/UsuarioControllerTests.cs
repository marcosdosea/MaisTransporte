using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaisTransporteWeb.Models;
using Moq;

namespace MaisTransporteWeb.Controllers.Tests
{
    [TestClass()]
    public class UsuarioControllerTests
    {
        private static UsuarioController controller;
        private IUsuarioService @object;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IUsuarioService>();

            IMapper mapper = new MapperConfiguration(cfg => 
               cfg.AddProfile(new UsuarioProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
               .Returns(GetTestUsuarios());
            mockService.Setup(service => service.Get(1))
               .Returns(GetTargetUsuario());
            mockService.Setup(service => service.Create(It.IsAny<Passageiro>()))
               .Verifiable();
            controller = new UsuarioController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<UsuarioViewModel>));

            List<UsuarioViewModel>? lista = (List<UsuarioViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(2, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(UsuarioViewModel));
            UsuarioViewModel usuarioViewModel = (UsuarioViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("juarezinho@gmail.com", usuarioViewModel.Email);
            Assert.AreEqual("79999865421", usuarioViewModel.Telefone);
            Assert.AreEqual("Juarez Salvatorio Vitorino", usuarioViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1980-08-01"), usuarioViewModel.DataNascimento);
            Assert.AreEqual("45888855547", usuarioViewModel.Cpf);

        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();

            // Assert 
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewUsuario());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Email", "Email é obrigatório.");

            // Act
            var result = controller.Create(GetNewUsuario());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(UsuarioViewModel));
            UsuarioViewModel usuarioViewModel = (UsuarioViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Juarez Salvatorio Vitorino", usuarioViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1980-08-01"), usuarioViewModel.DataNascimento);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetUsuarioViewModel().Id, GetTargetUsuarioViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(UsuarioViewModel));
            UsuarioViewModel usuarioViewModel = (UsuarioViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Juarez Salvatorio Vitorino", usuarioViewModel.Nome);
            Assert.AreEqual(DateTime.Parse("1980-08-01"), usuarioViewModel.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetUsuarioViewModel().Id, GetTargetUsuarioViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private UsuarioViewModel GetNewUsuario()
        {
            return new UsuarioViewModel
            {
                Email = "edantas241@gmail.com",
                Telefone = "79999131145",
                Nome = "Eliane Dantas",
                DataNascimento = DateTime.Parse("1980-08-01"),
                Cpf = "55566611189"
            };
        }

        private Passageiro GetTargetUsuario()
        {
            return new Passageiro
            {            
                Email = "juarezinho@gmail.com",
                Telefone = "79999865421",
                Nome = "Juarez Salvatorio Vitorino",
                DataNascimento = DateTime.Parse("1980-08-01"),
                Cpf = "45888855547"
            };
        }

        private UsuarioViewModel GetTargetUsuarioViewModel()
        {
            return new UsuarioViewModel
            {
                Email = "liondantas241@gmail.com",
                Telefone = "79999131147",
                Nome = "Lion Dantas",
                DataNascimento = DateTime.Parse("2016-12-01"),
                Cpf = "55566611191"
            };
        }

        private IEnumerable<Passageiro> GetTestUsuarios()
        {
            return new List<Passageiro>
            {
                new Passageiro
                {
                    Email = "edantas241@gmail.com",
                    Telefone = "79999131145",
                    Nome = "Eliane Dantas",
                    DataNascimento = DateTime.Parse("1980-08-01"),
                    Cpf = "55566611189"
                },
                new Passageiro
                {
                    Email = "liondantas241@gmail.com",
                    Telefone = "79999131147",
                    Nome = "Lion Dantas",
                    DataNascimento = DateTime.Parse("2016-12-01"),
                    Cpf = "55566611191"
                },
            };
        }
    }
}