﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingCart.ViewModel;

public class ProductToBuySimpleViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}