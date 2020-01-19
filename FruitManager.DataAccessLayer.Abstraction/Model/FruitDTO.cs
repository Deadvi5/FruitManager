using System;
using System.Collections.Generic;
using System.Text;

namespace FruitManager.DataAccessLayer.Abstraction.Model
{
    public class FruitDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
