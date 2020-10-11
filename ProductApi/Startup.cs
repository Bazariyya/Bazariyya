using Autofac;
using Autofac.Extensions.DependencyInjection;
using EventBus;
using EventBus.Abstractions;
using EventBusKafka;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Product.API.Application.IntegrationEvents;
using Product.API.Application.Queryes.ProductQueryes;
using Product.Domain.AggregatesModel.ProductAggregate;
using Product.Infrastructure;
using Product.Infrastructure.Repositoryes;
using ProductApi.Data;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProductApi
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
            services.Configure<ProductSettings>(Configuration);
            services.AddCustomSwagger(Configuration);
            services.AddControllers();
            services.AddEventBus(Configuration)
                    .AddMediatR(typeof(Startup))
                    .LoadAplicationServices(Configuration);
            

            services.AddDbContext<ProductContext>(options =>
                  {
                      options.UseSqlServer(Configuration["MsSqlConnection"],
                          sqlServerOptionsAction: sqlOptions =>
                          {
                              sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                              sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                          });
                  },
                      ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                  );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "ProductAPI V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=test}/{id?}");
            });
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //Events to be followed will be written
        }
    }

    static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Bazariyya - Ordering HTTP API",
                    Version = "v1",
                    Description = "The Ordering Service HTTP API"
                });

            });

            return services;
        }
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration["SubscriptionClientName"];


            services.AddSingleton<IEventBus, EventBusKafka.EventBusKafka>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<EventBusKafka.EventBusKafka>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new EventBusKafka.EventBusKafka(eventBusSubcriptionsManager, logger, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }

        public static IServiceCollection LoadAplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductQuery, ProductQuery>();
            services.AddScoped<IProductIntegrationEventService, ProductIntegrationEventService>();

            return services;
        }
    }
}
