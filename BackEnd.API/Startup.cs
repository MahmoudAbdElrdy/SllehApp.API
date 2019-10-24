﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Services;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace BackEnd.API
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
     services.AddMvc(config => {
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
         .AddJsonOptions(options => {
             options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
             options.SerializerSettings.Formatting = Formatting.Indented;
             options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
             options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
         });
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
       
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    {
                        options.User.RequireUniqueEmail = false;
                    })
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });
            services.AddSwaggerGen(c => {
                c.ResolveConflictingActions(x => x.First());
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
            });
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
           services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<IApplicationUserServices,ApplicationUserServices>().Reverse();
            //services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
         
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
           
            ////using (var scope = app.ApplicationServices.CreateScope())
            ////{
            ////    //Resolve ASP .NET Core Identity with DI help
            ////    var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
            ////    // do you things here
            ////}
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", " Auditor V1");
            });
          
            app.UseMvc();
            

        }
    }
}