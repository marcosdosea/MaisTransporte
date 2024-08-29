using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisTransporteWeb.Controllers
{
    [Authorize]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService veiculoService;
        private readonly IMotoristaService motoristaService;
        private readonly IMapper mapper;

        public VeiculoController(IVeiculoService veiculoService, IMotoristaService motoristaService, IMapper mapper)
        {
            this.veiculoService = veiculoService;
            this.motoristaService = motoristaService;
            this.mapper = mapper;
        }
        // GET: VeiculoController
        public ActionResult Index()
        {
            var listaVeiculo = veiculoService.GetAll();
            var listaVeiculoViewModel = mapper.Map<List<VeiculoViewModel>>(listaVeiculo);
            return View(listaVeiculoViewModel);
        }

        // GET: VeiculoController/Details/5
        public ActionResult Details(int id)
        {
            var veiculo = veiculoService.Get(id);
            var veiculoViewModel = mapper.Map<VeiculoViewModel>(veiculo);
            return View(veiculoViewModel);
        }

        // GET: VeiculoController/Create
        public ActionResult Create(int? idPassageiro)
        {
            var veiculoViewModel = new VeiculoViewModel();
            if (idPassageiro.HasValue)
            {
                veiculoViewModel.IdMotoristaPassageiro = idPassageiro.Value;
            }
            return View(veiculoViewModel);
        }


        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel veiculoViewModel, int idPassageiro)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o Motorista existe
                var motorista = motoristaService.Get(idPassageiro);
                if (motorista == null)
                {
                    ModelState.AddModelError("", "O motorista especificado não existe." + idPassageiro);
                    return View(veiculoViewModel);
                }

                // Mapear o view model para a entidade Veiculo
                var veiculo = mapper.Map<Veiculo>(veiculoViewModel);
                veiculo.IdMotoristaPassageiro = idPassageiro;

                // Definir a navegação de referência para garantir a associação correta
                veiculo.IdMotoristaPassageiroNavigation = motorista;

                veiculoService.Create(veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculoViewModel);
        }


        // GET: VeiculoController/Edit/5
        public ActionResult Edit(int id)
        {
            Veiculo veiculo = veiculoService.Get(id);
            VeiculoViewModel veiculoViewModel = mapper.Map<VeiculoViewModel>(veiculo);
            return View(veiculoViewModel);
        }

        // POST: VeiculoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VeiculoViewModel veiculoModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = mapper.Map<Veiculo>(veiculoModel);
                veiculoService.Edit(veiculo);
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
}
