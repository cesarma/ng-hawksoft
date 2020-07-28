using HawkSoftContacts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace HawkSoftContactListAngular
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string AllowAllCors = "AllowAll";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddDbContext<DataContext>(opt =>
            opt.UseSqlServer(Configuration["ConnectionString:HawkSoftContacts"], b => b.MigrationsAssembly("HawkSoftContactListAngular")));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Hawksoft Info Service API",
                    Version = "v2",
                    Description = "Sample service for Learner",
                });
            });
            // services.AddSwaggerDocument();

            services.AddControllersWithViews();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

          services.AddCors(options =>
                 {
                     options.AddPolicy(AllowAllCors,
                                       builder =>
                                       {
                                           builder.AllowAnyHeader();
                                           builder.AllowAnyMethod();
                                           builder.AllowAnyOrigin();
                                       });
                 });

            /*services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My First Swagger" });
            });*/
           /*    services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new Info { Title = "Values Api", Version = "v1" });
              });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // IApplicationBuilder applicationBuilder = app.UseSwagger();
                //   app.UseSwaggerUi3();
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "PlaceInfo Services"));
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            /*app.UseStaticFiles(new StaticFileOptions
            {
            FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
            System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Swagger")),
                RequestPath = "/Swagger"
            });*/
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });


            //app.UseSwagger();
         //   app.UseOpenApi();
          //  app.UseSwaggerUi3();

            // app.UseSwagger(options =>
            // {
            //   options.RouteTemplate = "api/{documentName}/swagger.json";
            // });

            // app.UseSwaggerUI(c =>
            // {
            //  string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            // c.RoutePrefix = "api";
            //  c.SwaggerEndpoint("V1/swagger.json", "Services Api");                

            //});

            /*  app.UseSwaggerUI(c =>
             {
                 string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                 var apiVersionDescriptionProvider = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

                 foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                 {
                     c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                 }
             });

              */
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Api"));

            app.MapWhen(r => !r.Request.Path.Value.StartsWith("/swagger"), builder => 
            {
                builder.UseMvc(routes =>
                {
                    routes.MapSpaFallbackRoute(
                        name: "spa-fallback",
                        defaults: new { controller = "Home", action = "Index" });
                });
            });
        }
    }
}
