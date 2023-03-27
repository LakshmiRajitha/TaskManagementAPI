// <copyright file="OAuth2OperationFilter.cs">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagementAPI
{
    /// <summary>
    /// OAuth 2 Operation Filter.
    /// </summary>
    public class OAuth2OperationFilter : IOperationFilter
    {
        /// <summary>
        /// Apply.
        /// </summary>
        /// <param name="operation">operation.</param>
        /// <param name="context">context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isAuthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true)).OfType<AuthorizeAttribute>().Any();

            if (!isAuthorized)
            {
                return;
            }

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            var oauth2SecurityScheme = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "OAuth2" },
            };

            operation.Security.Add(new OpenApiSecurityRequirement()
            {
                [oauth2SecurityScheme] = new[] { "API" }, // 'API' is scope here
            });
        }
    }
}
