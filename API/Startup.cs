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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProdajaSladoleda.Application.Commands.Category;
using ProdajaSladoleda.Application.Commands.Customer;
using ProdajaSladoleda.Application.Commands.Employee;
using ProdajaSladoleda.Application.Commands.Order;
using ProdajaSladoleda.Application.Commands.OrderDetail;
using ProdajaSladoleda.Application.Commands.Product;
using ProdajaSladoleda.Application.Commands.Role;
using ProdajaSladoleda.Application.Commands.User;
using ProdajaSladoleda.Application.Email;
using ProdajaSladoleda.Application.Interface;
using ProdajaSladoleda.DataAccess.EFDataAccess;
using ProdajaSladoleda.EFCommands.Category;
using ProdajaSladoleda.EFCommands.Customer;
using ProdajaSladoleda.EFCommands.Employee;
using ProdajaSladoleda.EFCommands.Order;
using ProdajaSladoleda.EFCommands.OrderDetail;
using ProdajaSladoleda.EFCommands.Product;
using ProdajaSladoleda.EFCommands.Role;
using ProdajaSladoleda.EFCommands.User;
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ProdajaSladoledaContext>();
            //categories
            services.AddTransient<IGetCategoriesCommand, EFGetCategoriesCommand>();
            services.AddTransient<IGetCategoryCommand, EFGetCategoryCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();
            //roles
            services.AddTransient<IGetRolesCommand, EFGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EFGetRoleCommand>();
            services.AddTransient<ICreateRoleCommand, EFCreateRoleCommand>();
            services.AddTransient<IEditRoleCommand, EFEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            //users
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<ICreateUserCommand, EFCreateUserCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            //Customers
            services.AddTransient<IGetCustomersCommand, EFGetCustomersCommand>();
            services.AddTransient<IGetCustomerCommand, EFGetCustomerCommand>();
            services.AddTransient<ICreateCustomerCommand, EFCreateCustomerCommand>();
            services.AddTransient<IEditCustomerCommand, EFEditCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, EFDeleteCustomerCommand>();
            //Products
            services.AddTransient<IGetProductsCommand, EFGetProductsCommand>();
            services.AddTransient<IGetProductCommand, EFGetProductCommand>();
            services.AddTransient<ICreateProductCommand, EFCreateProductCommand>();
            services.AddTransient<IEditProductCommand, EFEditProductCommand>();
            services.AddTransient<IDeleteProductCommand, EFDeleteProductCommand>();
            //Orders
            services.AddTransient<IGetOrdersCommand, EFGetOrdersCommand>();
            services.AddTransient<IGetOrderCommand, EFGetOrderCommand>();
            services.AddTransient<ICreateOrderCommand, EFCreateOrderCommand>();
            services.AddTransient<IEditOrderCommand, EFEditOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, EFDeleteOrderCommand>();
            //OrderDetails
            services.AddTransient<IGetOrderDetailsCommand, EFGetOrderDetailsCommand>();
            services.AddTransient<IGetOrderDetailCommand, EFGetOrderDetailCommand>();
            services.AddTransient<ICreateOrderDetailCommand, EFCreateOrderDetailCommand>();
            services.AddTransient<IEditOrderDetailCommand, EFEditOrderDetailCommand>();
            services.AddTransient<IDeleteOrderDetailCommand, EFDeleteOrderDetailCommand>();
            //Employees
            services.AddTransient<IGetEmployeesCommand, EFGetEmployeesCommand>();
            services.AddTransient<IGetEmployeeCommand, EFGetEmployeeCommand>();
            services.AddTransient<ICreateEmployeeCommand, EFCreateEmployeeCommand>();
            services.AddTransient<IEditEmployeeCommand, EFEditEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, EFDeleteEmployeeCommand>();
            //Email
            var section = Configuration.GetSection("Email");
            var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromAddress"], section["password"]);
            services.AddSingleton<IEmailSending>(sender);
            //swagger
            // Register the Swagger generator, defining 1 or more Swagger documents
            // Register the Swagger generator, defining 1 or more Swagger documents
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {   Title = "ProdajaSladoleda",
                    Version = "v1"
                });
            });

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProdajaSladoleda V1");
            });

            app.UseMvc();
        }
    }
}
