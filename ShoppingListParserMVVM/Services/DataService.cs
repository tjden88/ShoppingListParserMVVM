using ShoppingListParserMVVM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using ShoppingListParserMVVM.Models;

namespace ShoppingListParserMVVM.Services
{
    internal class DataService : IDataService
    {
        public IEnumerable<Element> GetElements(string FileName)
        {
            DataTable table = new("ТекущиеЗакупки");
            table.ReadXml(FileName);

            foreach (DataRow row in table.Rows)
            {
                Element element = new()
                {
                    Name = row["Наименование"].ToString(),
                    Price = (double)row["Цена"],
                    Count= (double)row["Кол-во"],
                    Order = row["Заказ"].ToString(),
                    Сontractor = row["Поставщик"].ToString()
                };
                yield return element;
            }
        }
    }
}
