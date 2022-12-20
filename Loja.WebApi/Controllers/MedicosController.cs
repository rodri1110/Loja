using Loja.Core.Domain;
using Loja.Core.Shared.ModelViews;
using Loja.Manager.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Loja.WebApi.Controllers
{
    /// <summary>
    /// Controller de cliente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _service;
        private readonly ILogger<MedicosController> _logger;

        /// <summary>
        /// Construtor da controller realizando a injeção ao ser instanciado
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public MedicosController(IMedicoService service, ILogger<MedicosController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os Medicos cadastrados na base de dados
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            //_logger são exibidos em diferentes leveis, verificar em appsettings.Development.json e alterar de acordo com a necessidade (error, fatal, information, warning, etc)
            //using para apresentar o request time.
            using (Operation.Time("Consulta todos os médicos"))
            {
                //throw new Exception("testando request get exception do serilog.exception...");
                return Ok(await _service.ListaMedicosAsync());
            }
        }

        /// <summary>
        /// Retorna um médico
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.ListaMedicoAsync(id));
        }

        /// <summary>
        /// Salva um médico na base
        /// </summary>
        /// <param name="medicoView"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] MedicoView medicoView)
        {
            //verificar o objeto que está sendo recebido @obj é a sintaxe do Serilog
            _logger.LogInformation("Objeto recebido {@medicoView}", medicoView);

            MedicoView novoMedico;
            using (Operation.Time("Tempo de adição de um novo médico"))
            {

                _logger.LogInformation("Request para inserção de novo médico.");
                novoMedico = await _service.SalvarMedicoAsync(medicoView);
                //throw new Exception("testando post exception do serilog.exception...");
            }
            return CreatedAtAction(nameof(Get), new { id = novoMedico.MedicoId }, novoMedico);
        }

        /// <summary>
        /// Atualiza os dados de um médico
        /// </summary>
        /// <param name="medicoView"></param>
        [HttpPut]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] AtualizarMedicoModelView medicoView)
        {
            var medicoAtualizado = await _service.AtualizarMedicoAsync(medicoView);
            if (medicoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(medicoAtualizado);
        }

        /// <summary>
        /// Deleta um médico na base
        /// </summary>
        /// <param name="id" example="123">Id do médico</param>
        /// <remarks>Ao Excluir um médico o mesmo será removido permanentemente da base</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Medico), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var medicoDeletado = await _service.DeletarMedico(id);
            if (medicoDeletado) { return NoContent(); }
            return NotFound();
        }
    }
}
