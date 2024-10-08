﻿using System;
using System.Windows.Input;

namespace TeRex
{
	public class RelayCommand<T> : RelayCommandBase, ICommand
	{
		private readonly Action<T> action;

		public RelayCommand(Action<T> action)
		{
			this.action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			action((T)parameter);
		}
	}
}