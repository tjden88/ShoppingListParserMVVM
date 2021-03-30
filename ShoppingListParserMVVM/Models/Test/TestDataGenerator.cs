using System;
using System.Collections.Generic;
using System.Text;
using ShoppingListParserMVVM.Services.Interfaces;

namespace ShoppingListParserMVVM.Models.Test
{
    static class TestDataGenerator
    {
        public static IEnumerable<Element> GetTestElements(int Count)
        {
            var rnd = new Random();
            for (var i = 0; i < Count; i++)
            {
                var e = new Element()
                {
                    Name = "Наименование " + Count % 10,
                    Count = rnd.NextDouble() * 100,
                    Order = (Count % 10).ToString(),
                    Price = rnd.NextDouble() * 1000,
                    Сontractor = "Поставщик " + rnd.Next(4)
                };
                yield return e;
            }

        }
    }
}
