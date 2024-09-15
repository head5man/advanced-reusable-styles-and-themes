using System;
using System.Windows.Input;

namespace TeRex
{
    public class RelayCommandBase
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

	public class RelayCommand : RelayCommandBase, ICommand
	{
		private readonly Action action;

        public RelayCommand(Action action)
		{
			this.action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			action();
		}
	}
}