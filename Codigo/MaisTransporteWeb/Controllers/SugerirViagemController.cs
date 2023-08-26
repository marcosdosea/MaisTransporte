using AutoMapper;
using MaisTransporteWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace MaisTransporteWeb.Controllers
{
    public class SugerirViagemController : Controller
    {
        private readonly ISugerirViagemService sugerirViagemService;
        private readonly IMapper mapper;

        public SugerirViagemController(ISugerirViagemService sugerirViagemService, IMapper mapper)
        {
            this.sugerirViagemService = sugerirViagemService;
            this.mapper = mapper;
        }

        // GET: SugerirViagemController
        public ActionResult Index()
        {
            var listaSugestaoViagem = sugerirViagemService.GetAll();
            var listaSugerirViagemViewModel = mapper.Map<List<SugerirViagemViewModel>>(listaSugestaoViagem);
            return View(listaSugerirViagemViewModel);
        }

        // GET: SugerirViagemController/Details
        public ActionResult Details(int id)
        {
            var sugerirViagem = sugerirViagemService.Get(id);
            var sugerirViagemViewModel = mapper.Map<SugerirViagemViewModel>(sugerirViagem);
            return View(sugerirViagemViewModel);
        }

        // GET: SugerirViagemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SugerirViagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SugerirViagemViewModel sugerirViagemViewModel)
        {
            if (ModelState.IsValid)
            {
                var sugerirViagem = mapper.Map<Sugestaoviagem>(sugerirViagemViewModel);
                sugerirViagemService.Create(sugerirViagem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
