using Microsoft.Extensions.DependencyInjection;
using Thiesen.Domain.Repositories;
using Thiesen.Infra.Data.Repositories;

namespace Thiesen.Infra.IoC.Providers
{
    public static class CadastroProvider
    {
        public static IServiceCollection AddCadastro(this IServiceCollection services)
        {
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}