using DAL;
using DAL.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Data.Reponsitory
{
    public class PermisionRepository : IPermisionRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public PermisionRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public bool Insert(PermisionModel model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Permision_create", "@Code", model.Code, "@Name", model.Name);
                if (!string.IsNullOrEmpty(msgError.ToString()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }










        public bool  Delete(int ID)
        {

            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "Permision_delete", "@ID", ID);
                if (!string.IsNullOrEmpty(msgError.ToString()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public List<PermisionModel> GetAll()
        {
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Permision_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<PermisionModel>().ToList();
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
        ~PermisionRepository()
        {
            Dispose(false);

        }
    }
}



















