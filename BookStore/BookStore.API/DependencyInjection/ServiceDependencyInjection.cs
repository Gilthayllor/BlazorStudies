using BookStore.API.Contracts.Services;
using BookStore.API.Implementations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.API.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection ConfigureServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IUserservice, UserService>();

            return services;
        }
    }
}
