using ECommerce.Domain.Contexts;
using ECommerce.Shared.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System.Reflection;

namespace ECommerce.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EcommerceConnectionString")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSwaggerGen();

            var types = typeof(IBaseValidator).Assembly.GetTypes().Where(t => t.GetTypeInfo().ImplementedInterfaces.Any(x => x.Name == typeof(IBaseValidator).Name)).ToList();

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
                })
                .AddFluentValidation(fv =>
                {

                    foreach (var type in types)
                    {
                        fv.RegisterValidatorsFromAssemblyContaining(type);
                    }
                })
                .AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });


            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IValidatorInterceptor, ValidationHandling>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var service = app.ApplicationServices.GetRequiredService<ECommerceContext>())
            {
                service.Database.Migrate();
            }

            string[] corsDomains = Configuration["CorsDomains:Domains"].Split(",");

            app.UseCors(options => options.WithOrigins(corsDomains).AllowAnyMethod().AllowAnyHeader());

            AutoMigrationDb(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.ConfigureExceptionHandlerMiddleware();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AutoMigrationDb(IApplicationBuilder app)
        {
            bool.TryParse(Configuration["ApiParameters:AutoMigrateDb"], out bool autoMigrateDb);

            if (autoMigrateDb)
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<ECommerceContext>();
                    context.Database.SetCommandTimeout(int.MaxValue);
                    context.Database.EnsureCreated();
                    context.Database.Migrate();
                }
            }
        }
    }
}
