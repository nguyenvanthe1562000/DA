using DAL;
using DAL.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    public class vOpenInventoryRepository : IvOpenInventoryRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public vOpenInventoryRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(vOpenInventoryModel model)
        {
            try
            {
                model.stt = "";
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("vOpenInventory_create", "@DocDate", model.DocDate, "@stt",
                    model.stt, "@note", model.note, "@ProducdId", model.ProducdId, "@Unit", 
                    model.Unit, "@Quantity", model.Quantity, "@UnitCost", model.UnitCost);
                if (!string.IsNullOrEmpty(result.message.ToString()))
                {
                    return false;
                    throw new Exception(result.message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }













        public async Task<List<vOpenInventoryModel>> GetAll()
        {
            try
            {
                string msgError="";
                var dt =  _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "vOpenInventory_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var list = dt.ConvertTo<vOpenInventoryModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        public async Task<vOpenInventoryModel> GetById(int ID)
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "vOpenInventory_get_by_id", "@ID", ID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                var list = dt.ConvertTo<vOpenInventoryModel>();
                return list.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {

                if (_dbHelper != null)
                {
                    _dbHelper = null;

                    //GC.Collect();
                }
                disposed = true;
            }

        }
        ~vOpenInventoryRepository()
        {
            Dispose(false);

        }
    }
}



















