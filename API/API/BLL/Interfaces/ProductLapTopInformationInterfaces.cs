using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IProductLapTopInformationService
    {
        Task<bool> Insert( ProductLapTopInformationModel model);            

    
     Task<bool>  Delete( int ID);


    
    
    
    
    Task<ProductLapTopInformationModel> GetById(string ProductCode);


    }
}












