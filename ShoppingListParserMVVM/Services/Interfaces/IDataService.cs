using System;
using System.Collections.Generic;
using System.Threading;
using ShoppingListParserMVVM.Models;

namespace ShoppingListParserMVVM.Services.Interfaces
{
    interface IDataService
    {
        IEnumerable<Element> GetElements(string FileName);
    }
}
