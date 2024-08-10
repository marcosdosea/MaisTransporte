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
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService motoristaService;
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public MotoristaController(IMotoristaService motoristaService, IUsuarioService usuarioService, IMapper mapper)
        {
            this.motoristaService = motoristaService;
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }

        // GET: MotoristaController
        public ActionResult Index()
        {
            var listaMotoristas = motoristaService.GetAll();
            var listaMotoristasViewModel = mapper.Map<List<MotoristaViewModel>>(listaMotoristas);
            return View(listaMotoristasViewModel);
        }

        // GET: MotoristaController/Details
        public ActionResult Details(int id)
        {
            var motorista = motoristaService.Get(id);
            var motoristaViewModel = mapper.Map<MotoristaViewModel>(motorista);
            return View(motoristaViewModel);
        }

        // GET: MotoristaController/Create
        public ActionResult Create(int? idPassageiro)
        {
            var motoristaViewModel = new MotoristaViewModel();
            if (idPassageiro.HasValue)
            {
                motoristaViewModel.IdPassageiro = idPassageiro.Value;
            }
            return View(motoristaViewModel);
        }

        // POST: MotoristaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotoristaViewModel motoristaViewModel, int idPassageiro)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o Passageiro existe
                var passageiro = usuarioService.Get(idPassageiro);
                if (passageiro == null)
                {
                    ModelState.AddModelError("", "O passageiro especificado não existe." + idPassageiro);
                    return View(motoristaViewModel);
                }

                // Mapear o view model para a entidade Motoristum
                var motorista = mapper.Map<Motoristum>(motoristaViewModel);
                motorista.IdPassageiro = idPassageiro;

                // Definir a navegação de referência para garantir a associação correta
                motorista.IdPassageiroNavigation = passageiro;

                motoristaService.Create(motorista);
                return RedirectToAction(nameof(Index));
            }
            return View(motoristaViewModel);
        }


        // GET: MotoristaController/Edit/5
        public ActionResult Edit(int id)
        {
            Motoristum motorista = motoristaService.Get(id);
            MotoristaViewModel motoristaViewModel = mapper.Map<MotoristaViewModel>(motorista);
            return View(motoristaViewModel);
        }
        // POST: MotoristaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MotoristaViewModel motoristaModel)
        {
            if (ModelState.IsValid)
            {
                var motorista = mapper.Map<Motoristum>(motoristaModel);
                motoristaService.Edit(motorista);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: MotoristaController/Delete/5
        public ActionResult Delete(int id)
        {
            Motoristum motorista = motoristaService.Get(id);
            MotoristaViewModel motoristaViewModel = mapper.Map<MotoristaViewModel>(motorista);
            return View(motoristaViewModel);
        }

        // POST: MotoristaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MotoristaViewModel motoristaModel)
        {
            motoristaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
