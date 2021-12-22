
using Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Service.Admin.Service.Interface

{
    public interface ITinTucService
    {
        bool Insert(TinTucModel model);

        bool Update(TinTucModel model);

        bool Delete(string ID);
        public List<TinTucModel> GetTinTucPaging(int pageIndex, int pageSize, out long total);

        List<TinTucModel> GetAll();






        TinTucModel GetById(string ID);

    }
}












