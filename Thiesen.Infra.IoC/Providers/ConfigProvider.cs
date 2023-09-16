using Microsoft.Extensions.DependencyInjection;
using Thiesen.Application.Commands.CreatePessoaFisica;
using Thiesen.Domain.Services;
using Thiesen.Infra.Data.AuthService;
using Thiesen.Infra.Data.UnitOfWork;

namespace Thiesen.Infra.IoC.Providers
{
    public static class ConfigProvider
    {
        public static IServiceCollection AddConfig(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddMediatR();

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePessoaFisicaCommand).Assembly));

            return services;
        }
    }
}