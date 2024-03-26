using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingPleasure.Abstractions.Application.Services;
using ReadingPleasure.Abstractions.Application;
using ReadingPleasure.Application.Authorization.Handlers;
using ReadingPleasure.Application.Authorization.Policies;
using ReadingPleasure.Application.MappingProfiles;
using ReadingPleasure.Application.Services;
using ReadingPleasure.Application.Utility;
using ReadingPleasure.Common.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Azure.Storage.Blobs;

namespace ReadingPleasure.Application
{
    public static class DependencyRegistrar
    {
        public static void ConfigureApplicationLayerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureServices();
            services.ConfigureAutomapper();
            services.ConfigureJwtAuthentication(configuration);
            services.ConfigureOptions();
            services.ConfigureAuthorizationHandlers();
            services.AddContextAccessor();
            services.ConfigureAzureBlobServiceClient(configuration);
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            {
                services.AddScoped<IGenreService, GenreService>();
                services.AddScoped<IReaderService, ReaderService>();
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IJwtService, JwtService>();
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IAuthorService, AuthorService>();
                services.AddScoped<IBookService, BookService>();
                services.AddScoped<IReviewService, ReviewService>();
                services.AddScoped<IEditionService, EditionService>();
                services.AddScoped<IPublishingHouseService, PublishingHouseService>();
                services.AddScoped<IStorageService, AzureBlobStorageService>();
            }
        }

        private static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMappingProfile).Assembly);
            services.AddAutoMapper(typeof(AuthMappingProfile).Assembly);
            services.AddAutoMapper(typeof(AuthorMappingProfile).Assembly);
            services.AddAutoMapper(typeof(BookMappingProfile).Assembly);
            services.AddAutoMapper(typeof(EditionMappingProfile).Assembly);
            services.AddAutoMapper(typeof(GenreMappingProfile).Assembly);
            services.AddAutoMapper(typeof(PublishingHouseMappingProfile).Assembly);
            services.AddAutoMapper(typeof(ReaderMappingProfile).Assembly);
            services.AddAutoMapper(typeof(ReviewMappingProfile).Assembly);
            services.AddAutoMapper(typeof(RoleMappingProfile).Assembly);
        }

        private static void AddContextAccessor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IContextAccessor, ContextAccessor>();
        }

        private static void ConfigureJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var validIssuer = configuration["JwtSettings:Issuer"];
                    var validAudience = configuration["JwtSettings:Audience"];
                    var secret = configuration["JwtSettings:Secret"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = validIssuer,
                        ValidAudience = validAudience,
                        IssuerSigningKey = new SymmetricSecurityKey
                            (Encoding.UTF8.GetBytes(secret)),
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            Console.WriteLine(context.Exception);
                            return Task.CompletedTask;
                        },
                    };
                });
        }

        private static void ConfigureOptions(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
        }

        private static void ConfigureAuthorizationHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        }

        private static void ConfigureAzureBlobServiceClient(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(_ => new BlobServiceClient(configuration.GetSection("Azure:Blob:ConnectionString").Value));
        }
    }
}
