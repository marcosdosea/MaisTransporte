using AutoMapper;
using Core.Service;
using Core;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaisTransporteWeb.Controllers
{
    public class ViagemController : Controller
    {
        private readonly IViagemService viagemService;
        private readonly IMapper mapper;

        public ViagemController(IViagemService viagemService, IMapper mapper)
        {
            this.viagemService = viagemService;
            this.mapper = mapper;
        }

        // GET: ViagemController
        public ActionResult Index()
        {
            var listaViagens = viagemService.GetAll();
            var listaViagemViewModel = mapper.Map<List<ViagemViewModel>>(listaViagens);
            return View(listaViagemViewModel);
        }

        // GET: ViagemController/Details
        public ActionResult Details(int id)
        {
            var viagem = viagemService.Get(id);
            var viagemViewModel = mapper.Map<ViagemViewModel>(viagem);
            return View(viagemViewModel);
        }

        // GET: ViagemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViagemViewModel viagemViewModel)
        {
            if (ModelState.IsValid)
            {
                var viagem = mapper.Map<Viagem>(viagemViewModel);
                viagemService.Create(viagem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
