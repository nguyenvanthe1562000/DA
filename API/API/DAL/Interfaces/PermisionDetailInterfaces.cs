using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Data.Reponsitory.Interface

{
    public interface IPermisionDetailRepository
    {
        Task<bool> Insert( PermisionDetailModel model);            


     Task<bool>  Delete( int ID);


    Task<List<PermisionDetailModel>> GetAll();

  



    Task<PermisionDetailModel> GetById(int ID);


    }
}





