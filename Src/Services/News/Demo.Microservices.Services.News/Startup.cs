using AutoMapper;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Core.Middleware;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.Entities;
using Demo.Microservices.Services.NewsService.Providers;
using Demo.Microservices.Services.NewsService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Microservices.Services.NewsService
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
            services.AddMemoryCache();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<NewsDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           
            services.AddScoped<Messages>();

            
            services.AddScoped<IEntityProvider<News>, NewsEFProvider>();
            services.AddScoped<INewsService, Demo.Microservices.Services.NewsService.Service.NewsService>();
                      services.AddHandlers();
           
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
            app.UseMiddleware<ExceptionHandler>();
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
