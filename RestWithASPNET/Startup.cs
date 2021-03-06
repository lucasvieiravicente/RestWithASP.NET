using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Interfaces;
using RestWithASPNET.Services;
using RestWithASPNET.Services.Interfaces;

namespace RestWithASPNET
{
    public class Startup
    {
        public IConfiguration Configuration { get; }        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MySqlConnectionString");
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString));

            services.AddControllers();
            services.AddApiVersioning();
            services.AddMvc().AddNewtonsoftJson();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
