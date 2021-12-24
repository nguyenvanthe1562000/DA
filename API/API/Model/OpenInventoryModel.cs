using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class OpenInventoryModel 
     {
       	
	public int ID { set; get; }
	public string Year { set; get; }
	public DateTime DocDate { set; get; }
	public string ProducdId { set; get; }
	public string Unit { set; get; }
	public int Quantity { set; get; }
	public decimal UnitCost { set; get; }
	public decimal Amount { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}



