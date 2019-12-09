using EHI.Services.API.Middleware;
using EHI.Services.DBModel.Contact;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EHI.Services.Contact.API
{
    public class Startup
    {
        private const string eHI_Connection = "EHI_Connection";
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                           .SetBasePath(env.ContentRootPath)
                           .AddConfiguration(configuration)
                           .Build();
        }

        public static IConfiguration Configuration { get; private set; }

        public static string EHIConnection = "EHI_Connection";

        //This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();            
            services.AddDbContext<EHIDemoContext>(item => item.UseSqlServer(Configuration.GetConnectionString(EHIConnection)));                    
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "EHI Contact API", Version = "v1" });

                var xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Contact.API.xml";
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// <summary>
        /// Configuration method
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="config"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration config)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            string[] CORS = config.GetSection("AppSettings:CORS").Get<string[]>();
            string[] METHODS = config.GetSection("AppSettings:METHODS").Get<string[]>();
            app.UseCors(options => options.WithOrigins(CORS).WithMethods(METHODS).AllowAnyHeader());
            app.UseResponseCompression();
            app.UseExceptionHandlerMiddleware();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseHttpsRedirection();
        }
    }
}
