using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WxService.model;

namespace WxService
{
    public class WxUtil
    {
        private static readonly object Flag = new object();
        public static WxUtil _WxUtil = null;
        private static string _Url = "https://api.weixin.qq.com/";
        private static string _AppID = "wxd3240bd59f9cbb64";
        private static string _AppSecret = "1a8a14dc7e5af8c8b340ef32c1fd08bc";

        public WxUtil()
        {
        }

        public WxUtil(string appID, string appSecret)
        {
            _AppID = appID;
            _AppSecret = appSecret;
        }

        public static WxUtil GetInstance(string appID = "wxd3240bd59f9cbb64", string appSecret = "1a8a14dc7e5af8c8b340ef32c1fd08bc")
        {
            //判断是否实例化过
            if (_WxUtil == null)
            {
                //进入lock
                lock (Flag)
                {
                    //判断是否实例化过
                    if (_WxUtil == null)
                    {
                        _WxUtil = new WxUtil(appID, appSecret);
                    }
                }
            }
            return _WxUtil;
        }

        /// <summary>
        /// 获取token,现在已经放入session中，后期放入数据库中
        /// </summary>
        /// <returns></returns>
        public async Task<WxToken> GetAccessToken()
        {
            var old = new WxToken()
            {
                access_token = "23_HV3iR9AEgaIBO2d2K7-r7lDXwfIzY5akCSNB8vXpTFETLtCjg8QpxN90_jhqg4VGPfNdOYHAxDcZjLIoKVw4UmnDw-IsBN9YrB33es0Ydh6CWojs5kkn6etbL1Y-sN1Q3YTfll1dNRg4ddMlEKDjAHAWCV",
                expires_in = 7200
            };
            return old;
            // var url = _Url +
            // $"cgi-bin/token?grant_type=client_credential&appid={_AppID}&secret={_AppSecret}";
            // return await HttpUtil.GetAsync<WxToken>(url);
        }
    }
}