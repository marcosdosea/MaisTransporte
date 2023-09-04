using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisTransporteWeb.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IMotoristaService motoristaService;
        private readonly IMapper mapper;

        public MotoristaController(IMotoristaService motoristaService, IMapper mapper)
        {
            this.motoristaService = motoristaService;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: MotoristaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MotoristaViewModel motoristaViewModel)
        {
            if (ModelState.IsValid)
            {
                var motorista = mapper.Map<Motoristum>(motoristaViewModel);
                motoristaService.Create(motorista);
            }
            return RedirectToAction(nameof(Index));
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
