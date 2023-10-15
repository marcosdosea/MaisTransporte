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
        private readonly IMapper mapper;

        public VeiculoController(IVeiculoService veiculoService, IMapper mapper)
        {
            this.veiculoService = veiculoService;
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
        public ActionResult Create()
        {

            return View();
        }

        // POST: VeiculoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel veiculoViewModel)
        {
            if (ModelState.IsValid)
            {
                var veiculo = mapper.Map<Veiculo>(veiculoViewModel);
                veiculoService.Create(veiculo);
            }
            return RedirectToAction(nameof(Index));
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
