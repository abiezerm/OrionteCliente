using AutoMapper;
using BusinessLayer.Services.Clients;
using BusinessLayer.Services.Users;
using BusinessLayer.Services.Companies;
using DataLayer.DBModels;
using DataLayer.DBModels.DBContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LoanAPI.ProgramConfigurations
{
    public static class ProgramExtension
    {
        public static void AddAutoMapperConfigurations(this IServiceCollection services)
        {
            var user = new User();
            var mapConfig = new MapperConfiguration(options =>
            {
                var mainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(e => e.GetName().Name == "DataLayer");
                options.AddMaps(mainAssembly);
                options.AllowNullCollections = true;
            });
            var mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddAuthenticationConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/oriontek-482c8";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/oriontek-482c8",
                    ValidateAudience = true,
                    ValidAudience = "oriontek-482c8",
                    ValidateLifetime = true
                };
            });
        }
        public static void BuildContext(this IServiceCollection services)
        {
            User user = new();

            services.AddTransient(options =>
            {
                // configuring useful dbcontext
                var builder = new DbContextOptionsBuilder<DbContext>();
                builder.UseSqlServer("Server=localhost;Database=OriontekDB;User Id=sa;Password=reallyStrongPwd123@;");

                var currentSession = options.GetService<IHttpContextAccessor>();

                if (currentSession?.HttpContext is not null)
                {
                    var userId = currentSession.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    // initializing a new dbcontext without filter configurations to get the user in the db
                    using (var context = new ContextDB())
                    {
                        user = context?.Users.IgnoreQueryFilters()
                                                  .FirstOrDefault(u => u.FirebaseId == userId
                                                                    && u.Status == true)!;
                        //&& u.Sucursal != null
                        //&& u.Sucursal.Estado == true);

                        if (user is null)
                        {
                           Console.WriteLine($"{userId}");
                        }
                        context?.Dispose();
                    };
                }
                return new ContextDB(options: builder.Options, currentUser: user!);
            });
        }
        public static void RegisterSerivices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IFirebaseInit, FirebaseInit>();
            services.AddScoped<IFirebaseManager, FirebaseManager>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICurrentSession, CurrentSession>();
            services.AddScoped<ICompanyService, CompanyService>();


        }
    }
}
