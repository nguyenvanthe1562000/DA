using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Function
    {
		public int ID { set; get; }
		public bool IsGroup { set; get; }
		public int ParentId { set; get; }
		public string Code { set; get; }
		public int CategoryFunc { set; get; }
		public string Name { set; get; }
		public string Url { set; get; }
		public int DisplayOrder { set; get; }
		public bool IsActive { set; get; }
		public int CreatedBy { set; get; }
		public DateTime CreatedAt { set; get; }
		public int ModifiedBy { set; get; }
		public DateTime ModifiedAt { set; get; }

	}
}
