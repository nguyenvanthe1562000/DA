using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class FunctionService : IFunctionService
    {
        private IFunctionRepository _FunctionRepository;
        public FunctionService(IFunctionRepository Function)
        {
            _FunctionRepository = Function;
        }








        public List<FunctionModel> GetAll()
        {
            var result = _FunctionRepository.GetAll();
            return result;
        }




    }
}










