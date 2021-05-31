using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SisApiRestCRUD.Data;
using SisApiRestCRUD.Repositories;
using SisApiRestCRUD.Repositorios;
using SisApiRestCRUD.Repositorios.Contratos;

namespace SisApiRestCRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();

            //Repositórios
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<ICursoRepositorio, CursoRepositorio>();

            //Banco em memórias para testes iniciais
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));

            //Conexão banco SQL Server
            string connection = "Data Source=SQL5097.site4now.net;Initial Catalog=db_a753bc_teste;User Id=db_a753bc_teste_admin;Password=Senhateste123";
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));


            //Inserindo Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "API Rest CRUD - Test",
                    Description = "Swagger",
                    Contact = new OpenApiContact()
                    {
                        Name = "Anderson Ribeiro Lopes",
                        Email = "anderrlopes@hotmail.com",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //Configurações swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Rest CRUD - Test");

            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
