using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Mux.Model;
using ShoppingCart.DTO;

namespace ShoppingCart.ViewModel;

public class ProductToBuySimpleViewModel : INotifyPropertyChanged
{
	private ProductToBuySimple _productToBuy { get; set; }
	public int Id
	{
		get => _productToBuy.Id;
		set
		{
			_productToBuy.Id = value;
			OnPropertyChanged(nameof(Id));
		}
	}
	public string Status
	{
		get => _productToBuy.Status;
		set
		{
			_productToBuy.Status = value;
			OnPropertyChanged(nameof(Status));
		}
	}
	public int? ProviderId
	{
		get => _productToBuy.ProviderId;
		set
		{
			_productToBuy.ProviderId = value;
			OnPropertyChanged(nameof(ProviderId));
		}
	}
	public Provider? Provider
	{
		get => _productToBuy.Provider;
		set
		{
			_productToBuy.Provider = value;
			OnPropertyChanged(nameof(Provider));
		}
	}
	public DateTime? LocationDate
	{
		get => _productToBuy.LocationDate;
		set
		{
			_productToBuy.LocationDate = value;
			OnPropertyChanged(nameof(LocationDate));
		}
	}
	public int? SellerId
	{
		get => _productToBuy.SellerId;
		set
		{
			_productToBuy.SellerId = value;
			OnPropertyChanged(nameof(SellerId));
		}
	}
	public Employee? Seller
	{
		get => _productToBuy.Seller;
		set
		{
			_productToBuy.Seller = value;
			OnPropertyChanged(nameof(Seller));
		}
	}
	public DateTime? ArrivalDate
	{
		get => _productToBuy.ArrivalDate;
		set
		{
			_productToBuy.ArrivalDate = value;
			OnPropertyChanged(nameof(ArrivalDate));
		}
	}
	public string? Comments
	{
		get => _productToBuy.Comments;
		set
		{
			_productToBuy.Comments = value;
			OnPropertyChanged(nameof(Comments));
		}
	}
	public DateTime RequestDate
	{
		get => _productToBuy.RequestDate;
		set
		{
			_productToBuy.RequestDate = value;
			OnPropertyChanged(nameof(RequestDate));
		}
	}
	public int? PetitionerId
	{
		get => _productToBuy.PetitionerId;
		set
		{
			_productToBuy.PetitionerId = value;
			OnPropertyChanged(nameof(PetitionerId));
		}
	}
	public Employee? Petitioner
	{
		get => _productToBuy.Petitioner;
		set
		{
			_productToBuy.Petitioner = value;
			OnPropertyChanged(nameof(Petitioner));
		}
	}
	public string InternalReference
	{
		get => _productToBuy.InternalReference;
		set
		{
			_productToBuy.InternalReference = value;
			OnPropertyChanged(nameof(InternalReference));
		}
	}
	public string ProductDescription
	{
		get => _productToBuy.ProductDescription;
		set
		{
			_productToBuy.ProductDescription = value;
			OnPropertyChanged(nameof(ProductDescription));
		}
	}
	public int RequestedAmount
	{
		get => _productToBuy.RequestedAmount;
		set
		{
			_productToBuy.RequestedAmount = value;
			OnPropertyChanged(nameof(RequestedAmount));
		}
	}
	public string MountingTechnology
	{
		get => _productToBuy.MountingTechnology;
		set
		{
			_productToBuy.MountingTechnology = value;
			OnPropertyChanged(nameof(MountingTechnology));
		}
	}
	public string EncapsulationType
	{
		get => _productToBuy.EncapsulationType;
		set
		{
			_productToBuy.EncapsulationType = value;
			OnPropertyChanged(nameof(EncapsulationType));
		}
	}
	public string Priority
	{
		get => _productToBuy.Priority;
		set
		{
			_productToBuy.Priority = value;
			OnPropertyChanged(nameof(Priority));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
