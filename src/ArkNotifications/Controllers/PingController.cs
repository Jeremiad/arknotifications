using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

namespace ArkNotifications.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}
