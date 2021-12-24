using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class PermisionService : IPermisionService
    {
        private IPermisionRepository _PermisionRepository;
        public PermisionService(IPermisionRepository Permision)
        {
            _PermisionRepository = Permision;
        }

        public bool Insert(PermisionModel model)
        {
            return _PermisionRepository.Insert(model);
        }





        public bool Delete(int ID)
        {
            return _PermisionRepository.Delete(ID);
        }


        public  List<PermisionModel> GetAll()
        {
            var result = _PermisionRepository.GetAll();
            return  result;
        }








}
}










