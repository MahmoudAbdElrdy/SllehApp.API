﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd.Repositories.Generics;
using BackEnd.Repositories.UOW;
using BackEnd.Service.IServices;
using BackEnd.Service.Mapper;
using BackEnd.Service.Models;
using BackEnd.Service.Services;
//using DAL;
//using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;

using BackEnd.DAL.Models;

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
            // services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddMvc(config => {
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
         .AddJsonOptions(options => {
             options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ssZ";
             options.SerializerSettings.Formatting = Formatting.Indented;
             options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
             options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             var resolver = options.SerializerSettings.ContractResolver;
             if (resolver != null)
                 (resolver as DefaultContractResolver).NamingStrategy = null;

         });
            services.AddDbContext<DB_A57576_SllehAppContext>(options =>
                    options.UseLazyLoadingProxies(false)
                    .UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            //        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //                {
            //                    options.User.RequireUniqueEmail = false;
            //                })
            //.AddEntityFrameworkStores<DB_A56457_LookandGoContext>()
            //.AddDefaultTokenProviders()
            //.AddDefaultUI();
            //        services.Configure<IdentityOptions>(options =>
            //        {
            //            options.Password.RequireDigit = false;
            //            options.Password.RequireNonAlphanumeric = false;
            //            options.Password.RequireLowercase = false;
            //            options.Password.RequireUppercase = false;
            //            options.Password.RequiredLength = 4;
            //        });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AspNetCoreApiStarter", Version = "v1" });
                // Swagger 2.+ support
                //              c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                //              {
                //                  In = "header",
                //                  Description = "Please insert JWT with Bearer into field",
                //                  Name = "Authorization",
                //                  Type = "apiKey"
                //              });

                //              c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //  { "Bearer", new string[] { } }
                //});
            });
            //services.AddSwaggerGen(c => {
            //    c.ResolveConflictingActions(x => x.First());
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "Test API",
            //        Description = "ASP.NET Core Web API"
            //    });
            //});
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            //services.AddScoped<UserManager<ApplicationUser>, UserManager<ApplicationUser>>();
            //services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddScoped<IServicesAdminUsers, AdminUsersServices>().Reverse();
            services.AddScoped<IServicesWorkshop, WorkshopServices>().Reverse();
            services.AddScoped<IServicesCustomer, CustomerServices>().Reverse();
            services.AddScoped<IServicesOrder, OrderServices>().Reverse();
            services.AddScoped<IServicesCustomerNotifications, CustomerNotificationsServices>().Reverse();
            services.AddScoped<IServicesWorkshopNotifications, WorkshopNotificationsServices>().Reverse();
            services.AddScoped<IServicesCountry, CountryServices>().Reverse();
            services.AddScoped<IServicesCity, CityServices>().Reverse();
            services.AddScoped<IServicesCar, CarServices>().Reverse();
            
            services.AddScoped<IResponseDTO, ResponseDTO>().Reverse();
            //
            // services.AddScoped<IDepartmentServices,DepartmentServices>().Reverse();

            // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            // JWT Authentication 

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                };
            }
            );

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
            app.UseCors("CorsPolicy");
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " Auditor V1");

            });
            //app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"UploadFiles")),
            //    RequestPath = new PathString("/UploadFiles")
            //});
            app.UseAuthentication();
            app.UseMvc();


        }
    }
}
