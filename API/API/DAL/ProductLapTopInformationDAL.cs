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
    public class ProductLapTopInformationRepository : IProductLapTopInformationRepository, IDisposable
    {
        private IDatabaseHelper _dbHelper;
        public ProductLapTopInformationRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }

        public async Task<bool> Insert(ProductLapTopInformationModel model)
        {
            try
            {
                string msgError = "";
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ProductLapTopInformation_create", "@IsGroup", model.IsGroup, "@ParentId", model.ParentId,
                    "@ProductCode", model.ProductCode, "@CPUType", model.CPUType, "@GraphicsCardType", model.GraphicsCardType, "@AmountRAM", model.AmountRAM, "@HardDrive", model.HardDrive,
                    "@ScreenSize", model.ScreenSize, "@ScreenResolution", model.ScreenResolution, "@Communication", model.Communication, "@OperatingSystem", model.OperatingSystem, "@Size",
                    model.Size, "@WIFI", model.WIFI, "@Bluetooth", model.Bluetooth, "@Weight", model.Weight);
                if (!string.IsNullOrEmpty(msgError.ToString()))
                {
                    return false;
                    throw new Exception(msgError);
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
                string msgError = "";
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "ProductLapTopInformation_delete", "@ID", ID);
                if (!string.IsNullOrEmpty(msgError.ToString()))
                {
                    return false;
                    throw new Exception(msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public async Task<ProductLapTopInformationModel> GetById(string ProductCode)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ProductLapTopInformation_get_by_id", "@ProductCode", ProductCode);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var list = dt.ConvertTo<ProductLapTopInformationModel>().FirstOrDefault();
                return list;

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
        ~ProductLapTopInformationRepository()
        {
            Dispose(false);

        }
    }
}



















