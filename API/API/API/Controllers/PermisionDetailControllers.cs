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
    public class PermisionDetailController : ControllerBase
    {
        private readonly IPermisionDetailService _PermisionDetailService;

        public PermisionDetailController(IPermisionDetailService PermisionDetail)
        {
            _PermisionDetailService = PermisionDetail;
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] PermisionDetailModel model)
        {
            try
            {
                var response = await _PermisionDetailService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - PermisionDetailApi," + ex.InnerException.InnerException.Message + "");
            }
        }











        [HttpDelete]
        [Route("delete/{ID}")]
        public async Task<IActionResult> Delete([FromRoute] int ID)
        {
            try
            {
                var response = await _PermisionDetailService.Delete(ID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- PermisionDetailApi," + ex.InnerException.InnerException.Message + "");

            }
        }







        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _PermisionDetailService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - PermisionDetailApi," + ex.InnerException.InnerException.Message + "");
            }
        }










        [HttpGet]
        [Route("GetById/{ID}")]
        public async Task<IActionResult> GetById([FromRoute] int ID)
        {
            try
            {
                var responseData = await _PermisionDetailService.GetById(ID);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - PermisionDetailApi," + ex.InnerException.InnerException.Message + "");
            }
        }




    }
}











