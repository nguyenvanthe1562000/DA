using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IProductInformationRepository
    {
        Task<bool> Insert( ProductInformationModel model, int userId);            

    Task<bool> Update( ProductInformationModel model, int userId);         

    
    Task<List<ProductInformationModel>> GetAll();

    Task<List<ProductInformationModel>> Search(DateTime fr_CreatedAt, DateTime to_CreatedAt);
  


      Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);

    Task<ProductInformationModel> GetById(string CategoryCode);


    }
}





