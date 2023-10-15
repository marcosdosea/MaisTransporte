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
    public class CancelarReservaController : Controller
    {
        private readonly IReservaService reservaService;
        private readonly IMapper mapper;

        public CancelarReservaController(IReservaService reservaService, IMapper mapper)
        {
            this.reservaService = reservaService;
            this.mapper = mapper;
        }

        // GET: CancelarReservaController
        public ActionResult Index()
        {
            var listaReservas = reservaService.GetAll();
            var listaReservasViewModel = mapper.Map<List<ReservaViewModel>>(listaReservas);
            return View(listaReservasViewModel);
        }

        // GET: CancelarReservaController/Delete
        public ActionResult Delete(int id)
        {
            Reserva reserva = reservaService.Get(id);
            ReservaViewModel reservaViewModel = mapper.Map<ReservaViewModel>(reserva);
            return View(reservaViewModel);
        }

        // POST: CancelarReservaController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ReservaViewModel reservaModel)
        {
            reservaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}