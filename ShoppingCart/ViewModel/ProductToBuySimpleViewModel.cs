using System;
using System.Collections.ObjectModel;
using Mux.Model;
using Serilog;
using SerilogUtils;
using ShoppingCart.Model;

namespace ShoppingCart.ViewModel;

public class ProductToBuySimpleViewModel : ViewModelBase
{
	private ProductToBuy _productToBuy;

	public ProductToBuy ProductToBuy
	{
		get => _productToBuy;
		set
		{
			_productToBuy = value;
			OnPropertyChanged(nameof(ProductToBuy));
		}
	}
	public RelayCommand AddProductToBuyCommand { get; }
	public RelayCommand UpdateProductToBuyCommand { get; }
	private ICContext Context { get; set; }
	private ILogger Logger { get; } = MyLogger.CreateLogger<ProductToBuySimpleViewModel>();


	public ProductToBuySimpleViewModel()
	{
		ProductToBuy = new ProductToBuySimple();
		ProductsToBuy = new ObservableCollection<ProductToBuySimple>();
	}
}
