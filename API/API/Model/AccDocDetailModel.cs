using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class AccDocDetailModel 
     {
       	
	public int ID { set; get; }
	public DateTime DocDate { set; get; }
	public string stt { set; get; }
	public string note { set; get; }
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



