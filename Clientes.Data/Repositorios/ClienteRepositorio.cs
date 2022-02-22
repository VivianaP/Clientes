using Clientes.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private PostgreSQConfiguration _connectionString;

        public ClienteRepositorio(PostgreSQConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }



        public async Task<Cliente> ConsultarPorId(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, nombre, tipo_documento, documento, razon_social, proveedores, ventas_ultimo
                        FROM public.cliente
                        WHERE id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id }); 
        }

        public async Task<IEnumerable<Cliente>> ConsultarTodos()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, nombre, tipo_documento, documento, razon_social, proveedores, ventas_ultimo
                        FROM public.cliente";

            return await db.QueryAsync<Cliente>(sql, new {});

        }

        public async Task<bool> InsertarCliente(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO public.cliente ( nombre, tipo_documento, documento, razon_social, proveedores, ventas_ultimo)
                        VALUES(@Nombre, @TipDocumento, @Documento, @RazonSocial, @Proveedores, @VentasUltimo) ";

            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.TipoDocumento, cliente.Documento, cliente.RazonSocial, cliente.Proveedores, cliente.VentasUltimo});

            return result > 0;
        }

        public async Task<bool> EditarCliente(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE public.cliente 
                        SET nombre = @Nombre,
                            tipo_documento = @TipDocumento,
                            documento = @Documento, 
                            razon_social = @RazonSocial, 
                            proveedores = @Proveedores, 
                            ventas_ultimo = @VentasUltimo
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { cliente.Nombre, cliente.TipoDocumento, cliente.Documento, cliente.RazonSocial, cliente.Proveedores, cliente.VentasUltimo, cliente.Id });

            return result > 0;
        }

        public async Task<bool> EliminarCliente(Cliente cliente)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM public.cliente
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = cliente.Id});
           
            return result > 0;

        }

        
    }
}
