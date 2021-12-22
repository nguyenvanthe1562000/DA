using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class PermisionModel 
     {
        
    public string Code { set; get; }
    public string Name { set; get; }
    public bool IsActive { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedAt { set; get; }
    public int ModifiedBy { set; get; }
    public DateTime ModifiedAt { set; get; }
    

     }
}



