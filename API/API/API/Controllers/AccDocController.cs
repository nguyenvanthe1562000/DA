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
    //[Authorize]
    [ApiController]
    public class AccDocController : ControllerBase
    {
        private readonly IAccDocService _AccDocService;

        public AccDocController(IAccDocService AccDoc)
        {
            _AccDocService = AccDoc;
        }
        [HttpPost]
        [Route("insert")]
        [ClaimRequirement(ClaimFunction.ACCDOC, ClaimAction.CANCREATE)]
        public  IActionResult Insert([FromBody] AccDocModel model)
        {
            try
            {
                var response =  _AccDocService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - AccDocApi," + ex.InnerException.InnerException.Message + "");
            }
        }


        [HttpDelete]
        [Route("delete/{ID}")]
        [ClaimRequirement(ClaimFunction.ACCDOC, ClaimAction.CANDELETE)]
        public async Task<IActionResult> Delete([FromRoute] int ID)
        {
            try
            {
                var response = await _AccDocService.Delete(ID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- AccDocApi," + ex.InnerException.InnerException.Message + "");

            }
        }

        [HttpGet]
        [Route("get-all")]
        public  IActionResult GetAll()
        {
            try
            {
                var response =  _AccDocService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - AccDocApi," + ex.InnerException.InnerException.Message + "");
            }
        }











        [HttpGet]
        [Route("GetById/{ID}")]
        
        public  IActionResult GetById([FromRoute] int ID)
        {
            try
            {
                var responseData =  _AccDocService.GetById(ID);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - AccDocApi," + ex.InnerException.InnerException.Message + "");
            }
        }




    }
}











