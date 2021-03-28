using System;
using System.Threading.Tasks;

namespace ShoppingListParserMVVM.Infrastructure.Commands.Base
{
    internal class CommandAsync : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Predicate<object> _CanExecute;


        public CommandAsync(Action execute, Func<bool> canExecute = null) : this(p => execute(),
            canExecute is null ? null : p => canExecute())
        {
        }

        public CommandAsync(Action<object> execute, Predicate<object> canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        /// <summary>Возможность выполнения команды</summary>
        protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

        /// <summary>Выполнить команду</summary>
        protected override async void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            try
            {
                Executable = false;
                await Task.Run(() => _Execute(parameter));
                Executable = true;
            }
            catch
            {
                Executable = true;
                throw;
            }
        }

    }
}