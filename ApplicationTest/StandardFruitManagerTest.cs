using AutoMapper;
using FruitManager.Application;
using FruitManager.Application.Abstraction.Model;
using FruitManager.Application.Mapping;
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
        #region Members and constructor
        private readonly IFruitDataBuilder fruitDataBuilder;
        private readonly IMapper fakeMapper;
        private readonly StandardFruitManager sut;

        public StandardFruitManagerTest()
        {
            fruitDataBuilder = Substitute.For<IFruitDataBuilder>();
            fakeMapper = CreateFakeMap();
            sut = new StandardFruitManager(fruitDataBuilder, fakeMapper);

        }
        #endregion

        #region GetFruits
        [Fact]
        public void GetFruits_should_return_fruits_correctly()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns(BuildFakeFruit());

            //Act
            var response = sut.GetFruits();

            //Assert
            fruitDataBuilder.Received(1).GetFruits();
            Assert.IsAssignableFrom<IEnumerable<FruitModel>>(response);
        }

        [Fact]
        public void GetFruits_should_return_null_if_no_fruits_are_found()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns((IList<FruitDTO>)null);

            //Act
            var response = sut.GetFruits();

            //Assert
            Assert.Null(response);
        }
        #endregion

        #region GetFruitByName
        [Theory]
        [InlineData("pippo")]
        [InlineData("PiPpo")]
        public void GetFruitByName_should_return_fruit_correctly(string name)
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns(BuildFakeFruit());

            //Act
            var response = sut.GetFruitByName(name);

            //Assert
            fruitDataBuilder.Received(1).GetFruits();
            Assert.Equal("pippo", response.Name);
            Assert.Equal("desc pippo", response.Description);
            Assert.Equal(1, response.Quantity);
            Assert.Equal(2, response.Price);

        }

        [Fact]
        public void GetFruitByName_should_return_null_if_no_fruits_are_returned()
        {
            //Arrange
            fruitDataBuilder.GetFruits().Returns((IList<FruitDTO>)null);

            //Act
            var response = sut.GetFruitByName("pippo");

            //Assert
            Assert.Null(response);
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

        private IMapper CreateFakeMap()
        {
            return new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new ApplicationProfile())));
        }
        #endregion
    }
}
