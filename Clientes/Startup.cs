
using Clientes.Data;
using Clientes.Data.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Clientes
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var postgreSQLConnectionConfuguracion = new PostgreSQConfiguration(Configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgreSQLConnectionConfuguracion);

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            
        }

        //  Uncomment if using a custom DI container
        //  public void ConfigureContainer(ContainerBuilder builder)
        //  {
        //  }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {

        }
    }
}
