using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class ProductInformationModel 
     {
        
    public bool IsGroup { set; get; }
    public int ParentId { set; get; }
    public string CategoryCode { set; get; }
    public string name { set; get; }
    public int DisplayOrder { set; get; }
    public bool IsActive { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedAt { set; get; }
    public int ModifiedBy { set; get; }
    public DateTime ModifiedAt { set; get; }
    

     }
}



