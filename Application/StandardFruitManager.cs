using AutoMapper;
using FruitManager.Application.Abstraction;
using FruitManager.Application.Abstraction.Model;
using FruitManager.DataAccessLayer.Abstraction;
using FruitManager.DataAccessLayer.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitManager.Application
{
    public class StandardFruitManager : IFruitManager
    {
        private readonly IFruitDataBuilder fruitDataBuilder;
        private readonly IMapper mapper;

        public StandardFruitManager(IFruitDataBuilder fruitDataBuilder, IMapper mapper)
        {
            this.fruitDataBuilder = fruitDataBuilder;
            this.mapper = mapper;
        }

        public IEnumerable<FruitModel> GetFruits()
        {
            FruitDTO[] response = fruitDataBuilder.GetFruits()?.ToArray();

            if (response is null)
                return null;

            return mapper.Map<IEnumerable<FruitDTO>, IEnumerable<FruitModel>>(response);
        }

        public FruitModel GetFruitByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            FruitDTO response = fruitDataBuilder.GetFruits()?.FirstOrDefault(f => f.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            if (response is null)
                return null;

            return new FruitModel { Name = response.Name, Description = response.Description, Price = response.Price, Quantity = response.Quantity };
        }
    }
}
