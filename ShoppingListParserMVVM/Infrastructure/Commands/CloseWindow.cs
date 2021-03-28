using ShoppingListParserMVVM.Infrastructure.Commands.Base;
using System;
using System.Windows;

namespace ShoppingListParserMVVM.Infrastructure.Commands
{
    class CloseWindow : BaseCommand
    {

        private static Window GetWindow(object p) => p as Window ?? App.ActiveWindow;

        protected override bool CanExecute(object p) => GetWindow(p) != null;

        protected override void Execute(object p) => GetWindow(p)?.Close();
    }
}
