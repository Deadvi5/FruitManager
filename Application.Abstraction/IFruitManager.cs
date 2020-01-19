using FruitManager.Application.Abstraction.Model;

namespace FruitManager.Application.Abstraction
{
    public interface IFruitManager
    {
        Fruit GetFruitByName(string name);
    }
}
