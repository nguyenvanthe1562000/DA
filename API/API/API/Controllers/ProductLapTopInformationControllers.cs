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
    public class ProductLapTopInformationController : ControllerBase
    {
        private readonly IProductLapTopInformationService _ProductLapTopInformationService;

        public ProductLapTopInformationController(IProductLapTopInformationService ProductLapTopInformation)
        {
            _ProductLapTopInformationService = ProductLapTopInformation;
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] ProductLapTopInformationModel model)
        {
            try
            {
                var response = await _ProductLapTopInformationService.Insert(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: insert - ProductLapTopInformationApi," + ex.InnerException.InnerException.Message + "");
            }
        }

        [HttpDelete]
        [Route("delete/{ID}")]
        public async Task<IActionResult> Delete([FromRoute] int ID)
        {
            try
            {
                var response = await _ProductLapTopInformationService.Delete(ID);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: Delete- ProductLapTopInformationApi," + ex.InnerException.InnerException.Message + "");

            }
        }


        [HttpGet]
        [Route("GetById/{ProductCode}")]
        public async Task<IActionResult> GetById([FromRoute] string ProductCode)
        {
            try
            {
                var responseData = await _ProductLapTopInformationService.GetById(ProductCode);
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetById - ProductLapTopInformationApi," + ex.InnerException.InnerException.Message + "");
            }
        }

    }
}











