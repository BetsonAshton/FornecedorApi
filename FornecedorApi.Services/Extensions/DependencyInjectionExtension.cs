using FornecedorApi.Application.Interfaces;
using FornecedorApi.Application.Services;
using FornecedorApi.Domain.Interfaces.Repositories;
using FornecedorApi.Domain.Interfaces.Services;
using FornecedorApi.Domain.Services;
using FornecedorApi.Infra.Data.Repositories;

namespace FornecedorApi.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IFornecedorAppService, FornecedorAppService>();
            services.AddTransient<IEnderecoAppService, EnderecoAppService>();
            services.AddTransient<IFornecedorDomainService, FornecedorDomainService>();
            services.AddTransient<IEnderecoDomainService, EnderecoDomainService>();
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();


            return services;
        }
    }
}
