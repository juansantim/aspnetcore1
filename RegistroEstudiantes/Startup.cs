using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RegistroEstudiantes.Data;

namespace RegistroEstudiantes
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
            services.AddDbContextPool<RegistroEstudiantesContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("RegistroEstudiantesDB"));
            });

            //services.AddSingleton<IMateriaService, inMemoryMateriasService>();
            services.AddScoped<IMateriaService, RegistroEstudiantesService>();
;
            services.AddRazorPages();
            services.AddControllers();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(NuestroMiddleWare);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            //Este middleware debe ir antes de useEndpoits
            app.UseAuthentication();
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private RequestDelegate NuestroMiddleWare(RequestDelegate next)
        {
            return async httpRequest =>
            {
                if (httpRequest.Request.Path.StartsWithSegments("/MiMiddleware"))
                {
                    await httpRequest.Response.WriteAsync("Hola desde nuestro middleware");
                }
                else 
                {
                    await next(httpRequest);
                }
                
            };
        }
    }
}
