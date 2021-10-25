using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using relicarioApi.Data;
using relicarioApi.Repositories;
using relicarioApi.Repositories.Galeria.Artistas;
using relicarioApi.Repositories.Galeria.Categorias;
using relicarioApi.Repositories.Galeria.Produtos;
using relicarioApi.Repositories.Home.Numeros;
using relicarioApi.Repositories.Home.Valores;
using relicarioApi.Repositories.Loja.Produtos;
using relicarioApi.Repositories.System.Parameter;
using relicarioApi.Services;
using relicarioApi.Services.Correio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace relicarioApi
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
            services.AddDbContext<DataContext>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("DbConnection")));

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IConsumeCorreioFrete, ConsumeFreteProduto>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICategoriaGaleriaRepository, CategoriaGaleriaRepository>();
            services.AddTransient<IGaleriaProdutoRepository, GaleriaProdutoRepository>();
            services.AddTransient<IProdutoGaleriaFotoRepository, ProdutoGaleriaFotoRepository>();
            services.AddTransient<IArtistaRepository, ArtistaRepository>();

            services.AddTransient<ICategoriaLojaRepository, CategoriaLojaRepository>();
            services.AddTransient<IProdutoLojaRepository, ProdutoLojaRepository>();
            services.AddTransient<IProdutoLojaAtributoRepository, ProdutoLojaAtributoRepository>();
            services.AddTransient<IProdutoLojaRelacionadoRepository, ProdutoLojaRelacionadoRepository>();
            services.AddTransient<IProdutoLojaFotoRepository, ProdutoLojaFotoRepository>();

            services.AddTransient<IValoresRepository, ValoresRepository>();
            services.AddTransient<INumerosRepository, NumerosRepository>();
            services.AddTransient<IParametersRepository, ParametersRepository>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "relicarioApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "relicarioApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
