using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterarbeitRestServer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace MasterarbeitRestServer
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
            
            string conString = "User Id=ADMIN;Password=pS18062016!Linus;Data Source=masterarbeitdb_high";

            OracleConfiguration.TnsAdmin = @"C:\Users\pat15\Documents\Wallet_MasterarbeitDB";
            OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

            services.AddDbContext<Context>(opt => opt.UseOracle(conString));
            
            services.AddControllers();


            services.AddScoped<IRepository, OracleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Test 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
