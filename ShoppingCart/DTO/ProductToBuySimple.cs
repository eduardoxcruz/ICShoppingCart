using System;
using Mux.Model;

namespace ShoppingCart.DTO;

public class ProductToBuySimple
{
	public int Id { get; set; }
	public string Status { get; set; }
	public int? ProviderId { get; set; }
	public Provider? Provider { get; set; }
	public DateTime? LocationDate { get; set; }
	public int? SellerId { get; set; }
	public Employee? Seller { get; set; }
	public DateTime? ArrivalDate { get; set; }
	public string? Comments { get; set; }
	public DateTime RequestDate { get; set; }
	public int? PetitionerId { get; set; }
	public Employee? Petitioner { get; set; }
	public string InternalReference { get; set; }
	public string ProductDescription { get; set; }
	public int RequestedAmount { get; set; }
	public string MountingTechnology { get; set; }
	public string EncapsulationType { get; set; }
	public string Priority { get; set; }
}
