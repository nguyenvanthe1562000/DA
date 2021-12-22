using Common;
using Common.Helper;
using Data.Reponsitory.Interface;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Data.Reponsitory
{
  public class ProductInformationRepository:IProductInformationRepository,IDisposable
   {
        private IDatabaseHelper _dbHelper;
        public ProductInformationRepository(IDatabaseHelper databaseHelper)
        {
            _dbHelper = databaseHelper;
        }
        
 public async Task<bool> Insert(ProductInformationModel model, int userId)
        {
                  try
            {                  
                var result =  await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("ProductInformation_create","@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@CategoryCode", model.CategoryCode, "@name", model.name, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive, "@CreatedBy", model.CreatedBy, "@CreatedAt", model.CreatedAt, "@ModifiedBy", model.ModifiedBy, "@ModifiedAt", model.ModifiedAt,"@user_id", userId);
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
   









        
 public async Task<bool>  Update(ProductInformationModel model, int userId)
        {
        
            try
            {
                var result = await _dbHelper.ExecuteScalarSProcedureWithTransactionAsync("ProductInformation_update","@IsGroup", model.IsGroup, "@ParentId", model.ParentId, "@CategoryCode", model.CategoryCode, "@name", model.name, "@DisplayOrder", model.DisplayOrder, "@IsActive", model.IsActive, "@CreatedBy", model.CreatedBy, "@CreatedAt", model.CreatedAt, "@ModifiedBy", model.ModifiedBy, "@ModifiedAt", model.ModifiedAt
                ,"@user_id", userId);
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

        
        
        public async Task<List<ProductInformationModel>>GetAll()
        {
            try
            {
                var dt =await  _dbHelper.ExecuteSProcedureReturnDataTableAsync("ProductInformation_get_all");
             if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<ProductInformationModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        public async Task<List<ProductInformationModel>> Search( DateTime fr_CreatedAt, DateTime to_CreatedAt)
        {
             try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("ProductInformation_search", "@fr_CreatedAt", fr_CreatedAt, "@to_CreatedAt", to_CreatedAt);
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                 var list = await dt.Item2.ConvertToAsync<ProductInformationModel>();
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            try
            {

                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync("usp_sys_PagingForTable", "@PageSize", pagingRequest.PageSize, "@PageIndex", pagingRequest.PageIndex, "@orderby", pagingRequest.OrderBy, "@table", "ProductInformation");
                if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
                var list = await dt.Item2.ConvertToAsync<PagedResultBase>();
                return list.ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        
        public  async Task<ProductInformationModel> GetById(string CategoryCode)
        {
            string msgError = "";
            try
            {
                var dt = await _dbHelper.ExecuteSProcedureReturnDataTableAsync( "ProductInformation_get_by_id","@CategoryCode", CategoryCode);
               if (!string.IsNullOrEmpty(dt.message))
                {
                    throw new Exception(dt.message);
                }
 var list = await dt.Item2.ConvertToAsync<ProductInformationModel>();
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
        ~ProductInformationRepository()
        {
            Dispose(false);

        }
   }
}



















