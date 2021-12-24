
using DAL;
using DAL.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
    public class AccDocRepository : IAccDocRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public AccDocRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public  bool Insert(AccDocModel model)
        {
            try
            {
                string msgError = "";
                string json = JsonConvert.SerializeObject(model.listjson);
                var result =  _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError,"AccDoc_create", "@DocDate", model.DocDate, 
                    "@stt", model.stt, "@Description", model.Description, "@listjson", json);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
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
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("AccDoc_delete", "@ID", ID);
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





        public  List<AccDocModel> GetAll()
        {
            try
            {
                string msgError = "";
                var dt =  _dbHelper.ExecuteSProcedureReturnDataTable(out msgError,"AccDoc_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<AccDocModel>().ToList();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public  AccDocModel GetById(int ID)
        {
            string msgError = "";
            try
            {
                var dt =  _dbHelper.ExecuteSProcedureReturnDataTable(out msgError,"AccDoc_get_by_id", "@ID", ID);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<AccDocModel>().FirstOrDefault();

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
        ~AccDocRepository()
        {
            Dispose(false);

        }
    }
}



















