using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Reponsitory.Interface;
using Model.Model;
using Service.Admin.Service.Interface;

namespace Service.Admin.Service
{
    public class vOpenInventoryService : IvOpenInventoryService
    {
        private IvOpenInventoryRepository _vOpenInventoryRepository;
        public vOpenInventoryService(IvOpenInventoryRepository vOpenInventory)
        {
            _vOpenInventoryRepository = vOpenInventory;
        }

        public async Task<bool> Insert(vOpenInventoryModel model)
        {
            return await _vOpenInventoryRepository.Insert(model);
        }

        public async Task<List<vOpenInventoryModel>> GetAll()
        {
            var result = _vOpenInventoryRepository.GetAll();
            return await result;
        }

        public async Task<vOpenInventoryModel> GetById(int ID)
        {
            var result = _vOpenInventoryRepository.GetById(ID);
            return await result;
        }



    }
}










