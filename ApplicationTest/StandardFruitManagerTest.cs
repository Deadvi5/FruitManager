using FruitManager.Application;
using FruitManager.DataAccessLayer.Abstraction;
using FruitManager.DataAccessLayer.Abstraction.Model;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace ApplicationTest
{
    public class StandardFruitManagerTest
    {
        private readonly IFruitDataBuilder fruitDataBuilder;
        private readonly StandardFruitManager sut;

        public StandardFruitManagerTest()
        {
            fruitDataBuilder = Substitute.For<IFruitDataBuilder>();
            sut = new StandardFruitManager(fruitDataBuilder);

        }

        #region GetFruitByName
        [Fact]
        public void GetFruitByName_should_return_fruit_correctly()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns(BuildFakeFruit());

            //Act
            var response = sut.GetFruitByName("Pippo");

            //Assert
            fruitDataBuilder.Received(1).GetFruits();
            Assert.Equal("pippo", response.Name);
            Assert.Equal("desc pippo", response.Description);
            Assert.Equal(1, response.Quantity);
            Assert.Equal(2, response.Price);

        }

        [Fact]
        public void GetFruitByName_should_return_null_if_fruit_not_found()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns(BuildFakeFruit());

            //Act
            var response = sut.GetFruitByName("amarena");

            //Assert
            Assert.Null(response);
        }

        [Fact]
        public void GetFruitByName_should_throw_exception_if_name_arg_is_null_or_empty()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns(BuildFakeFruit());

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.GetFruitByName(null));
        } 
        #endregion

        #region Private Members
        private IList<FruitDTO> BuildFakeFruit()
        {
            return new List<FruitDTO>()
           {
               new FruitDTO { Name = "pippo", Description="desc pippo", Quantity=1,Price=2},
               new FruitDTO { Name = "minnie", Description="desc minnie", Quantity=2,Price=3},
               new FruitDTO { Name = "topolino", Description="desc topolino", Quantity=3,Price=4}
           };
        }
        #endregion
    }
}
