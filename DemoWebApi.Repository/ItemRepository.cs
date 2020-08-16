using DemoWebApi.Interface;
using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DemoWebApi.ViewModel;
namespace DemoWebApi.Repository
{
    public class ItemRepository : IItem
    {
        private readonly ApplicationDBContext _context;
        public ItemRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<ItemViewModel> ItemsByName(string ItemName, int PageNumber, int PageSize)
        {
            PageNumber = PageNumber < 1 ? 1 : PageNumber;
            PageSize = PageSize < 1 ? 10 : PageSize;
            var result = (from i in _context.Item
                          join s in _context.SubCategory on i.SubCategoryId equals s.Id
                          join c in _context.Category on s.CategoryId equals c.Id
                          where i.Name == (ItemName == "" ? i.Name : ItemName)
                          select new ItemViewModel
                          {
                              Id = i.Id,
                              Name = i.Name,
                              SubCategoryName = s.Name,
                              CategoryName = c.Name,
                              Description = i.Description
                          }).OrderBy(i => i.Id).Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            return result;
        }
    }
}
