using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class AccDocService :IAccDocService
  {
        private IAccDocRepository _AccDocRepository;
        public AccDocService (  IAccDocRepository  AccDoc  )
        {
            _AccDocRepository =   AccDoc   ;
       }
    
        public bool Insert ( AccDocModel model)
        {
 
            return  _AccDocRepository.Insert(model);
        }



        public async Task<bool> Delete(int ID)
        {
            return await _AccDocRepository.Delete(ID);
        }

        public List<AccDocModel> GetAll()
        {
            var result = _AccDocRepository.GetAll();
            return  result;
        }
    
         public  AccDocModel GetById(int ID)
        {
            var result = _AccDocRepository.GetById(ID);
            return  result;
        }


    
   }
}










