using System.Collections.ObjectModel;
using System.Windows.Input;
using ShoppingListParserMVVM.Infrastructure.Commands.Base;
using ShoppingListParserMVVM.Models;
using ShoppingListParserMVVM.Models.Test;
using ShoppingListParserMVVM.Services.Interfaces;
using ShoppingListParserMVVM.ViewModels.Base;

namespace ShoppingListParserMVVM.ViewModels
{
    internal class MainWindowViewModel : WindowViewModel
    {
        #region Commands

        #region Command GetDataCommand - Получить данные

        private ICommand _GetDataCommand;

        /// <summary>Получить данные</summary>
        public ICommand GetDataCommand => _GetDataCommand
            ??= new Command(OnGetDataCommandExecuted, CanGetDataCommandExecute);

        private bool CanGetDataCommandExecute() => true;

        private void OnGetDataCommandExecuted()
        {
            DataCollection = new ObservableCollection<Element>(_dataService.GetElements(FileName));
        }

        #endregion

        #endregion

        #region FileName : string - Имя файла с данными

        //private string _FileName = @"D:\YandexDisk\БД Программа\Заказы\CurrentZakup.xml";
        private string _FileName = "CurrentZakup.xml";

        /// <summary>Имя файла с данными</summary>
        public string FileName
        {
            get => _FileName;
            set => Set(ref _FileName, value);
        }

        #endregion

        #region DataCollection : ObservableCollection<Element> - Данные элементов

        private ObservableCollection<Element> _DataCollection;

        /// <summary>Данные элементов</summary>
        public ObservableCollection<Element> DataCollection
        {
            get => _DataCollection;
            private set => Set(ref _DataCollection, value);
        }

        #endregion

        private readonly IDataService _dataService;

        public MainWindowViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Title = "Парсер списка покупок";
            //OnGetDataCommandExecuted();
            if (App.IsDesignTime)
            {
                DataCollection = new ObservableCollection<Element>(TestDataGenerator.GetTestElements(100));
            }
                

        }
    }
}
