using Clientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> ConsultarTodos();

        Task<Cliente> ConsultarPorId(int id);

        Task<bool> InsertarCliente(Cliente cliente);

        Task<bool> EditarCliente(Cliente cliente);

        Task<bool> EliminarCliente(Cliente cliente);

    }
}
