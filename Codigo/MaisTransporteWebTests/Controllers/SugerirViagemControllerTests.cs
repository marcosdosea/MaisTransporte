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
    public class SugerirViagemControllerTest
    {
        private static SugerirViagemController controller;
        private ISugerirViagemService @object;
        private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ISugerirViagemService>();

            IMapper mapper = new MapperConfiguration(cfg =>
               cfg.AddProfile(new SugerirViagemProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
               .Returns(GetTestSugestoes());
            mockService.Setup(service => service.Get(1))
               .Returns(GetTargetSugestao());
            mockService.Setup(service => service.Create(It.IsAny<Sugestaoviagem>()))
               .Verifiable();
            controller = new SugerirViagemController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<SugerirViagemViewModel>));

            List<SugerirViagemViewModel>? lista = (List<SugerirViagemViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(SugerirViagemViewModel));
            SugerirViagemViewModel sugerirViagemViewModel = (SugerirViagemViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("Fest Verão", sugerirViagemViewModel.Titulo);
            Assert.AreEqual("Itabaiana", sugerirViagemViewModel.LocalOrigem);
            Assert.AreEqual("Aracaju", sugerirViagemViewModel.LocalDestino);
            Assert.AreEqual(30, sugerirViagemViewModel.ValorPassagem);
            Assert.AreEqual(15, sugerirViagemViewModel.TotalVagas);
            Assert.AreEqual(DateTime.Parse("2023-08-01"), sugerirViagemViewModel.DataPartida);
            Assert.AreEqual(DateTime.Parse("2023-08-02"), sugerirViagemViewModel.DataChegada);
            Assert.AreEqual("Viagem com segurança, conforto e preço baixo.", sugerirViagemViewModel.Descricao);
            Assert.AreEqual("Pública", sugerirViagemViewModel.Visibilidade);
            Assert.AreEqual(1, sugerirViagemViewModel.IdPassageiro);
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
            var result = controller.Create(GetNewSugestao());

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
            var result = controller.Create(GetNewSugestao());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private SugerirViagemViewModel GetNewSugestao()
        {
            return new SugerirViagemViewModel
            {
                Id = 3,
                Titulo = "Festa dos Caretas",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Ribeirópolis",
                ValorPassagem = 15,
                TotalVagas = 25,
                DataPartida = DateTime.Parse("2023-04-10"),
                DataChegada = DateTime.Parse("2023-04-10"),
                Descricao = "Viagem com segurança, conforto e preço baixo.",
                Visibilidade = "Pública",
                IdPassageiro = 1
            };
        }

        private Sugestaoviagem GetTargetSugestao()
        {
            return new Sugestaoviagem
            {
                Id = 1,
                Titulo = "Fest Verão",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Aracaju",
                ValorPassagem = 30,
                TotalVagas = 15,
                DataPartida = DateTime.Parse("2023-08-01"),
                DataChegada = DateTime.Parse("2023-08-02"),
                Descricao = "Viagem com segurança, conforto e preço baixo.",
                Visibilidade = "Pública",
                IdPassageiro = 1
            };
        }

        private SugerirViagemViewModel GetTargetSugerirViagemViewModel()
        {
            return new SugerirViagemViewModel
            {
                Id = 2,
                Titulo = "Fest Verão",
                LocalOrigem = "Itabaiana",
                LocalDestino = "Aracaju",
                ValorPassagem = 30,
                TotalVagas = 15,
                DataPartida = DateTime.Parse("2023-08-01"),
                DataChegada = DateTime.Parse("2023-08-02"),
                Descricao = "Viagem com segurança, conforto e preço baixo.",
                Visibilidade = "Pública",
                IdPassageiro = 1
            };
        }

        private IEnumerable<Sugestaoviagem> GetTestSugestoes()
        {
            return new List<Sugestaoviagem>
            {
                new Sugestaoviagem
                {
                    Id = 1,
                    Titulo = "Festa dos Caminhoneiros",
                    LocalOrigem = "Aracaju",
                    LocalDestino = "Itabaiana",
                    ValorPassagem = 30,
                    TotalVagas = 20,
                    DataPartida = DateTime.Parse("2023-06-09"),
                    DataChegada = DateTime.Parse("2023-06-12"),
                    Descricao = "Viagem com segurança e conforto.",
                    Visibilidade = "Pública",
                    IdPassageiro = 1
                },
                new Sugestaoviagem
                {
                    Id = 2,
                    Titulo = "Fest Verão",
                    LocalOrigem = "Itabaiana",
                    LocalDestino = "Aracaju",
                    ValorPassagem = 30,
                    TotalVagas = 15,
                    DataPartida = DateTime.Parse("2023-08-01"),
                    DataChegada = DateTime.Parse("2023-08-02"),
                    Descricao = "Viagem com segurança, conforto e preço baixo.",
                    Visibilidade = "Pública",
                    IdPassageiro = 1
                },
            };
        }
    }
}