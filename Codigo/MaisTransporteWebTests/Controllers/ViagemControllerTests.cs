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
    [TestClass]
    public class ViagemControllerTest
    {
        private static ViagemController controller;
        private IViagemService @object;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IViagemService>();

            IMapper mapper = new MapperConfiguration(cfg =>
               cfg.AddProfile(new ViagemProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
               .Returns(GetTestViagens());
            mockService.Setup(service => service.Get(1))
               .Returns(GetTargetViagem());
            mockService.Setup(service => service.Create(It.IsAny<Viagem>()))
               .Verifiable();
            controller = new ViagemController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<ViagemViewModel>));

            List<ViagemViewModel>? lista = (List<ViagemViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(ViagemViewModel));
            ViagemViewModel viagemViewModel = (ViagemViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Fest Verão 2023.2", viagemViewModel.Titulo);
            Assert.AreEqual("Itabaiana", viagemViewModel.LocalOrigem);
            Assert.AreEqual("Aracaju", viagemViewModel.LocalDestino);
            Assert.AreEqual(25, viagemViewModel.ValorPassagem);
            Assert.AreEqual(20, viagemViewModel.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-12-05"), viagemViewModel.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-12-10"), viagemViewModel.DataChegada);
            Assert.AreEqual("Conforto e segurança em um só lugar!", viagemViewModel.Descricao);
            Assert.AreEqual(1, viagemViewModel.IdMotorista);
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
            var result = controller.Create(GetNewViagem());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Invalid()
        {
            // Arrange
            controller.ModelState.AddModelError("Título", "Título da viagem é obrigatório.");

            // Act
            var result = controller.Create(GetNewViagem());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private ViagemViewModel GetNewViagem()
        {
            return new ViagemViewModel
            {
                Id = 1,
                Titulo = "Fest Verão 2023.1",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Aracaju",
                ValorPassagem = 25,
                TotalVagas = 20,
                DataPartida = DateTime.Parse("2023-10-15"),
                DataChegada = DateTime.Parse("2023-10-18"),
                Descricao = "Conforto e segurança em um só lugar!",
                IdMotorista = 1               
            };
        }

        private Viagem GetTargetViagem()
        {
            return new Viagem
            {
                Id = 2,
                Titulo = "Fest Verão 2023.2",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Aracaju",
                ValorPassagem = 25,
                TotalVagas = 20,
                DataPartida = DateTime.Parse("2023-12-05"),
                DataChegada = DateTime.Parse("2023-12-10"),
                Descricao = "Conforto e segurança em um só lugar!",
                IdMotorista = 1
            };
        }

        private ViagemViewModel GetTargetViagemViewModel()
        {
            return new ViagemViewModel
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
            };
        }

        private IEnumerable<Viagem> GetTestViagens()
        {
            return new List<Viagem>
            {
                new Viagem
                {
                    Id = 1,
                    Titulo = "Micarana 2023.1",
                    LocalOrigem = "Itabaiana",
                    LocalDestino = "Aracaju",
                    ValorPassagem = 25,
                    TotalVagas = 20,
                    DataPartida = DateTime.Parse("2023-10-15"),
                    DataChegada = DateTime.Parse("2023-10-18"),
                    Descricao = "Conforto e segurança em um só lugar!",
                    IdMotorista = 1
                },
                new Viagem
                {
                    Id = 2,
                    Titulo = "Fest Verão 2023.1",
                    LocalOrigem = "Itabaiana",
                    LocalDestino = "Aracaju",
                    ValorPassagem = 25,
                    TotalVagas = 20,
                    DataPartida = DateTime.Parse("2023-10-15"),
                    DataChegada = DateTime.Parse("2023-10-18"),
                    Descricao = "Conforto e segurança em um só lugar!",
                    IdMotorista = 1
                },
            };
        }
    }
}