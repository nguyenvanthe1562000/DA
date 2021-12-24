//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Model.Model;
//using Newtonsoft.Json;
//using Service.Admin.Service.Interface;
//using ShopVT.Extensions;
//using ShopVT.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShopVT.Controllers.Admin
//{
//    [Route("api/[controller]")]
//   [Authorize]
//    [ApiController]
//    public class ProductInformationController : ControllerBase
//    {
//        private readonly IProductInformationService _ProductInformationService;

//        public ProductInformationController(IProductInformationService ProductInformation)
//        {
//            _ProductInformationService=ProductInformation;
//        }
//                [HttpPost]
//[Route("insert")]
//[ClaimRequirement(ClaimFunction.CHAT, ClaimAction.CANREAD)]
//public async Task<IActionResult> Insert([FromBody] ProductInformationModel model)
//{
//      try
//      {
//            var response =await _ProductInformationService.Insert(model,GetUserId());
//            return Ok(response);
//      }
//      catch (Exception ex)
//      {
//            return BadRequest("Error at method: insert - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//      }
//}
        





//                        [HttpPut]
//        [Route("Update")]
//[ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANUPDATE)]
//         public async Task<IActionResult> Update ([FromBody] ProductInformationModel model)
//        {
//            try
//            {
//                var responseData =await _ProductInformationService.Update(model,GetUserId());
//                return Ok(responseData);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Error at method: Update - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//            }
//        }    





                
//                [HttpGet]
//[Route("get-all")]
//[ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
// public async Task<IActionResult> GetAll()
//{
//    try
//    {
//        var response =await _ProductInformationService.GetAll();
//        return Ok(response);
//    }   
//    catch(Exception ex)
//    {
//        return BadRequest("Error at method: GetAll - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//    }
//}



//                /// <summary> </summary>
// /// <param name="fr_CreatedAt">kiểu dữ liệu DateTime</param>
// /// <param name="to_CreatedAt">kiểu dữ liệu DateTime</param>
///// <returns> </returns>

//[HttpGet]
//[Route("search")]
// public IActionResult Search(string data)
//      {
//            try
//            {
//                var fromData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
//    DateTime _fr_CreatedAt = default;
//if (fromData.Keys.Contains("fr_CreatedAt") && fromData["fr_CreatedAt"] != null && fromData["fr_CreatedAt"].ToString() != "")
//{
//var dt  = Convert.ToDateTime(fromData["fr_CreatedAt"].ToString());
//if (dt != null)
//_fr_CreatedAt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
//}
//DateTime _to_CreatedAt = default;
//if (fromData.Keys.Contains("to_CreatedAt") && fromData["to_CreatedAt"] != null && fromData["to_CreatedAt"].ToString() != "")
//{
//var dt  = Convert.ToDateTime(fromData["to_CreatedAt"].ToString());
//if (dt != null)
//_to_CreatedAt = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
//}

//                var response = _ProductInformationService.Search(_fr_CreatedAt, _to_CreatedAt);
//                return Ok(response);
//      }
//      catch (Exception ex)
//      {
//             return BadRequest("Error at method: Search - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//      }
//}
        






// [ClaimRequirement(ClaimFunction.ADMINACCOUNT, ClaimAction.CANCREATE)]
//        [HttpPost]
//        [Route("Paging")]
//        public async Task<IActionResult> Paging([FromBody] PagingRequestBase pagingRequest)
//        {
//            try
//            {
//                var response = await _ProductInformationService.Paging(pagingRequest);
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest("Error at method: GetAllForPaging - PostApi," + ex.InnerException.InnerException.Message + "");
//            }
//        }






//                [HttpPut]
//[Route("save-from-list")]
//public IActionResult SaveFromList([FromBody] List<ProductInformationModel> listjson_ProductInformation)
//{
//      try
//      {
//    string _listjson_ProductInformation = listjson_ProductInformation != null ? JsonConvert.SerializeObject( listjson_ProductInformation ) :null;
//            var response = _ProductInformationService.SavefromList(_listjson_ProductInformation);
//            return Ok(response);
//      }
//      catch (Exception ex)
//      {
//            return BadRequest("Error at method: SaveFromList - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//      }
//}




//                [HttpGet]
//[Route("GetById/{CategoryCode}")]
//[ClaimRequirement(ClaimFunction.FUNCTION, ClaimAction.CANREAD)]
// public async Task<IActionResult> GetById ([FromUri] string CategoryCode)
//{
//    try
//    {
//        var responseData =await _ProductInformationService.GetById(CategoryCode);
//        return Ok(responseData);
//    }
//    catch (Exception ex)
//    {
//        return BadRequest("Error at method: GetById - ProductInformationApi," + ex.InnerException.InnerException.Message + "");
//    }
//}




//    }
//}











