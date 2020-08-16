using System;
using System.Collections.Generic;
using DemoWebApi.ViewModel;

namespace DemoWebApi.Interface
{
    public interface IItem
    {
        List<ItemViewModel> ItemsByName(string Item, int PageNumber, int PageSize);
    }
}
