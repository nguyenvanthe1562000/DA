using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Newtonsoft.Json;
using Service.Admin.Service.Interface;
using ShopVT.Extensions;
using ShopVT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisionController :ControllerBase
    {
        private readonly IPermisionService _PermisionService;

        public PermisionController(IPermisionService Permision)
        {
            _PermisionService = Permision;
        }
        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] PermisionModel model)
        {
            try
            {   
                var response =  _PermisionService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - PermisionApi," + ex.InnerException.InnerException.Message + "");
            }
        }









        [HttpDelete]
        [Route("delete/{ID}")]
        public IActionResult Delete([FromRoute] int ID)
        {
            try
            {
                var response =  _PermisionService.Delete(ID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- PermisionApi," + ex.InnerException.InnerException.Message + "");

            }
        }







        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                var response =  _PermisionService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - PermisionApi," + ex.InnerException.InnerException.Message + "");
            }
        }



        /// 












    }
}











