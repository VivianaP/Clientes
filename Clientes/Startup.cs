
using Clientes.Data;
using Clientes.Data.Repositorios;
using Clientes.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Clientes
{

    public class Startup
    {
        private readonly string _MyCors = "MyCors";


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

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddDbContext<MyDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyCors, builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").
                    AllowAnyHeader().AllowAnyMethod();

                });
            });



        }

        //  Uncomment if using a custom DI container
        //  public void ConfigureContainer(ContainerBuilder builder)
        //  {
        //  }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseCors(_MyCors);
        }
    }
}
