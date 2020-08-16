using System;
using System.Collections.Generic;
using System.Text;
using DemoWebApi.Models;
namespace DemoWebApi.Interface
{
    public interface ICategory
    {
        bool DeleteCategory(string CategoryName);
    }
}
