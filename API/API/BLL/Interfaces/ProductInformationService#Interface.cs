using Common;
using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IProductInformationService
    {
        Task<bool> Insert( ProductInformationModel model, int userId);            

    Task<bool> Update( ProductInformationModel model, int userId);         

    
    Task<List<ProductInformationModel>> GetAll();

    Task<List<ProductInformationModel>> Search(DateTime fr_CreatedAt, DateTime to_CreatedAt);
  


      Task<PagedResultBase> Paging(PagingRequestBase pagingRequest);



    bool SavefromList(string listjson_ProductInformation);
    

    Task<ProductInformationModel> GetById(string CategoryCode);


    }
}












