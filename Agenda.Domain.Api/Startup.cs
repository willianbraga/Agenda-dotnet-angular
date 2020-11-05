using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Agenda.Domain.Handlers;
using Agenda.Domain.Infra.Contexts;
using Agenda.Domain.Infra.Repositories;
using Agenda.Domain.Repositories;

namespace Agenda.Domain.Api
{
#pragma warning disable 1591
    public class Startup
    {

        private const string SWAGGERFILE_PATH = "./swagger/v1/swagger.json";
        private const string API_VERSION = "v1";
        private const string SETTINGS_SECTION = "Settings";
        private const string API_CHECK_KEY = "API";
        private const string PROJECT_NAME = "API Teste";
        private const string XML_EXTENSION = ".xml";
        private const string SECURITY_TYPE = "Bearer";
        private const string SECURITY_NAME = "Authorization";
        private const string SECURITY_DESCRIPTION = "Authorization Key header using the scheme. Example: \"Bearer {token}\"";
        private const string SECURITY_SCHEME = "oauth2";


        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("connectionString")));
            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<AgendaHandler, AgendaHandler>();
            AddSwagger(services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                   {
                       opt.Authority = "https://securetoken.google.com/agenda-will";
                       opt.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidIssuer = "https://securetoken.google.com/agenda-will",
                           ValidateAudience = true,
                           ValidAudience = "agenda-will",
                           ValidateLifetime = true
                       };
                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger
            app.UseSwagger()
               .UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;
                    c.SwaggerEndpoint(SWAGGERFILE_PATH, PROJECT_NAME + API_VERSION);
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = PROJECT_NAME, Version = API_VERSION });
                c.AddSecurityDefinition(SECURITY_TYPE, new OpenApiSecurityScheme
                {
                    Description = SECURITY_DESCRIPTION,
                    In = ParameterLocation.Header,
                    Name = SECURITY_NAME,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SECURITY_TYPE
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SECURITY_TYPE
                            },
                            Scheme = SECURITY_SCHEME,
                            Name = SECURITY_TYPE,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
