using System.Windows;

namespace ShoppingCart.Model;

public static class MyMessageBox
{
	public static MessageBoxResult ShowConfirmationBox(string message)
	{
		return MessageBox.Show(message,
			"Confirmar Accion",
			MessageBoxButton.YesNo,
			MessageBoxImage.Question);
	}
}
