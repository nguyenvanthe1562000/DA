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
    public class PermisionDetailRepository : IPermisionDetailRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public PermisionDetailRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(PermisionDetailModel model)
        {
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("PermisionDetail_create", "@PermisionCode", 
                    model.PermisionCode, "@functionCode", model.functionCode, "@CanCreate", model.CanCreate, "@CanRead", model.CanRead, "@Canupdate", model.Canupdate, "@Candelete", model.Candelete, "@CanReport", model.CanReport);
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








        public async Task<bool> Delete(int ID)
        {

            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("PermisionDetail_delete", "@ID", ID);
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




        public async Task<List<PermisionDetailModel>> GetAll()
        {
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("PermisionDetail_get_all");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<PermisionDetailModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public async Task<PermisionDetailModel> GetById(int ID)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("PermisionDetail_get_by_id", "@ID", ID);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<PermisionDetailModel>();
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
        ~PermisionDetailRepository()
        {
            Dispose(false);

        }
    }
}



















