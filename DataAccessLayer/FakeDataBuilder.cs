using FruitManager.DataAccessLayer.Abstraction;
using FruitManager.DataAccessLayer.Abstraction.Model;
using System.Collections.Generic;

namespace FruitManager.DataAccessLayer
{
    public class FakeDataBuilder : IFruitDataBuilder
    {
        public IList<FruitDTO> GetFruits()
        {
            return new List<FruitDTO>
            {
                new FruitDTO { Name = "Apple", Description= "Golden", Price=decimal.MaxValue,Quantity=2},
                new FruitDTO { Name = "Banana", Description= "Chiquita", Price=decimal.MaxValue,Quantity=4}
            };
        }
    }
}
