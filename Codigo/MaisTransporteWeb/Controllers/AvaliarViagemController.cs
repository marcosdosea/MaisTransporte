using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisTransporteWeb.Controllers
{
    public class AvaliarViagemController : Controller
    {
        private readonly IAvaliacaoViagemService avaliacaoViagemService;
        private readonly IMapper mapper;

        public AvaliarViagemController(IAvaliacaoViagemService avaliacaoViagemService, IMapper mapper)
        {
            this.avaliacaoViagemService = avaliacaoViagemService;
            this.mapper = mapper;
        }
        // GET: AvaliarViagemController
        public ActionResult Index()
        {
            var listaAvaliacaoViagem = avaliacaoViagemService.GetAll();
            var listaAvaliarViagemViewModel = mapper.Map<List<AvaliarViagemViewModel>>(listaAvaliacaoViagem);
            return View(listaAvaliarViagemViewModel);
        }

        // GET: AvaliarViagemController/Details/5
        public ActionResult Details(int id)
        {
            var avaliarViagem = avaliacaoViagemService.Get(id);
            var avaliarViagemViewModel = mapper.Map<AvaliarViagemViewModel>(avaliarViagem);
            return View(avaliarViagemViewModel);
        }

        // GET: AvaliarViagemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvaliarViagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliarViagemViewModel avaliarViagemModel)
        {
            if (ModelState.IsValid)
            {
                var avaliarViagem = mapper.Map<Avaliacao>(avaliacaoViagemService);
                avaliacaoViagemService.Create(avaliarViagem);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
