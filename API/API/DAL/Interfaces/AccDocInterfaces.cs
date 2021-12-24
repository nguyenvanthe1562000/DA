using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IAccDocRepository
    {
        bool Insert(AccDocModel model);



        List<AccDocModel> GetAll();


        Task<bool> Delete(int ID);


        AccDocModel GetById(int ID);


    }
}





