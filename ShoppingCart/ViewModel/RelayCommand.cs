using System;

namespace ShoppingCart.ViewModel;

public class RelayCommand
{
	private readonly Action<object> _execute;
	private readonly Predicate<object> _canExecute;

	public RelayCommand(Action<object> execute) : this(execute, null)
	{
	}

	public RelayCommand(Action<object> execute, Predicate<object> canExecute)
	{
		_execute = execute ?? throw new ArgumentNullException(nameof(execute));
		_canExecute = canExecute;
	}
}
