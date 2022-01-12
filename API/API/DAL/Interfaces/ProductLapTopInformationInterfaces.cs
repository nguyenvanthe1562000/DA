using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Model;
namespace Data.Reponsitory.Interface

{
    public interface IProductLapTopInformationRepository
    {
        Task<bool> Insert(ProductLapTopInformationModel model);
        Task<bool> Delete(int ID);
        Task<ProductLapTopInformationModel> GetById(string ProductCode);


    }
}





