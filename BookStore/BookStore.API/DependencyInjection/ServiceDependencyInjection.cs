using BookStore.API.Contracts.Services;
using BookStore.API.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection ConfigureServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            //services.AddScoped<IAuthorRepository, AuthorRepository>();
            //services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
