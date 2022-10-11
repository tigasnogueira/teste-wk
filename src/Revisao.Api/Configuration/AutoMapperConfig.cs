using AutoMapper;
using Revisao.Api.ViewModels;
using Revisao.Business.Models;

namespace Revisao.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<ProdutoViewModel, Produto>();

            

            
        }
    }
}
