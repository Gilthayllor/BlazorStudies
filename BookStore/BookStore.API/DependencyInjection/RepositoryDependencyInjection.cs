using BookStore.API.Contracts.Repositories;
using BookStore.API.Implementations.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static IServiceCollection ConfigureRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
