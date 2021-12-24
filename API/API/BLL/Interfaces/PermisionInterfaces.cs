using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface IPermisionService
    {
        bool Insert( PermisionModel model);            


     bool Delete( int ID);


    List<PermisionModel> GetAll();

  




    



    }
}












