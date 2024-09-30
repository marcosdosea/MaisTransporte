using AutoMapper;
using MaisTransporteWeb.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MaisTransporteWeb.Controllers
{
    [Authorize]
    public class SugestaoviagemController : Controller
    {
        private readonly ISugestaoviagemService _sugestaoviagemService;
        private readonly IViagemService _viagemService;
        private readonly IMapper _mapper;

        public SugestaoviagemController(ISugestaoviagemService sugestaoviagemService, IViagemService viagemService, IMapper mapper)
        {
            _sugestaoviagemService = sugestaoviagemService;
            _viagemService = viagemService;
            _mapper = mapper;
        }

        // GET: SugerirViagemController
        public ActionResult Index()
        {
            var listaSugestaoViagem = _sugestaoviagemService.GetAll();
            var listaSugestaoviagemModel = _mapper.Map<List<SugestaoviagemViewModel>>(listaSugestaoViagem);
            return View(listaSugestaoviagemModel);
        }

        // GET: SugerirViagemController/Details
        public ActionResult Details(int id)
        {
            var sugestaoViagem = _sugestaoviagemService.Get(id);
            var sugestaoviagemModel = _mapper.Map<SugestaoviagemViewModel>(sugestaoViagem);
            return View(sugestaoviagemModel);
        }

        // GET: SugerirViagemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SugerirViagemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SugestaoviagemViewModel sugestaoViagemModel)
        {
            if (ModelState.IsValid)
            {
                var sugestaoViagem = _mapper.Map<Sugestaoviagem>(sugestaoViagemModel);
                _sugestaoviagemService.Create(sugestaoViagem);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AceitarViagem(int id)
        {
            var sugestaoViagem = _sugestaoviagemService.Get(id);

            if (sugestaoViagem != null)
            {
                // Mapeia a Sugestaoviagem para Viagem
                var viagem = _mapper.Map<Viagem>(sugestaoViagem);

                // Salva a nova viagem no banco de dados
                _viagemService.Create(viagem);

                // Remove a sugestão de viagem do banco de dados
                _sugestaoviagemService.Delete(id);
            }

            return RedirectToAction("Index", "Viagem"); // Redireciona para a tela de viagens
        }
    }
}
