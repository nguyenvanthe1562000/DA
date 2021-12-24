
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
  public class FunctionRepository:IFunctionRepository,IDisposable
   {
        private IDatabaseHelper _dbHelper;
        public FunctionRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        

   










        
        public List<FunctionModel>GetAll()
        {
            try
            {
                string msgError = "";
                var dt =  _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Function_get_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<FunctionModel>().ToList();
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


        ~FunctionRepository()
        {
            Dispose(false);

        }
   }
}



















