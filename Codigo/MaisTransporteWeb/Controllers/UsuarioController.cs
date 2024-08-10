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
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var listaUsuarios = usuarioService.GetAll();
            var listaUsuariosViewModel = mapper.Map<List<UsuarioViewModel>>(listaUsuarios);
            return View(listaUsuariosViewModel);
        }

        // GET: UsuarioController/Details
        public ActionResult Details(int id)
        {
            var usuario = usuarioService.Get(id);
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(usuario);
            return View(usuarioViewModel);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel, string submitButton)
        {
            if (ModelState.IsValid)
            {
                var passageiro = mapper.Map<Passageiro>(usuarioViewModel);

                // Cria o passageiro e retorna o ID
                usuarioService.Create(passageiro);

                if (submitButton == "MOTORISTA")
                {
                    // Redireciona para a criação de motorista com o ID do passageiro
                    return RedirectToAction("Create", "Motorista", new { idPassageiro = passageiro.Id });
                }

                // Se for "PASSAGEIRO", redireciona para a index
                return RedirectToAction(nameof(Index));
            }

            // Se o modelo não for válido, retorna à mesma view com os erros
            return View(usuarioViewModel);
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            Passageiro passageiro = usuarioService.Get(id);
            UsuarioViewModel usuarioViewModel = mapper.Map<UsuarioViewModel>(passageiro);
            return View(usuarioViewModel);
        }
        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioViewModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var passageiro = mapper.Map<Passageiro>(usuarioModel);
                usuarioService.Edit(passageiro);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            Passageiro passageiro = usuarioService.Get(id);
            UsuarioViewModel usuarioViewModel = mapper.Map<UsuarioViewModel>(passageiro);
            return View(usuarioViewModel);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioViewModel usuarioModel)
        {
            usuarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
