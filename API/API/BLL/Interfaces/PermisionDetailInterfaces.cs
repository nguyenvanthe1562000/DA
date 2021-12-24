using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IPermisionDetailService
    {
        Task<bool> Insert( PermisionDetailModel model);            


     Task<bool>  Delete( int ID);


    Task<List<PermisionDetailModel>> GetAll();

  





    

    Task<PermisionDetailModel> GetById(int ID);


    }
}












