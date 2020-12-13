using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xayah.FIControl.Business;
using Xayah.FIControl.DataContext;
using Xayah.FIControl.DataContext.Repositories;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.UI
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

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            DefineInjection(services);
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }


        private static void DefineInjection(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite().AddDbContext<XayahFIControlDataContext>();


            services.AddTransient(typeof(IBaseBusiness<>), typeof(BaseBusiness<>));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddTransient(typeof(IAccountlauncheRepository), typeof(AccountlauncheRepository));
            services.AddTransient(typeof(IAccountlauncheBusiness), typeof(AccountlauncheBusiness));

            services.AddTransient(typeof(IBankStatementRepository), typeof(BankStatementRepository));
            services.AddTransient(typeof(IBankStatementBusiness), typeof(BankStatementBusiness));




        }
    }
}
