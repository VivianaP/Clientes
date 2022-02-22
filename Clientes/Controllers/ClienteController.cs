using Clientes.Data.Repositorios;
using Clientes.Model;
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ConsultarTodos()
        {
            return Ok(await _clienteRepositorio.ConsultarTodos());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarPorId(int id)
        {
            return Ok(await _clienteRepositorio.ConsultarPorId(id));

        }

        [HttpPost]
        public async Task<IActionResult> InsertarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _clienteRepositorio.InsertarCliente(cliente);

            return Created("creared", created);

        }

        [HttpPut]
        public async Task<IActionResult> EditarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clienteRepositorio.EditarCliente(cliente);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {

            await _clienteRepositorio.EliminarCliente(new Cliente { Id = id });

            return NoContent();

        }

    }
}
