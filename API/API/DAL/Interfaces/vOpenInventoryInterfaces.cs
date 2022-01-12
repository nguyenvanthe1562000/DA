using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IvOpenInventoryRepository
    {
        Task<bool> Insert( vOpenInventoryModel model);            

    
    
    Task<List<vOpenInventoryModel>> GetAll();

    
    
    Task<vOpenInventoryModel> GetById(int ID);


    }
}





