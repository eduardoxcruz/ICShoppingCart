using System.Windows;

namespace ShoppingCart.Model;

public static class MyMessageBox
{
	public static MessageBoxResult ShowConfirmationBox(string message)
	{
		return MessageBox.Show(message,
			"Confirmar",
			MessageBoxButton.YesNo,
			MessageBoxImage.Exclamation);
	}

	public static void ShowErrorBox(string message)
	{
		MessageBox.Show(message,
			"Error",
			MessageBoxButton.OK,
			MessageBoxImage.Error);
	}
}
