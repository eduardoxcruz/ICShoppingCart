using System;
using System.Collections.ObjectModel;
using Mux.Model;
using ShoppingCart.DTO;

namespace ShoppingCart.ViewModel;

public class ProductToBuySimpleViewModel : ViewModelBase
{
	private ProductToBuySimple ProductToBuy { get; set; }
	public ObservableCollection<ProductToBuySimple> ProductsToBuy { get; set; }
	public int Id
	{
		get => ProductToBuy.Id;
		set
		{
			ProductToBuy.Id = value;
			OnPropertyChanged(nameof(Id));
		}
	}
	public string Status
	{
		get => ProductToBuy.Status;
		set
		{
			ProductToBuy.Status = value;
			OnPropertyChanged(nameof(Status));
		}
	}
	public int? ProviderId
	{
		get => ProductToBuy.ProviderId;
		set
		{
			ProductToBuy.ProviderId = value;
			OnPropertyChanged(nameof(ProviderId));
		}
	}
	public Provider? Provider
	{
		get => ProductToBuy.Provider;
		set
		{
			ProductToBuy.Provider = value;
			OnPropertyChanged(nameof(Provider));
		}
	}
	public DateTime? LocationDate
	{
		get => ProductToBuy.LocationDate;
		set
		{
			ProductToBuy.LocationDate = value;
			OnPropertyChanged(nameof(LocationDate));
		}
	}
	public int? SellerId
	{
		get => ProductToBuy.SellerId;
		set
		{
			ProductToBuy.SellerId = value;
			OnPropertyChanged(nameof(SellerId));
		}
	}
	public Employee? Seller
	{
		get => ProductToBuy.Seller;
		set
		{
			ProductToBuy.Seller = value;
			OnPropertyChanged(nameof(Seller));
		}
	}
	public DateTime? ArrivalDate
	{
		get => ProductToBuy.ArrivalDate;
		set
		{
			ProductToBuy.ArrivalDate = value;
			OnPropertyChanged(nameof(ArrivalDate));
		}
	}
	public string? Comments
	{
		get => ProductToBuy.Comments;
		set
		{
			ProductToBuy.Comments = value;
			OnPropertyChanged(nameof(Comments));
		}
	}
	public DateTime RequestDate
	{
		get => ProductToBuy.RequestDate;
		set
		{
			ProductToBuy.RequestDate = value;
			OnPropertyChanged(nameof(RequestDate));
		}
	}
	public int? PetitionerId
	{
		get => ProductToBuy.PetitionerId;
		set
		{
			ProductToBuy.PetitionerId = value;
			OnPropertyChanged(nameof(PetitionerId));
		}
	}
	public Employee? Petitioner
	{
		get => ProductToBuy.Petitioner;
		set
		{
			ProductToBuy.Petitioner = value;
			OnPropertyChanged(nameof(Petitioner));
		}
	}
	public string InternalReference
	{
		get => ProductToBuy.InternalReference;
		set
		{
			ProductToBuy.InternalReference = value;
			OnPropertyChanged(nameof(InternalReference));
		}
	}
	public string ProductDescription
	{
		get => ProductToBuy.ProductDescription;
		set
		{
			ProductToBuy.ProductDescription = value;
			OnPropertyChanged(nameof(ProductDescription));
		}
	}
	public int RequestedAmount
	{
		get => ProductToBuy.RequestedAmount;
		set
		{
			ProductToBuy.RequestedAmount = value;
			OnPropertyChanged(nameof(RequestedAmount));
		}
	}
	public string MountingTechnology
	{
		get => ProductToBuy.MountingTechnology;
		set
		{
			ProductToBuy.MountingTechnology = value;
			OnPropertyChanged(nameof(MountingTechnology));
		}
	}
	public string EncapsulationType
	{
		get => ProductToBuy.EncapsulationType;
		set
		{
			ProductToBuy.EncapsulationType = value;
			OnPropertyChanged(nameof(EncapsulationType));
		}
	}
	public string Priority
	{
		get => ProductToBuy.Priority;
		set
		{
			ProductToBuy.Priority = value;
			OnPropertyChanged(nameof(Priority));
		}
	}

	public ProductToBuySimpleViewModel()
	{
		ProductToBuy = new ProductToBuySimple();
		ProductsToBuy = new ObservableCollection<ProductToBuySimple>();
	}
}
