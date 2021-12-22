using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermisionDetail
    {
		public int ID { set; get; }
		public string PermisionCode { set; get; }
		public string FunctionCode { set; get; }
		public bool CanCreate { set; get; }
		public bool CanRead { set; get; }
		public bool Canupdate { set; get; }
		public bool Candelete { set; get; }
		public bool CanReport { set; get; }
		public bool IsActive { set; get; }
		public int CreatedBy { set; get; }
		public DateTime CreatedAt { set; get; }
		public int ModifiedBy { set; get; }
		public DateTime ModifiedAt { set; get; }


	}
}
