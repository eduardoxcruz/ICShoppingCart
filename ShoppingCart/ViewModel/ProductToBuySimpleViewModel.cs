using System;
using System.Collections.ObjectModel;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Mux;
using Mux.Model;
using Serilog;
using SerilogUtils;
using ShoppingCart.Model;

namespace ShoppingCart.ViewModel;

public class ProductToBuySimpleViewModel : ViewModelBase
{
	private ProductToBuy _productToBuy;
	private ObservableCollection<ProductToBuy> _shoppingCart;
	private ObservableCollection<Employee> _employees;
	private ObservableCollection<MountingTechnology> _mountingTechnologies;

	public ProductToBuy ProductToBuy
	{
		get => _productToBuy;
		set
		{
			_productToBuy = value;
			OnPropertyChanged(nameof(ProductToBuy));
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
	public RelayCommand AddProductToBuyCommand { get; }
	public RelayCommand UpdateProductToBuyCommand { get; }
	private ICContext Context { get; set; }
	private ILogger Logger { get; } = MyLogger.CreateLogger<ProductToBuySimpleViewModel>();


	public ProductToBuySimpleViewModel()
	{
		Context = new ICContext();
		_productToBuy = new ProductToBuy();
		_shoppingCart = GetShoppingCartAsObservableCollection();
		_employees = GetEmployeesAsObservableCollection();
		AddProductToBuyCommand = new RelayCommand(AddProductToBuy, _ => true);
		UpdateProductToBuyCommand = new RelayCommand(UpdateProductToBuy, _ => true);
	}
	
	private ObservableCollection<ProductToBuy> GetShoppingCartAsObservableCollection()
	{
		try
		{
			LoadShoppingCart();
			
			return Context.ShoppingCart.Local.ToObservableCollection();
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de cargar el carrito de compras. {@BaseException}", 
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al cargar el carrito de compras. Vea el log para mas detalles.");
			return new ObservableCollection<ProductToBuy>();
		}
	}
	
	private void LoadShoppingCart()
	{
		Context.ShoppingCart
			.Include(p => p.Petitioner)
			.Include(p => p.Provider)
			.Load();
	}
	
	private ObservableCollection<Employee> GetEmployeesAsObservableCollection()
	{
		try
		{
			LoadEmployees();
			
			return Context.Employees.Local.ToObservableCollection();
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de cargar el los empleados. {@BaseException}", 
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al cargar los empleados. Vea el log para mas detalles.");
			return new ObservableCollection<Employee>();
		}
	}
	
	private void LoadEmployees()
	{
		Context.Employees.Load();
	}
	
	private async void AddProductToBuy(object o)
	{
		if (!ConfirmAction("¿Desea agregar el registro?")) return;
		
		try
		{
			Context.ShoppingCart.Add(GenerateNewProductToBuy());
			await Context.SaveChangesAsync();
			ProductToBuy = new ProductToBuy();
			MyMessageBox.ShowSuccessBox("Exito al agregar el registro.");
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de agregar un nuevo registro a Shopping Cart. {@BaseException}", 
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al agregar el registro. Vea el log para mas detalles.");
		}
	}

	private ProductToBuy GenerateNewProductToBuy()
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

	private async void UpdateProductToBuy(object o)
	{
		if (ProductToBuy.Id == 0 || !ConfirmAction("¿Desea actualizar el registro?"))
		{
			return;
		}
		
		try
		{
			Context.Entry(ProductToBuy).State = EntityState.Modified;
			await Context.SaveChangesAsync();
			MyMessageBox.ShowSuccessBox("Exito al actualizar el registro.");
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de actualizar el registro en Shopping Cart. {@BaseException}", 
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al actualizar el registro. Vea el log para mas detalles.");
		}
	}

	private bool ConfirmAction(string confirmationMessage)
	{
		return MyMessageBox.ShowConfirmationBox(confirmationMessage) != MessageBoxResult.No;
	}
}
