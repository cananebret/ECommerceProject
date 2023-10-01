
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.WebApi;
using System.Reflection;

namespace ECommerce.WebApi
{
    public class Program
    {
        private static readonly string ExecutingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

        public static void Main(string[] args)
        {
            try
            {
                var hostBuilder = CreateHostBuilder(Configuration, args);

                var configuredHost = hostBuilder.Build();

                configuredHost.Run();
            }
            catch (Exception ex)
            {


            }
            finally
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
        Host.CreateDefaultBuilder(args)
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacModule());
       })
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseConfiguration(configuration);
           webBuilder.UseStartup<Startup>();
       }).UseServiceProviderFactory(new AutofacServiceProviderFactory());


        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
    }
}




//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();
