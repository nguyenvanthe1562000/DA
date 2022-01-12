using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using Newtonsoft.Json;
using Service.Admin.Service;
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
    [Authorize]
    [ApiController]
    public class vOpenInventoryController : ControllerBase
    {
        private readonly IvOpenInventoryService _vOpenInventoryService;

        public vOpenInventoryController(IvOpenInventoryService vOpenInventory)
        {
            _vOpenInventoryService = vOpenInventory;
        }
        [HttpPost]
        [Route("insert")]
        [ClaimRequirement(ClaimFunction.OPENINVENTORY, ClaimAction.CANCREATE)]
        public async Task<IActionResult> Insert([FromBody] vOpenInventoryModel model)
        {
            try
            {
                var response = await _vOpenInventoryService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - vOpenInventoryApi," + ex.InnerException.InnerException.Message + "");
            }
        }








        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _vOpenInventoryService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - vOpenInventoryApi," + ex.InnerException.InnerException.Message + "");
            }
        }






        [HttpGet]
        [Route("GetById/{ID}")]
        public async Task<IActionResult> GetById([FromRoute] int ID)
        {
            try
            {
                var responseData = await _vOpenInventoryService.GetById(ID);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - vOpenInventoryApi," + ex.InnerException.InnerException.Message + "");
            }
        }




    }
}











