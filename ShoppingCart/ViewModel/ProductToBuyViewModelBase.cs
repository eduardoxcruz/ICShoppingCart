using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using Mux;
using Mux.Model;
using ShoppingCart.Model;

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

	private void InitializeCommands()
	{
		AddProductToBuyCommand = new RelayCommand(AddProductToBuy, _ => true);
		UpdateProductToBuyCommand = new RelayCommand(UpdateProductToBuy, _ => true);
		CleanProductToBuyCommand = new RelayCommand(ClearProductToBuy, _ => true);
		ClearFiltersAndRefreshShoppingCartViewCommand = new RelayCommand(ClearFiltersAndRefreshShoppingCartView, _ => true);
		RefreshShoppingCartViewCommand = new RelayCommand(RefreshShoppinCartView, _ => true);
	}

	protected abstract void AddProductToBuy(object o);

	protected ProductToBuy GenerateNewProductToBuy()
	{
		ProductToBuy newProductToBuy = new()
		{
			RequestDate = DateTime.Now,
			Status = "PENDIENTE"
		};
		
		CopyModifiedProperties(ref newProductToBuy);

		return newProductToBuy;
	}

	private void CopyModifiedProperties(ref ProductToBuy productToBuy)
	{
		productToBuy.Comments = ProductToBuy.Comments;
		productToBuy.PetitionerId = ProductToBuy.Petitioner!.Id;
		productToBuy.InternalReference = ProductToBuy.InternalReference;
		productToBuy.ProductDescription = ProductToBuy.ProductDescription;
		productToBuy.RequestedAmount = ProductToBuy.RequestedAmount;
		productToBuy.MountingTechnology = ProductToBuy.MountingTechnology;
		productToBuy.EncapsulationType = ProductToBuy.EncapsulationType;
		productToBuy.Priority = ProductToBuy.Priority;
	}

	protected abstract void UpdateProductToBuy(object o);
	
	protected bool ConfirmAction(string confirmationMessage)
	{
		return MyMessageBox.ShowConfirmationBox(confirmationMessage) != MessageBoxResult.No;
	}

	public void ClearProductToBuy(object o)
	{
		ProductToBuy = new ProductToBuy() {Status = "PENDIENTE"};
	}
	
	public void ClearFiltersAndRefreshShoppingCartView(object o)
	{
		ClearFilters();
		RefreshShoppinCartView(new object());
	}

	private void ClearFilters()
	{
		QuickSearchFilter = "";
		IdFilter = "";
		ProviderFilter = "";
		InternalReferenceFilter = "";
		StatusFilter = "";
		PetitionerFilter = "";
		MountingTechnologyFilter = "";
		EncapsulationTypeFilter = "";
	}

	public void RefreshShoppinCartView(object o)
	{
		ShoppingCartView.View.Refresh();
	}

	private void InitializeObservableCollections()
	{
		_shoppingCart = GetShoppingCartAsObservableCollection();
		_employees = GetEmployeesAsObservableCollection();
		_mountingTechnologies = GetMountingTechnologiesAsObservableCollection();
		_encapsulationTypes = GetEncapsulationTypesAsObservableCollection();
		_providers = GetProvidersAsObservableCollection();
	}

	protected abstract ObservableCollection<ProductToBuy> GetShoppingCartAsObservableCollection();
	
	protected void LoadShoppingCart()
	{
		Context.ShoppingCart
			.Include(p => p.Petitioner)
			.Include(p => p.Provider)
			.Load();
	}

	protected abstract ObservableCollection<Employee> GetEmployeesAsObservableCollection();
	
	protected void LoadEmployees()
	{
		Context.Employees.Load();
	}

	protected abstract ObservableCollection<MountingTechnology> GetMountingTechnologiesAsObservableCollection();
	
	protected void LoadMountingTechnologies()
	{
		Context.MountingTechnologies.Load();
	}

	protected abstract ObservableCollection<EncapsulationType> GetEncapsulationTypesAsObservableCollection();
	
	protected void LoadEncapsulationTypes()
	{
		Context.EncapsulationTypes.Load();
	}

	protected abstract ObservableCollection<Provider> GetProvidersAsObservableCollection();

	protected void LoadProviders()
	{
		Context.Providers.Load();
	}
}
