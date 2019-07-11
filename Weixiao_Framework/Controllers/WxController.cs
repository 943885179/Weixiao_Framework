using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WxService;
using WxService.model;

namespace Weixiao_Framework.Controllers
{
    public class WxController : ApiController
    {
        private static WxUtil wx = WxUtil.GetInstance();

        [HttpGet]
        public async Task<WxToken> GetToken()
        {
            // var token =new HttpCookie("qwe");
            var s = HttpContext.Current;
            var wxToken = HttpContext.Current.Session["WxToken"] as WxToken;
            if (wxToken == null)
            {
                var result = await wx.GetAccessToken();
                if (result.errcode == 0)
                {
                    HttpContext.Current.Session["WxToken"] = result;
                    HttpContext.Current.Session.Timeout = result.expires_in / 60;
                }
                return result;
            }
            else
            {
                return wxToken;
            }
        }
    }
}