using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingPleasure.Abstractions.Infrastructure;
using ReadingPleasure.Domain.Entities;
using ReadingPleasure.Infrastructure.Repositories;

namespace ReadingPleasure.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static void ConfigureInfrastructureLayerDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.ConfigureIdentity();
            services.ConfigureRepositories();
            services.ConfigureUnitOfWork();
        }

        private static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SqlConnection");
                options.UseSqlServer(connectionString);
            });
        }

        private static void ConfigureIdentity(
            this IServiceCollection services)
        {
            services
                .AddIdentityCore<User>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IEditionRepository, EditionRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPublishingHouseRepository, PublishingHouseRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
