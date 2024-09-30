using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using MaisTransporteWeb.Models;

namespace MaisTransporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SugestaoviagensController : ControllerBase
    {
        private readonly ISugestaoviagemService _sugestaoviagemService;
        private readonly IMapper _mapper;

        public SugestaoviagensController(ISugestaoviagemService sugestaoviagemService, IMapper mapper)
        {
            _sugestaoviagemService = sugestaoviagemService;
            _mapper = mapper;
        }

        // GET: api/<SugerirViagensController>
        [HttpGet]
        public ActionResult Get()
        {
            var listaSugestoes = _sugestaoviagemService.GetAll();
            if (listaSugestoes == null)
                return NotFound();
            return Ok(listaSugestoes);
        }

        // GET api/<SugerirViagensController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Sugestaoviagem sugestaoViagem = _sugestaoviagemService.Get(id);
            if (sugestaoViagem == null)
                return NotFound();
            return Ok(sugestaoViagem);
        }

        // POST api/<SugerirViagensController>
        [HttpPost]
        public ActionResult Post([FromBody] SugestaoviagemViewModel sugestaoviagemModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var sugestaoViagem = _mapper.Map<Sugestaoviagem>(sugestaoviagemModel);
            _sugestaoviagemService.Create(sugestaoViagem);

            return Ok();
        }
    }
}