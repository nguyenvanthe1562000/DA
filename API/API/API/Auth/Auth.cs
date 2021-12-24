
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model;
using Model.Model;
using Newtonsoft.Json;
using ShopVT.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class ClaimRequirementAttribute : TypeFilterAttribute
{
    public ClaimRequirementAttribute(string function, string action) : base(typeof(ClaimRequirementFilter))
    {
        Arguments = new object[] { new Claim(function, action) };
    }
}

public class ClaimRequirementFilter : IAuthorizationFilter
{
    readonly Claim _claim;

    public ClaimRequirementFilter(Claim claim)
    {
        _claim = claim;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        var userCode = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (userCode.Equals("Admin"))
        {
            return;
        }
        else
        {
            var getroles = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;//get role of user của token
            if (getroles is null)
            {
                context.Result = new ForbidResult();
                return;
            }
            var roles = JsonConvert.DeserializeObject<List<PermisionDetailModel>>(getroles).ToList();
            if (roles.Exists(c => c.functionCode == _claim.Type))
            {
                if (roles.Exists(c => c.CanCreate == true))
                {
                    context.Result = new ForbidResult();

                }
                else if (roles.Exists(c => c.CanRead == true))
                {
                    context.Result = new ForbidResult();
                }
                else if (roles.Exists(c => c.Canupdate == true))
                {
                    context.Result = new ForbidResult();
                }
                else if (roles.Exists(c => c.Candelete == true))
                {
                    context.Result = new ForbidResult();
                }
                else //if (roles.Exists(c => c.CanReport == _claim.Value))
                {
                    context.Result = new ForbidResult();
                }

            }

        }
    }
}