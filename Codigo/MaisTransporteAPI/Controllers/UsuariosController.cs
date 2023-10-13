using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using MaisTransporteWeb.Models;
using Org.BouncyCastle.Crypto;

namespace MaisTransporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;
        private object UsuarioService;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var listaUsuario = _usuarioService.GetAll();
            var listaUsuarioModel = _mapper.Map<List<UsuarioViewModel>>(listaUsuario);
            return Ok(listaUsuarioModel);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Passageiro usuario = _usuarioService.Get(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioViewModel usuarioModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var usuario = _mapper.Map<Passageiro>(usuarioModel);
            _usuarioService.Create(usuario);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioViewModel usuarioModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var usuario = _mapper.Map<Passageiro>(usuarioModel);
            if (usuario == null)
                return NotFound();

            _usuarioService.Edit(usuario);

            return Ok();
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Passageiro usuario = _usuarioService.Get(id);
            if (usuario == null)
                return NotFound();

            _usuarioService.Delete(id);
            return Ok();
        }
    }
}
