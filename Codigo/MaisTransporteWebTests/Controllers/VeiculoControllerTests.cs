using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Controllers;
using MaisTransporteWeb.Mappers;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace MaisTransporteWebTests.Controllers
{
    [TestClass]
    public class VeiculoControllerTests
    {
        private static VeiculoController controller;
        //private IVeiculoService @object;
        //private IMapper mapper;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IVeiculoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
               cfg.AddProfile(new VeiculoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
               .Returns(GetTestVeiculo());
            mockService.Setup(service => service.Get(1))
               .Returns(GetTargetVeiculo());
            mockService.Setup(service => service.Create(It.IsAny<Veiculo>()))
               .Verifiable();
            controller = new VeiculoController(mockService.Object, mapper);
        }


        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<VeiculoViewModel>));

            List<VeiculoViewModel>? lista = (List<VeiculoViewModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VeiculoViewModel));
            VeiculoViewModel veiculoViewModel = (VeiculoViewModel)viewResult.ViewData.Model;

            Assert.AreEqual("123235212", veiculoViewModel.Renavam);
            Assert.AreEqual("OHD-2929", veiculoViewModel.Placa);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), veiculoViewModel.DataEmissao);
            Assert.AreEqual("SSP", veiculoViewModel.Expedidor);
            Assert.AreEqual("SE", veiculoViewModel.Estado);
            Assert.AreEqual(1, veiculoViewModel.IdMotoristaPassageiro);
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
            var result = controller.Create(GetNewVeiculo());

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
            controller.ModelState.AddModelError("Renavam", "Número do Renavam é obrigatório.");

            // Act
            var result = controller.Create(GetNewVeiculo());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(VeiculoViewModel));
            VeiculoViewModel veiculoViewModel = (VeiculoViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("123235212", veiculoViewModel.Renavam);
            Assert.AreEqual("OHD-2929", veiculoViewModel.Placa);
            Assert.AreEqual(DateTime.Parse("2023-04-10"), veiculoViewModel.DataEmissao);
            Assert.AreEqual("SSP", veiculoViewModel.Expedidor);
            Assert.AreEqual("SE", veiculoViewModel.Estado);
            Assert.AreEqual(1, veiculoViewModel.IdMotoristaPassageiro);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(GetTargetVeiculoViewModel().Id, GetTargetVeiculoViewModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private VeiculoViewModel GetNewVeiculo()
        {
            return new VeiculoViewModel
            {
                Id = 1,
                Renavam = "123235212",
                Placa = "OHD-2929",
                DataEmissao = DateTime.Parse("2023-04-10"),
                Expedidor = "SSP",
                Estado = "SE",
                IdMotoristaPassageiro = 1,
            };
        }
        
        private Veiculo GetTargetVeiculo()
        {
            return new Veiculo
            {
                Id = 5,
                Renavam = "123235212",
                Placa = "OHD-2929",
                DataEmissao = DateTime.Parse("2023-04-10"),
                Expedidor = "SSP",
                Estado = "SE",
                IdMotoristaPassageiro = 1,
            };
        }
        private VeiculoViewModel GetTargetVeiculoViewModel()
        {
            return new VeiculoViewModel
            {
                Id = 2,
                Renavam = "123235212",
                Placa = "OHD-2929",
                DataEmissao = DateTime.Parse("2023-04-10"),
                Expedidor = "SSP",
                Estado = "SE",
                IdMotoristaPassageiro = 1
            };
        }

        private IEnumerable<Veiculo> GetTestVeiculo()
        {
            return new List<Veiculo>
            {
                new Veiculo
                {
                    Id = 1,
                    Renavam = "123235212",
                    Placa = "OHD-2929",
                    DataEmissao = DateTime.Parse("2023-04-10"),
                    Expedidor = "SSP",
                    Estado = "SE",
                    IdMotoristaPassageiro = 1
                },
                new Veiculo
                {
                    Id = 2,
                    Renavam = "123235212",
                    Placa = "OHD-2929",
                    DataEmissao = DateTime.Parse("2023-04-10"),
                    Expedidor = "SSP",
                    Estado = "SE",
                    IdMotoristaPassageiro = 1,
                },
            };
        }


    }
}
