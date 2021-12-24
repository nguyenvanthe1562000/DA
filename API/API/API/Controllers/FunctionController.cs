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
    [Authorize]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _FunctionService;

        public FunctionController(IFunctionService Function)
        {
            _FunctionService = Function;
        }

        [HttpGet]
        [Route("get-all")]

        public IActionResult GetAll()
        {
            try
            {
                var response = _FunctionService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Error at method: GetAll - FunctionApi," + ex.InnerException.InnerException.Message + "");
            }
        }



    }
}











