﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Microservices.Core.Provider;
using Demo.Microservices.Services.NewsService.Entities;
using Demo.Microservices.Services.NewsService.Handlers;
using Demo.Microservices.Services.NewsService.Providers;
using Demo.Microservices.Services.NewsService.Providers;
using Demo.Microservices.Services.NewsService.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<NewsDbContext>(options =>
       options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           
            services.AddScoped<Messages>();

            
            services.AddScoped<IEntityProvider<News>, NewsEFProvider>();
            services.AddScoped<INewsService, Demo.Microservices.Services.NewsService.Service.NewsService>();
            //services. AddScoped<IQueryHandler<GetNewsQuery, Entities.News>, GetNewsQueryHandler>();
          //  services.AddHandlers();
            // services.AddScoped<INewsRepository, NewsProvider>();
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
            app.UseMvc();

        }
    }
}
