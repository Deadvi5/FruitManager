using AutoMapper;
using FruitManager.Application.Abstraction.Model;
using FruitManager.DataAccessLayer.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
