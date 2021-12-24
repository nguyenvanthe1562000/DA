using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IPermisionRepository
    {
        bool Insert(PermisionModel model);


        bool Delete(int ID);


        List<PermisionModel> GetAll();



    }
}





