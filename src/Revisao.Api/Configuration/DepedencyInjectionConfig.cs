using Revisao.Api.Extensions;
using Revisao.Business.Intefaces;
using Revisao.Business.Interfaces;
using Revisao.Business.Notificacoes;
using Revisao.Business.Services;
using Revisao.Data.context.RevisaoData;
using Revisao.Data.repository;

namespace Revisao.Api.Configuration
{
    public static class DepedencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;

        }
    }
}
