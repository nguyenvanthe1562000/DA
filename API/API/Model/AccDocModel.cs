using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class AccDocModel
    {

        public int ID { set; get; }
        public DateTime DocDate { set; get; }
        public string stt { set; get; }
        public string Description { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public List<AccDocDetailModel> listjson { get; set; }

    }
}



