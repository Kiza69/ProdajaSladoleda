using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.Email;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using ProdajaSladoleda.EFCommands.Category;
using ProdajaSladoleda.EFCommands.Product;

namespace WEB
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ProdajaSladoledaContext>();
            //categories
            services.AddTransient<IGetCategoriesCommand, EFGetCategoriesCommand>();
            services.AddTransient<IGetCategoryCommand, EFGetCategoryCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryDLLCommand, EFGetCategoryDLLCommand>();
            //Products
            services.AddTransient<IGetProductsCommand, EFGetProductsCommand>();
            services.AddTransient<IGetProductCommand, EFGetProductCommand>();
            services.AddTransient<ICreateProductCommand, EFCreateProductCommand>();
            services.AddTransient<IEditProductCommand, EFEditProductCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();
            //Email
            var section = Configuration.GetSection("Email");
            var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromAddress"], section["password"]);
            services.AddSingleton<IEmailSending>(sender);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
