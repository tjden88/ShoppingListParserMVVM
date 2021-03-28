using ShoppingListParserMVVM.Services.Interfaces;
using ShoppingListParserMVVM.ViewModels.Base;

namespace ShoppingListParserMVVM.ViewModels
{
    internal class MainWindowViewModel : WindowViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IDataService _DataService;

        public MainWindowViewModel(IUserDialog UserDialog, IDataService DataService)
        {
            Title = "Парсер списка покупок";
            _UserDialog = UserDialog;
            _DataService = DataService;
        }
    }
}
