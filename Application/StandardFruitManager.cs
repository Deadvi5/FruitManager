using FruitManager.Application.Abstraction;
using FruitManager.Application.Abstraction.Model;
using FruitManager.DataAccessLayer.Abstraction;
using FruitManager.DataAccessLayer.Abstraction.Model;
using System;
using System.Linq;

namespace FruitManager.Application
{
    public class StandardFruitManager : IFruitManager
    {
        private readonly IFruitDataBuilder fruitDataBuilder;

        public StandardFruitManager(IFruitDataBuilder fruitDataBuilder)
        {
            this.fruitDataBuilder = fruitDataBuilder;
        }

        public Fruit GetFruitByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            FruitDTO response = fruitDataBuilder.GetFruits().FirstOrDefault(f => f.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            
            if (response is null)
                return null;

            return new Fruit { Name = response.Name, Description = response.Description, Price = response.Price, Quantity = response.Quantity };
        }
    }
}
