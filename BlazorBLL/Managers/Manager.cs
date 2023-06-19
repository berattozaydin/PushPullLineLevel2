using Microsoft.AspNetCore.Http;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBLL.Managers
{
    public class Manager
    {
        public IIdentity Identity { get; }
        public IDatabase Db { get; }
        public string UserRole { get; }
        public int UserId { get; }
        public Manager(IHttpContextAccessor httpContextAccessor, IDatabase db)
        {
            Identity = httpContextAccessor.HttpContext.User.Identity;
            UserRole = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            UserId = Convert.ToInt32(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Db = db;
        }
    }
}
