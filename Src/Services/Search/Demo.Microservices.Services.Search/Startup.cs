using System;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using Demo.Microservices.Core.Handlers;
using Demo.Microservices.Services.Search.Model;
using Demo.Microservices.Services.Search.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SolrNet;
namespace Demo.Microservices.Services.Search
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
           var solrUrl= Configuration.GetValue<string>("SolrUri");
           services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
            var authenticationBytes = Encoding.ASCII.GetBytes("admin:b");
            var solrOptions = new Action<SolrNetOptions>(k => k.HttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authenticationBytes))
            );

            services.AddSolrNet("http://localhost:8081/solr/films/select?q=*%3A*", solrOptions);


            services.AddSolrNet<SolrNewsItem>("http://localhost:8081/solr/films/select?q=*%3A*",solrOptions);
            
           
            services.AddScoped<Messages>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<ISearchService, SearchService>();
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

            app.UseHttpsRedirection();
            app.UseMvc();

          
        }
    }
}
