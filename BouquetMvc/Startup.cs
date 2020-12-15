using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BouquetEngine.Model;
using BouquetEngine.Storage;
using BouquetMvc.Servises;
using Npgsql;

namespace BouquetMvc
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
            services.AddControllersWithViews();
            // connection string
            var connection = new NpgsqlConnection(
               "Host=isilo.db.elephantsql.com;Port=5432;Database=ighjlwdb;" +
               "Username=ighjlwdb;Password=4l7MttgNRLGL7c0M01PloeX2sDvAlr65;"
           );
            connection.Open();

            IBouquetStorage bouquetStorage = new BouquetDBStorage(connection);
            IOrderStorage orderStorage = new OrderDBStorage(connection);

            services.AddSingleton<IBouquetStorage>(bouquetStorage);
            services.AddSingleton<IOrderStorage>(orderStorage);
            services.AddSingleton<SessionCartStorage>(new SessionCartStorage());
            services.AddSession(options =>
            {
                options.Cookie.Name = "_boquet_boutique_session_id";
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
