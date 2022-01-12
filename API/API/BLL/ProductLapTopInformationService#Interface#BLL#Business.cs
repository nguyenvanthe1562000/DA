using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class ProductLapTopInformationService :IProductLapTopInformationService
  {
        private IProductLapTopInformationRepository _ProductLapTopInformationRepository;
        public ProductLapTopInformationService (  IProductLapTopInformationRepository  ProductLapTopInformation  )
        {
            _ProductLapTopInformationRepository =   ProductLapTopInformation   ;
       }
    
        public async Task<bool> Insert ( ProductLapTopInformationModel model)
        {
            return await _ProductLapTopInformationRepository.Insert(model);
        }

        public async Task<bool> Delete(int ID)
        {
            return await _ProductLapTopInformationRepository.Delete(ID);
        }

         public  async Task<ProductLapTopInformationModel> GetById(string ProductCode)
        {
            var result = _ProductLapTopInformationRepository.GetById(ProductCode);
            return await result;
        }

   }
}










