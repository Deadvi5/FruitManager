using AutoMapper;
using FruitManager.Application.Abstraction.Model;
using FruitManager.DataAccessLayer.Abstraction.Model;

namespace FruitManager.Application.Mapping
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<FruitDTO, FruitModel>();
        }
    }
}
