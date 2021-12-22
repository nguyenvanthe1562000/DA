using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class ProductInformationService :IProductInformationService
  {
        private IProductInformationRepository _ProductInformationRepository;
        public ProductInformationService (  IProductInformationRepository  ProductInformation  )
        {
            _ProductInformationRepository =   ProductInformation   ;
       }
    
        public async Task<bool> Insert ( ProductInformationModel model, int userId)
        {
    ProductInformationModel productinformationModel= new ProductInformationModel(){;
};
            return await _ProductInformationRepository.Insert(model,userId);
        }



    
        public async Task<bool> Update(ProductInformationModel model, int userId);
        { 
            return await _ProductInformationRepository.Update(model,  userId);
        }

    
    
        public async List<ProductInformationModel> GetAll()
        {
            var result = _ProductInformationRepository.GetAll();
            return await result;
        }

    
        public async Task<List<ProductInformationModel>> Search( DateTime fr_CreatedAt, DateTime to_CreatedAt)
        {
            return await _ProductInformationRepository.Search(fr_CreatedAt, to_CreatedAt);
        }

       public async Task<PagedResultBase> Paging(PagingRequestBase pagingRequest)
        {
            return await _ProductInformationRepository.Paging(pagingRequest);
        }






    
        public bool SavefromList(string listjson_ProductInformation)
        {
            return _ProductInformationRepository.SavefromList(listjson_ProductInformation);
        }

    
         public  async Task<ProductInformationModel> GetById(string CategoryCode)
        {
            var result = _ProductInformationRepository.GetById(CategoryCode);
            return await result;
        }


    
   }
}










