using AutoMapper;
using MaisTransporteWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Service;

namespace MaisTransporteWeb.Controllers
{
    [Authorize]
    public class SugerirViagemController : Controller
    {
        private readonly ISugerirViagemService sugerirViagemService;
        private readonly IViagemService viagemService;
        private readonly IMapper mapper;

        public SugerirViagemController(ISugerirViagemService sugerirViagemService, IViagemService viagemService, IMapper mapper)
        {
            this.sugerirViagemService = sugerirViagemService;
            this.viagemService = viagemService;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AceitarViagem(int id)
        {
            var sugestaoViagem = sugerirViagemService.Get(id);

            if (sugestaoViagem != null)
            {
                // Mapeia a Sugestaoviagem para Viagem
                var viagem = mapper.Map<Viagem>(sugestaoViagem);

                // Salva a nova viagem no banco de dados
                viagemService.Create(viagem);

                // Remove a sugestão de viagem do banco de dados
                sugerirViagemService.Delete(id);
            }

            return RedirectToAction("Index", "Viagem"); // Redireciona para a tela de viagens
        }
    }
}
