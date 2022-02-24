using System;

namespace ShoppingCart.ViewModel;

public class RelayCommand
{
	private readonly Action<object> _execute;  
	private readonly Predicate<object> _canExecute; 
}
