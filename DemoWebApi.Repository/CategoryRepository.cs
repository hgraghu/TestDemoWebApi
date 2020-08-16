using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DemoWebApi.Interface;

namespace DemoWebApi.Repository
{
    public class CategoryRepository: ICategory
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool DeleteCategory(string CategoryName)
        {
            var data = (from c in _context.Category
                           where c.Name.ToLower() == CategoryName.ToLower()
                        select c).FirstOrDefault();

            if (data != null)//check if Category exists
            {
                var Subdata = (from s in _context.SubCategory//check if Subcategory exists the dont delete
                            where s.Id == data.Id
                            select s).FirstOrDefault();

                if (Subdata != null)
                {
                    return false;
                }
                else
                {
                    _context.Category.Remove(data);
                    var result = _context.SaveChanges();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }
}
