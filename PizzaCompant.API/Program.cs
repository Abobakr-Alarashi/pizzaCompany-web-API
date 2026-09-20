using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Application.IService;
using Application.ServiceImpl;
using Domain.IRepository;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        var configuration = context.Configuration;

                        // 1. DbContext
                        services.AddDbContext<AppDbContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                        // 2. DI Repositories
                        services.AddScoped<ICategoryRepository, CategoryRepository>();
                        services.AddScoped<ICustomerRepository, CustomerRepository>();
                        services.AddScoped<IItemToppingRepository,ItemToppingRepository>();
                        services.AddScoped<IOrderRepository, OrderRepository>();
                        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
                        services.AddScoped<IPizzaRepository, pizzaRepository>();
                        services.AddScoped<IPizzaToppingRepository, PizzaToppingRepository>();
                        services.AddScoped<IToppingRepository, ToppingRepository>();

                        // 3. DI Services
                       services.AddScoped<ICategoryService, CategoryServiceImpl>();
                        services.AddScoped<ICustomerService, CustomerServiceImpl>();
                        services.AddScoped<IItemToppingService,ItemToppingServiceImpl>();
                        services.AddScoped<IOrderService, OrderServiceImpl>();
                        services.AddScoped<IOrderItemService, OrderItemServiceImpl>();
                        services.AddScoped<IPizzaService, PizzaServiceImpl>();
                        services.AddScoped<IPizzaToppingService, PizzaToppingServiceImpl>();
                        services.AddScoped<IToppingService, ToppingServiceImpl>();

                        // 4. AutoMapper 
                        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                        // 5. Controllers
                        services.AddControllers();

                        // 6. Swagger Config 
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza Company", Version = "v1" });
                        });
                    });

                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        // Configure pipeline
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        // Swagger Middleware
                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Company");
                        });

                        app.UseHttpsRedirection();

                        // Required in .NET 5 for Routing and Endpoints
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
