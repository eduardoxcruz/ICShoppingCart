using System.Collections.ObjectModel;
using System.Windows.Data;
using Mux;
using Mux.Model;

namespace ShoppingCart.ViewModel;

public abstract class ProductToBuyViewModelBase : ViewModelBase
{
	private int _selectedIndex;
	private ProductToBuy _selectedItem;
	private ProductToBuy _productToBuy;
	private ObservableCollection<ProductToBuy> _shoppingCart;
	private CollectionViewSource _shoppingCartView;
	private ObservableCollection<Employee> _employees;
	private ObservableCollection<MountingTechnology> _mountingTechnologies;
	private ObservableCollection<EncapsulationType> _encapsulationTypes;
	private ObservableCollection<Provider> _providers;
	private string _quickSearchFilter;
	private string _idFilter;
	private string _statusFilter;
	private string _providerFilter;
	private string _internalReferenceFilter;
	private string _petitionerFilter;
	private string _mountingTechnologyFilter;
	private string _encapsulationTypeFilter;
	
	public int SelectedIndex
	{
		get => _selectedIndex;
		set
		{
			_selectedIndex = value;
			OnPropertyChanged(nameof(SelectedIndex));
			OnPropertyChanged(nameof(SelectedItem));
		}
	}
	public ProductToBuy SelectedItem
	{
		get => _selectedItem;
		set
		{
			_selectedItem = value;
			OnPropertyChanged(nameof(SelectedItem));
			OnPropertyChanged(nameof(ProductToBuy));
		}
	}
	public ProductToBuy ProductToBuy
	{
		get
		{
			return SelectedIndex > -1 ? _selectedItem : _productToBuy;
		} 
		set
		{
			if (SelectedIndex > -1)
			{
				_selectedItem = value;
			}
			else
			{
				_productToBuy = value;
			}
			
			OnPropertyChanged(nameof(ProductToBuy));
			OnPropertyChanged(nameof(SelectedItem));
		}
	}
	public ObservableCollection<ProductToBuy> ShoppingCart
	{
		get => _shoppingCart;
		set
		{
			_shoppingCart = value;
			OnPropertyChanged(nameof(ShoppingCart));
		}
	}
	public CollectionViewSource ShoppingCartView
	{
		get => _shoppingCartView;
		set
		{
			_shoppingCartView = value;
			OnPropertyChanged(nameof(ShoppingCartView));
		}
	}
	public ObservableCollection<Employee> Employees
	{
		get => _employees;
		set
		{
			_employees = value;
			OnPropertyChanged(nameof(Employees));
		}
	}
	public ObservableCollection<MountingTechnology> MountingTechnologies
	{
		get => _mountingTechnologies;
		set
		{
			_mountingTechnologies = value;
			OnPropertyChanged(nameof(MountingTechnologies));
		}
	}
	public ObservableCollection<EncapsulationType> EncapsulationTypes
	{
		get => _encapsulationTypes;
		set
		{
			_encapsulationTypes = value;
			OnPropertyChanged(nameof(EncapsulationTypes));
		}
	}
	public ObservableCollection<Provider> Providers
	{
		get => _providers;
		set
		{
			_providers = value;
			OnPropertyChanged(nameof(Providers));
		}
	}
	public string QuickSearchFilter
	{
		get => _quickSearchFilter;
		set
		{
			_quickSearchFilter = value;
			OnPropertyChanged(nameof(QuickSearchFilter));
		}
	}
	public string IdFilter
	{
		get => _idFilter;
		set
		{
			_idFilter = value;
			OnPropertyChanged(nameof(IdFilter));
		}
	}
	public string StatusFilter
	{
		get => _statusFilter;
		set
		{
			_statusFilter = value;
			OnPropertyChanged(nameof(StatusFilter));
		}
	}
	public string ProviderFilter
	{
		get => _providerFilter;
		set
		{
			_providerFilter = value;
			OnPropertyChanged(nameof(ProviderFilter));
		}
	}
	public string InternalReferenceFilter
	{
		get => _internalReferenceFilter;
		set
		{
			_internalReferenceFilter = value;
			OnPropertyChanged(nameof(InternalReferenceFilter));
		}
	}
	public string PetitionerFilter
	{
		get => _petitionerFilter;
		set
		{
			_petitionerFilter = value;
			OnPropertyChanged(nameof(PetitionerFilter));
		}
	}
	public string MountingTechnologyFilter
	{
		get => _mountingTechnologyFilter;
		set
		{
			_mountingTechnologyFilter = value;
			OnPropertyChanged(nameof(MountingTechnologyFilter));
		}
	}
	public string EncapsulationTypeFilter
	{
		get => _encapsulationTypeFilter;
		set
		{
			_encapsulationTypeFilter = value;
			OnPropertyChanged(nameof(EncapsulationTypeFilter));
		}
	}
	public RelayCommand AddProductToBuyCommand { get; set; }
	public RelayCommand UpdateProductToBuyCommand { get; set; }
	public RelayCommand CleanProductToBuyCommand { get; set; }
	public RelayCommand RefreshShoppingCartViewCommand { get; set; }
	public RelayCommand ClearFiltersAndRefreshShoppingCartViewCommand { get; set; }
	protected ICContext Context { get; set; }
	
#pragma warning disable CS8618
	protected ProductToBuyViewModelBase() {}
#pragma warning restore CS8618

	private void InitializeFilters()
	{
		_quickSearchFilter = "";
		_idFilter = "";
		_statusFilter = "";
		_providerFilter = "";
		_internalReferenceFilter = "";
		_petitionerFilter = "";
		_mountingTechnologyFilter = "";
		_encapsulationTypeFilter = "";
	}

	
}
