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

        

    }
}
