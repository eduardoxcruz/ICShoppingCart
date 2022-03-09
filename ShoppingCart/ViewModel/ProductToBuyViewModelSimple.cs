using Serilog;
using ShoppingCart.Model;

namespace ShoppingCart.ViewModel;

public class ProductToBuyViewModelSimple
{
	private ILogger Logger { get; } = MyLogger.CreateLogger<ProductToBuyViewModelSimple>();
}
