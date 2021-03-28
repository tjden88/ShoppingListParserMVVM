using System;

namespace ShoppingListParserMVVM.Infrastructure.Commands.Base
{
    internal class Command : BaseCommand
    {
        private readonly Action<object> _Execute;
        private readonly Predicate<object> _CanExecute;


        public Command(Action execute, Func<bool> canExecute = null) : this(p => execute(),
            canExecute is null ? null : p => canExecute())
        {
        }

        public Command(Action<object> execute, Predicate<object> canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        /// <summary>Возможность выполнения команды</summary>
        protected override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

        /// <summary>Выполнить команду</summary>
        protected override void Execute(object p) => _Execute(p);

    }
}
