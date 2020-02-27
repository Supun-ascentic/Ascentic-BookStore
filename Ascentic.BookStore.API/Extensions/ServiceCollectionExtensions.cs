using Ascentic.BookStore.Application.Applications;
using Ascentic.BookStore.Application.Interfaces;
using Ascentic.BookStore.Domain.Domain;
using Ascentic.BookStore.Domain.Interfaces;
using Ascentic.BookStore.Infrastructure.DbContext;
using Ascentic.BookStore.Infrastructure.Interfaces;
using Ascentic.BookStore.Infrastructure.Repository;
using Ascentic.BookStore.Infrastructure.UnitOfWork;
using Ascentic.BookStore.Model.DTO;
using Ascentic.BookStore.Model.Entity;
using Ascentic.BookStore.Model.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ascentic.BookStore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Add your own custom services here
            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRatingRepository,RatingRepository>();

            services.AddScoped<IBookDomain,BookDomain>();
            services.AddScoped<IAuthorDomain,AuthorDomain>();
            services.AddScoped<ICategoryDomain,CategoryDomain>();
            services.AddScoped<IRatingDomain,RatingDomain>();

         
            services.AddScoped<IBookApplication,BookApplication>();
            services.AddScoped<IAuthorApplication,AuthorApplication>();
            services.AddScoped<IRatingApplication,RatingApplication>();
            services.AddScoped<ICategoryApplication,CategoryApplication>();



            // Singleton - Only one instance is ever created and returned.
            // services.AddSingleton<IExampleService, ExampleService>();

            // Scoped - A new instance is created and returned for each request/response cycle.
            // services.AddScoped<IExampleService, ExampleService>();

            // Transient - A new instance is created and returned each time.
            // services.AddTransient<IExampleService, ExampleService>();
            return services;
        }

    }
}
