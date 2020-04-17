using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralErros.Application.App;
using CentralErros.Application.Interface;
using CentralErros.Application.Mapper;
using CentralErros.Data.Repositorio;
using CentralErros.Domain.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CentralErros.Api
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
            //Configuração para quebrar a referência cicular da resposta da api
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IAplicacaoRepositorio, AplicacaoRepositorio>();
            services.AddScoped<IAvisoRepositorio, AvisoRepositorio>();
            services.AddScoped<ILogRepositorio, LogRepositorio>();
            services.AddScoped<ITipoLogRepositorio, TipoLogRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioAplicacaoRepositorio, UsuarioAplicacaoRepositorio>();
            services.AddScoped<IUsuarioAvisoRepositorio, UsuarioAvisoRepositorio>();

            services.AddScoped<IAplicacaoAplicacao, AplicacaoAplicacao>();
            services.AddScoped<IAvisoAplicacao, AvisoAplicacao>();
            services.AddScoped<ILogAplicacao, LogAplicacao>();
            services.AddScoped<ITipoLogAplicacao, TipoLogAplicacao>();
            services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
            services.AddScoped<IUsuarioAplicacaoAplicacao, UsuarioAplicacaoAplicacao>();
            services.AddScoped<IUsuarioAvisoAplicacao, UsuarioAvisoAplicacao>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddSwaggerGen(x => x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Central de Erros", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Configurando o Swagger
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api Central Erros");
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
