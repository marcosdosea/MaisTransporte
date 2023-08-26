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

        public ActionResult Index()
        {
            var listaViagens = viagemService.GetAll();
            var listaViagemViewModel = mapper.Map<List<ViagemViewModel>>(listaViagens);
            return View(listaViagemViewModel);
        }

        public ActionResult Details(int id)
        {
            var viagem = viagemService.Get(id);
            var viagemViewModel = mapper.Map<ViagemViewModel>(viagem);
            return View(viagemViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
