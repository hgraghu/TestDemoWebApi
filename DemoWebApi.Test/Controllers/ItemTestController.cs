using DemoWebApi.Controllers;
using DemoWebApi.Interface;
using DemoWebApi.Repository;
using DemoWebApi.Test.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemoWebApi.Test.Controllers
{
    public class ItemTestController : IClassFixture<DbFixture>
    {
        ItemController _itemController;
        private readonly IItem _ItemRepo;
        private readonly DbFixture _dbFixture;
        public ItemTestController(DbFixture dbFixture)
        {
            _dbFixture = dbFixture;
            _ItemRepo = new ItemRepository(_dbFixture.DemoWebDbContext); // intilaizing the repository with db context
            _itemController = new ItemController(_ItemRepo);
        }

        [Fact]
        public async void GetItems()
        {
            var items=_itemController.ItemsByName("FruitSalad");
            Assert.Equal("FruitSalad", items?[0].Name);
        }
    }
}
