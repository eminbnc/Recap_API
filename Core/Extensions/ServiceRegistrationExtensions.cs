using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Core.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
          
        }
    }
}
