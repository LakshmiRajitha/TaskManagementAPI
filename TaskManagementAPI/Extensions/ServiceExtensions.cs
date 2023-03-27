using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TaskManagementAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TaskManagementAPI.Repository.Contracts;
using TaskManagementAPI.Repository;

namespace TaskManagementAPI
{
    /// <summary>
    /// Service Extension class.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configuring Cors policy.
        /// </summary>
        /// <param name="services">services.</param>
        /// <param name="config">config.</param>
        public static void ConfigureCors(this IServiceCollection services, IConfiguration config)
        {
            var corsEnableURIs = config["AppSettings:CorsEnableURIs"].Split(',');
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.WithOrigins(corsEnableURIs)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        /// <summary>
        /// Configuring Repository.
        /// </summary>
        /// <param name="services">services.</param>
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

        /// <summary>
        /// Configure Token Authentication.
        /// </summary>
        /// <param name="services">services.</param>
        public static void ConfigureTokenAuthentication(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(AppData.Jwt.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
        }

        /// <summary>
        /// Configuring Swagger.
        /// </summary>
        /// <param name="services">services.</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<OAuth2OperationFilter>();
                options.DescribeAllParametersInCamelCase();
                options.CustomSchemaIds(x => x.FullName);
                options.SwaggerDoc("v1", CreateOpenApiInfo());
                options.AddSecurityDefinition("OAuth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(AppData.Jwt.TokenUrl),
                            Scopes = new Dictionary<string, string>
                        {
                            { AppData.Jwt.Audience, "Oauth HTTP Api" },
                        },
                        },
                    },
                    Description = "Oauth Security Scheme",
                });

                // Get xml comments path
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        private static OpenApiInfo CreateOpenApiInfo()
        {
            return new OpenApiInfo()
            {
                Title = "Task Management API",
                Version = "v1",
                Description = "Task Management API",
                License = new OpenApiLicense(),
            };
        }
    }
}
