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
            string conString = "User Id=ADMIN;Password=pS18062016!Linus;";

            string WalletLocLokal = @"C:\Users\pat15\Desktop\master\abschlussarbeit\sourcen\MasterarbeitRestServer\DB";
            string WalletLocCloud = @"D:\home\site\repository\DB";



            string walletLoc = WalletLocCloud;

            //Enter port, host name or IP, service name, and wallet directory for your Oracle Autonomous DB.
            conString += "Data Source=(description=(address=(protocol=tcps)(port=1522)(host=adb.eu-frankfurt-1.oraclecloud.com))(connect_data=(service_name=ok6xrgnsfgkpak1_masterarbeitdb_high.adb.oraclecloud.com))(SECURITY = (MY_WALLET_DIRECTORY = " + walletLoc + ")));";


            //OracleConfiguration.TnsAdmin = @"..\repository\DB";
            //OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;

            

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

            app.UseHttpsRedirection();

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
