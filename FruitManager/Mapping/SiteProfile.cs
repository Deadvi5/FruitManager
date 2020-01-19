using AutoMapper;
using FruitManager.Application.Abstraction.Model;
using FruitManager.Models;

namespace FruitManager.Mapping
{
    public class SiteProfile : Profile
    {
        public SiteProfile()
        {
            CreateMap<FruitModel, FruitViewModel>();
        }
    }
}
