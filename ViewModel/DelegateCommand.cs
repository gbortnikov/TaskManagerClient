using System;
using System.Windows.Input;

namespace TaskManagerClient.ViewModel
{
    class DelegateCommand:ICommand
    {
        private Action<object> execute;     //сама функция для передачи
        private Func<object,bool> canExecute;   // можно ли ее выполнить или нельзя

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute,Func<object,bool> canExecute = null)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
