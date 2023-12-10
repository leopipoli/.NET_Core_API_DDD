using CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace API
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
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Curso de API com AspNetCore - Na Prática",
                    Description = "Arquitetura DDD",
                    //TermsOfService = new Uri("https://www.linkedin.com/in/leonardo-da-silva-pipoli-172b6a171/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Leonardo da Silva Pipoli",
                        Email = "leonardo.pipoli48@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/leonardo-da-silva-pipoli-172b6a171/")
                    },
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Termo de Licença de Uso",
                    //    Url = new Uri("https://www.linkedin.com/in/leonardo-da-silva-pipoli-172b6a171/")
                    //}
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso API com AspNetCore");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
