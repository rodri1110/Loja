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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly ILogger<ClientesController> _logger;

        /// <summary>
        /// Construtor da controller realizando a injeção ao ser instanciado
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public ClientesController(IClienteService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados na base de dados
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            //_logger são exibidos em diferentes leveis, verificar em appsettings.Development.json e alterar de acordo com a necessidade (error, fatal, information, warning, etc)
            //using para apresentar o request time.
            using (Operation.Time("Consulta todos os clientes"))
            {
                //throw new Exception("testando request get exception do serilog.exception...");
                return Ok(await _service.ListaClientesAsync());
            }
        }

        /// <summary>
        /// Retorna um cliente
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.ListaClienteAsync(id));
        }

        /// <summary>
        /// Salva um cliente na base
        /// </summary>
        /// <param name="clienteModelView"></param>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ClienteModelView clienteModelView)
        {
            //verificar o objeto que está sendo recebido @obj é a sintaxe do Serilog
            _logger.LogInformation("Objeto recebido {@clienteModelView}", clienteModelView);

            Cliente novoCliente;
            using (Operation.Time("Tempo de adição de um novo cliente"))
            {

                _logger.LogInformation("Request para inserção de novo cliente.");
                novoCliente = await _service.SalvarClienteAsync(clienteModelView);
                //throw new Exception("testando post exception do serilog.exception...");
            }
            return CreatedAtAction(nameof(Get), new { id = novoCliente.ClienteId }, novoCliente);
        }

        /// <summary>
        /// Atualiza os dados de um cliente e registra a data de atualização
        /// </summary>
        /// <param name="clienteModelView"></param>
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] AtualizarClienteModelView clienteModelView)
        {
            var clienteAtualizado = await _service.AtualizarClienteAsync(clienteModelView);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        /// <summary>
        /// Deleta um cliente na base
        /// </summary>
        /// <param name="id" example="123">Id do cliente</param>
        /// <remarks>Ao Excluir um cliente o mesmo será removido permanentemente da base</remarks>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteDeletado = await _service.DeletarCliente(id);
            if (clienteDeletado) { return NoContent(); }
            return NotFound();
        }
    }
}
