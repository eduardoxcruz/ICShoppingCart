using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using Mux.Model;
using Serilog;
using SerilogUtils;
using ShoppingCart.Model;

namespace ShoppingCart.ViewModel;

public class ProductToBuyViewModelSimple : ProductToBuyViewModelBase
{
	private ILogger Logger { get; } = MyLogger.CreateLogger<ProductToBuyViewModelSimple>();

	protected override async void AddProductToBuy(object o)
	{
		if (!ConfirmAction("¿Desea agregar el registro?"))
		{
			return;
		}

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

	protected override async void UpdateProductToBuy(object o)
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

	protected override ObservableCollection<ProductToBuy> GetShoppingCartAsObservableCollection()
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
			MyMessageBox.ShowErrorBox(
				"Ocurrio un error al cargar el carrito de compras. Vea el log para mas detalles.");
			return new ObservableCollection<ProductToBuy>();
		}
	}

	protected override ObservableCollection<Employee> GetEmployeesAsObservableCollection()
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

	protected override ObservableCollection<MountingTechnology> GetMountingTechnologiesAsObservableCollection()
	{
		try
		{
			LoadMountingTechnologies();

			return Context.MountingTechnologies.Local.ToObservableCollection();
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de cargar las tecnologias de montaje. {@BaseException}",
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox(
				"Ocurrio un error al cargar las tecnologias de montaje. Vea el log para mas detalles.");
			return new ObservableCollection<MountingTechnology>();
		}
	}

	protected override ObservableCollection<EncapsulationType> GetEncapsulationTypesAsObservableCollection()
	{
		try
		{
			LoadEncapsulationTypes();

			return Context.EncapsulationTypes.Local.ToObservableCollection();
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de cargar los encapsulados. {@BaseException}",
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al cargar los encapsulados. Vea el log para mas detalles.");
			return new ObservableCollection<EncapsulationType>();
		}
	}

	protected override ObservableCollection<Provider> GetProvidersAsObservableCollection()
	{
		try
		{
			LoadProviders();

			return Context.Providers.Local.ToObservableCollection();
		}
		catch (Exception exception)
		{
			Logger
				.Here()
				.Error(
					"Ocurrio una excepcion al tratar de cargar los proveedores. {@BaseException}",
					exception.GetBaseException());
			MyMessageBox.ShowErrorBox("Ocurrio un error al cargar los proveedores. Vea el log para mas detalles.");
			return new ObservableCollection<Provider>();
		}
	}

	protected override void UseQuickSearch(object sender, FilterEventArgs filterEventArgs)
	{
		ProductToBuy productToBuy = (filterEventArgs.Item as ProductToBuy)!;
		string searchingText = QuickSearchFilter.ToLower();

		if (productToBuy.Id.ToString().Contains(searchingText))
		{
			filterEventArgs.Accepted = true;
			return;
		}

		if (productToBuy.Provider != null && productToBuy.Provider.BusinessName.Contains(searchingText))
		{
			filterEventArgs.Accepted = true;
			return;
		}

		if (IsInEmployeeProperties(productToBuy, searchingText))
		{
			filterEventArgs.Accepted = true;
			return;
		}

		if (IsInStringProperties(productToBuy, searchingText))
		{
			filterEventArgs.Accepted = true;
			return;
		}

		filterEventArgs.Accepted = false;
	}

	protected override bool IsInStringProperties(ProductToBuy productToBuy, string searchingText)
	{
		if (productToBuy.Status.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.Comments != null && productToBuy.Comments.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.InternalReference.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.ProductDescription.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.MountingTechnology.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.EncapsulationType.ToLower().Contains(searchingText))
		{
			return true;
		}

		if (productToBuy.Priority.ToLower().Contains(searchingText))
		{
			return true;
		}

		return false;
	}

	protected override void UseAdvancedSearch(object sender, FilterEventArgs filterEventArgs)
	{
		ProductToBuy item = (filterEventArgs.Item as ProductToBuy)!;

		if (IdMatch(item) &&
		    StatusMatch(item) &&
		    ProviderMatch(item) &&
		    InternalReferenceMatch(item) &&
		    PetitionerMatch(item) &&
		    MountingTechnologyMatch(item) &&
		    EncapsulationTypeMatch(item)
		   )
		{
			filterEventArgs.Accepted = true;
			return;
		}

		filterEventArgs.Accepted = false;
	}
}
