using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.Reporting.Graphite.Client;
using App.Metrics.Scheduling;
using AutoMapper;
using Domain.Entity;
using FluentValidation.AspNetCore;
using Infrastructure.Interface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface;
using Repository.Repository;
using WebService.FluentValidations;
using WebService.Mappers;

namespace WebService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(opts =>
            {
                opts.UseLazyLoadingProxies().UseNpgsql(Environment.GetEnvironmentVariable("MAIN_CONNECTION_STRING") ?? Configuration.GetConnectionString("ApplicationConnection"));
            });

            //Repository
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IPaymentTypeService, PaymentTypeService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ITransferService, TransferService>();
            services.AddScoped<IPointOfSaleService, PointOfSaleService>();
            
            //Infrastructure
            services.AddScoped<IFileService, FileService>();
            
            var metrics = new MetricsBuilder()
                .Report.ToGraphite(
                    options => {
                        options.Graphite.BaseUri = new Uri("net.tcp://localhost:2003");
                        options.ClientPolicy.BackoffPeriod = TimeSpan.FromSeconds(30);
                        options.ClientPolicy.FailuresBeforeBackoff = 5;
                        options.ClientPolicy.Timeout = TimeSpan.FromSeconds(10);
                        options.FlushInterval = TimeSpan.FromSeconds(20);
                    })
                .Build();

            services.AddMetrics(metrics);
            services.AddMetricsReportingHostedService();
            
            var scheduler = new AppMetricsTaskScheduler(
                TimeSpan.FromMilliseconds(500),
                async () =>
                {
                    await Task.WhenAll(metrics.ReportRunner.RunAllAsync());
                });
            scheduler.Start();
            
            services
                .AddIdentity<ApplicationUser, IdentityRole>(opts =>
                {
                    opts.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddAutoMapper(Assembly.GetAssembly(typeof(EventProfile)));

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(opts =>
                {
                    opts.RegisterValidatorsFromAssemblyContaining<CreateEventViewModelValidation>();
                    opts.LocalizationEnabled = true;
                })
                .AddMetrics();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseMetricsAllMiddleware();
            
            UpdateDatabase(app);
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}