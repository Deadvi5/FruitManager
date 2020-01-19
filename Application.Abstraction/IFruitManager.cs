using FruitManager.Application.Abstraction.Model;
using System.Collections.Generic;

namespace FruitManager.Application.Abstraction
{
    public interface IFruitManager
    {
        IEnumerable<FruitModel> GetFruits();
        FruitModel GetFruitByName(string name);
    }
}
