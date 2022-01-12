using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IvOpenInventoryService
    {
        Task<bool> Insert( vOpenInventoryModel model);            

    
    
    Task<List<vOpenInventoryModel>> GetAll();

    
    
    
    Task<vOpenInventoryModel> GetById(int ID);


    }
}












