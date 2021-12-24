using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface INguoiDungRepository
    {
        NguoiDungModel GetUser(string username, string password);
        List<NguoiDungModel> GetDataAllPaginate(int pageIndex, int pageSize, out long total);
        NguoiDungModel GetDatabyID(string id);
        bool Create(NguoiDungModel model);
        bool Update(NguoiDungModel model);
        bool Delete(string user_id);
        List<PermisionDetailModel> GetRoles(string Code);
        List<NguoiDungModel> Search(int pageIndex, int pageSize, out long total, string hoTen, string taiKhoan);
    }
}
