using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using MaisTransporteWeb.Models;
using Org.BouncyCastle.Crypto;
using Service;

namespace MaisTransporteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMapper _mapper;
        private object VeiculoService;

        public VeiculosController(IVeiculoService veiculoService, IMapper mapper)
        {
            this._veiculoService = veiculoService;
            this._mapper = mapper;
        }
        // GET: VeiculoController
        [HttpGet]
        public ActionResult Get()
        {
            var listaVeiculo = _veiculoService.GetAll();
            var listaVeiculoViewModel = _mapper.Map<List<VeiculoViewModel>>(listaVeiculo);
            return Ok(listaVeiculoViewModel);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Veiculo veiculo = _veiculoService.Get(id);
            if (veiculo == null)
                return NotFound();
            return Ok(veiculo);
        }

        [HttpPost]
        public ActionResult Post([FromBody] VeiculoViewModel veiculoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var veiculo = _mapper.Map<Veiculo>(veiculoModel);
            _veiculoService.Create(veiculo);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] VeiculoViewModel veiculoModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var veiculo = _mapper.Map<Veiculo>(veiculoModel);
            if (veiculo == null)
                return NotFound();

            _veiculoService.Edit(veiculo);

            return Ok();
        }

    }
}
