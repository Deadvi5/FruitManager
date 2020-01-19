using FruitManager.DataAccessLayer.Abstraction.Model;
using System.Collections.Generic;

namespace FruitManager.DataAccessLayer.Abstraction
{
    public interface IFruitDataBuilder
    {
        IList<FruitDTO> GetFruits();
    }
}
