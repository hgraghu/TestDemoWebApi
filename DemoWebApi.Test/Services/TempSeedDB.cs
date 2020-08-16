using DemoWebApi.Models;
using DemoWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Test.Services
{
    public static class TempSeedDB
    {
        // Seeding the database with test data
        public static async Task SeedDb(ApplicationDBContext context)
        {
            var category1 = new Category
            {
                Name = "Non Veg"
            };
            var category2 = new Category
            {
                Name = "Veg"
            };
            context.Category.Add(category1);
            context.Category.Add(category2);

            var subCategory1 = new SubCategory
            {
                Name = "Fruits",
                CategoryId = 2,// create foreign key relation and them pass the category2

            };
            var subCategory2 = new SubCategory
            {
                Name = "Chicken",
                CategoryId = 1,// create foreign key relation and them pass the category1
            };
            context.SubCategory.Add(subCategory1);
            context.SubCategory.Add(subCategory2);

            var item1 = new Item
            {
                Name = "FruitSalad",
                Description = "A mix of Fruit",
                SubCategoryId = 1,// create foreign key relation and them pass the subcategory1
            };
            var item2 = new Item
            {
                Name = "ChickenDish",
                Description = "Chicken Kabab",
                SubCategoryId = 2,// create foreign key relation and them pass the subcategory2
            };
            context.Item.Add(item1);
            context.Item.Add(item2);
            await context.SaveChangesAsync();
        }
    }
}
