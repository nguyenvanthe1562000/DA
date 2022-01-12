using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Admin.Service
{
    public class PermisionDetailService : IPermisionDetailService
    {
        private IPermisionDetailRepository _PermisionDetailRepository;
        public PermisionDetailService(IPermisionDetailRepository PermisionDetail)
        {
            _PermisionDetailRepository = PermisionDetail;
        }

        public async Task<bool> Insert(PermisionDetailModel model)
        {

            return await _PermisionDetailRepository.Insert(model);
        }



        public async Task<bool> Delete(int ID)
        {
            return await _PermisionDetailRepository.Delete(ID);
        }


        public async Task<List<PermisionDetailModel>> GetAll()
        {
            var result = _PermisionDetailRepository.GetAll();
            return await result;
        }

        public async Task<PermisionDetailModel> GetById(int ID)
        {
            var result = _PermisionDetailRepository.GetById(ID);
            return await result;
        }



    }
}










