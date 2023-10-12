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
    public class ViagensController : ControllerBase
    {
        private readonly IViagemService _viagemService;
        private readonly IMapper _mapper;

        public ViagensController(IViagemService viagemService, IMapper mapper)
        {
            _viagemService = viagemService;
            _mapper = mapper;
        }

        // GET: api/<ViagensController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaViagens = _viagemService.GetAll();
            if (listaViagens == null)
                return NotFound();
            return Ok(listaViagens);
        }

        // GET api/<ViagensController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Viagem viagem = _viagemService.Get(id);
            if (viagem == null)
                return NotFound();
            return Ok(viagem);
        }

        // POST api/<ViagensController>
        [HttpPost]
        public ActionResult Post([FromBody] ViagemViewModel viagemModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var viagem = _mapper.Map<Viagem>(viagemModel);
            _viagemService.Create(viagem);

            return Ok();
        }
    }
}