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
    public class SugerirViagensController : ControllerBase
    {
        private readonly ISugerirViagemService _sugerirViagemService;
        private readonly IMapper _mapper;

        public SugerirViagensController(ISugerirViagemService sugerirViagemService, IMapper mapper)
        {
            _sugerirViagemService = sugerirViagemService;
            _mapper = mapper;
        }

        // GET: api/<SugerirViagensController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaSugestoes = _sugerirViagemService.GetAll();
            if (listaSugestoes == null)
                return NotFound();
            return Ok(listaSugestoes);
        }

        // GET api/<SugerirViagensController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Sugestaoviagem sugestaoViagem = _sugerirViagemService.Get(id);
            if (sugestaoViagem == null)
                return NotFound();
            return Ok(sugestaoViagem);
        }

        // POST api/<SugerirViagensController>
        [HttpPost]
        public ActionResult Post([FromBody] SugerirViagemViewModel sugerirViagemModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var sugestaoViagem = _mapper.Map<Sugestaoviagem>(sugerirViagemModel);
            _sugerirViagemService.Create(sugestaoViagem);

            return Ok();
        }
    }
}