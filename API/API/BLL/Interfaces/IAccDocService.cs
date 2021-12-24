using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service.Interface

{
    public interface IAccDocService
    {
        bool Insert(AccDocModel model);



        List<AccDocModel> GetAll();




        Task<bool> Delete(int ID);

        AccDocModel GetById(int ID);


    }
}












