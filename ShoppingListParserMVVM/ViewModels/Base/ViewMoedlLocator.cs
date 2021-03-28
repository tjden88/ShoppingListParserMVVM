using Microsoft.Extensions.DependencyInjection;

namespace ShoppingListParserMVVM.ViewModels.Base
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
