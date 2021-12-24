using DAL;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using Helper;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Model.Model;

namespace BLL
{
    public class NguoiDungBussiness : INguoiDungBussiness
    {
        private INguoiDungRepository _res;
        private IConfiguration _config;
        private string Secret;
        public NguoiDungBussiness(INguoiDungRepository res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _config=configuration;
            _res = res;
        }
        public List<NguoiDungModel> GetDataAllPaginate(int pageIndex, int pageSize, out long total)
        {
            return _res.GetDataAllPaginate(pageIndex, pageSize, out total);
        }
        public bool Delete(string user_id)
        {
            return _res.Delete(user_id);
        }
        public NguoiDungModel Authenticate(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.HoTen.ToString()),
            //        new Claim(ClaimTypes.NameIdentifier, user.role),
            //        new Claim(ClaimTypes.Role,JsonConvert.SerializeObject(user.listjson_Roles))
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            var token = GenerateJSONWebToken(user);
            user.token = token;

            return user;

        }

        private string GenerateJSONWebToken(NguoiDungModel user)
        {

            //var json = Task.Run(() =>
            //{
            //    var rolesModel = JsonConvert.DeserializeObject<List<RolesModel>>(identity.Roles);
            //    List<Roles> listRoles = new List<Roles>();
            //    foreach (var item in rolesModel)
            //    {
            //        Roles roles = new Roles();
            //        roles.Function = item.FunctionCode;
            //        roles.CanRead = item.CanRead ? ClaimAction.CANREAD : "";
            //        roles.CanCreate = item.CanCreate ? ClaimAction.CANCREATE : "";
            //        roles.CanUpdate = item.CanUpdate ? ClaimAction.CANUPDATE : "";
            //        roles.CanDelete = item.CanDelete ? ClaimAction.CANDELETE : "";
            //        roles.CanReport = item.CanReport ? ClaimAction.CANREPORT : "";
            //        listRoles.Add(roles);

            //    }
            //    return JsonConvert.SerializeObject(listRoles);
            //});
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>() {
                     new Claim(ClaimTypes.Name, user.HoTen.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.role.ToString()),
                    new Claim(ClaimTypes.Role,JsonConvert.SerializeObject(user.listjson_Roles).ToString())
                 };
         
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public NguoiDungModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NguoiDungModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NguoiDungModel model)
        {
            return _res.Update(model);
        }
        public List<NguoiDungModel> Search(int pageIndex, int pageSize, out long total, string hoTen, string taiKhoan)
        {
            return _res.Search(pageIndex, pageSize, out total, hoTen, taiKhoan);
        }

        public List<PermisionDetailModel> GetRoles(string Code)
        {
            throw new NotImplementedException();
        }
    }
}
