using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;

/*******************************************
* 文件说明：用户登陆状态管理
********************************************/

namespace KSOAWeb
{

    public static class UserStateManager
    {
        private static char[] charArray;

        /// <summary>
        /// 管理员Cookie键匹配模式
        /// </summary>
        private static string administatorTokenPattern;

        /// <summary>
        /// 会员Cookie键匹配模式
        /// </summary>
        private static string memberTokenPattern;

        static UserStateManager()
        {
            charArray = new char[] { '_', 'c', 's', 'u', '1', 'g', 'c', 't', 'i', 'l', 'y', 'h', 'o', 'p', '6' };
            StringBuilder sb = new StringBuilder();
            Array.ForEach(charArray, a =>
            {
                sb.Append(a);
            });

            administatorTokenPattern = String.Format("^KSOA_[{0}]+_token$", sb.ToString());
            memberTokenPattern = String.Format("^_token_[{0}]+_$", sb.ToString());
        }
/*
        /// <summary>
        /// 创建随机的COOKIE 
        /// </summary>
        /// <returns></returns>
        private static string GeneratorRandomStr()
        {
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            int arrayLength = charArray.Length;

            int i = 0;
            do
            {
                ++i;
                sb.Append(charArray[rd.Next(0, arrayLength - 1)]);
            }
            while (i < 5);

            return sb.ToString();
        }

        

        #region 系统用户

        public static class Administrator
        {
            /// <summary>
            /// 账户信息
            /// </summary>
            public static SysUser Current
            {
                get
                {
                    SysUser user = HttpContext.Current.Session["admin"] as SysUser;
                    if (user == null)
                    {
                        HttpCookie cookie = null;
                        foreach (var key in HttpContext.Current.Request.Cookies.Keys)
                        {
                            if (Regex.IsMatch(key.ToString(), administatorTokenPattern))
                            {
                                cookie = HttpContext.Current.Request.Cookies[key.ToString()];
                                break;
                            }
                        }
                        if (cookie != null)
                        {
                            byte[] decodedBytes = Convert.FromBase64String(cookie.Value);
                            string[] paramStr = Encoding.UTF8.GetString(decodedBytes).Split('&');
                            string username = paramStr[0],
                                   cookieToken = paramStr[1];

                            user = new SysUserLogic().GetSysUser(username);

                            //用户不存在则返回false
                            if (user == null) return null;

                            //  string token = MD5Helper.Encrypt_MD5(username + "U1City$SHOP" + user.UserPwd);

                            //密钥一致，则登录
                            if (String.Compare(user.UserPwd, cookieToken, true) == 0)
                            {
                                HttpContext.Current.Session["admin"] = user;
                                return user;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return user;
                }
            }

            /// <summary>
            /// 是否登录
            /// </summary>
            public static bool HasLogin { get { return Current != null; } }

            /// <summary>
            /// 系统用户登录
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool Login(string username, string password, double minutes)
            {
                string token = ShopHelper.GenerateManagerEncryptPwd(username, password);
                SysUser user = new SysUserLogic().GetSysUser(username);
                if (user == null || String.Compare(token, user.UserPwd, true) != 0) return false;

                Exit(); //先退出，清除Cookie

                HttpContext.Current.Session["admin"] = user;
                HttpCookie cookie = new HttpCookie(String.Format("u1city_shop_{0}_token", GeneratorRandomStr()));

                cookie.Expires = DateTime.Now.AddMinutes(minutes);

                //保存到Cookie中的密钥

                byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + token);
                string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                cookie.Value = encodedtokenStr;

                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }
            public static int Login1(string username, string password, double minutes)//限制被锁定用户登录
            {
                string token = ShopHelper.GenerateManagerEncryptPwd(username, password);
                SysUser user = new SysUserLogic().GetSysUser(username);
                if (user == null) return -1;
                if (user == null || String.Compare(token, user.UserPwd, true) != 0) return -2;
                if (user.Enable == "N") return -3;

                Exit(); //先退出，清除Cookie

                HttpContext.Current.Session["admin"] = user;
                HttpCookie cookie = new HttpCookie(String.Format("u1city_shop_{0}_token", GeneratorRandomStr()));

                cookie.Expires = DateTime.Now.AddMinutes(minutes);

                //保存到Cookie中的密钥

                byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + token);
                string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                cookie.Value = encodedtokenStr;
                cookie.Path = "/admin/";

                HttpContext.Current.Response.Cookies.Add(cookie);

                return 1;
            }

            /// <summary>
            /// 系统用户登出
            /// </summary>
            public static void Exit()
            {
                SysUser user = Current;
                //移除会话
                HttpContext.Current.Session.Remove("admin");


                //移除Cookie
                HttpResponse response = HttpContext.Current.Response;
                HttpCookie cookie = null;
                var keys = HttpContext.Current.Request.Cookies.Keys;
                int keysLength = keys.Count;
                for (int i = 0; i < keysLength; i++)
                {
                    if (Regex.IsMatch(keys[i].ToString(), administatorTokenPattern))
                    {
                        cookie = HttpContext.Current.Request.Cookies[i];

                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddYears(-1);
                            response.Cookies.Add(cookie);
                        }
                    }
                }
            }
        }

        #endregion

        #region 会员用户

        public static class Member
        {
            /// <summary>
            /// 账户信息
            /// </summary>
            public static CusCustomer Current
            {
                get
                {
                    CusCustomer user = HttpContext.Current.Session["member"] as CusCustomer;
                    if (user == null)
                    {
                        HttpCookie cookie = null;
                        foreach (var key in HttpContext.Current.Request.Cookies.Keys)
                        {
                            if (Regex.IsMatch(key.ToString(), memberTokenPattern))
                            {
                                cookie = HttpContext.Current.Request.Cookies[key.ToString()];
                                break;
                            }
                        }
                        if (cookie != null)
                        {
                            byte[] decodedBytes = Convert.FromBase64String(cookie.Value);
                            string[] paramStr = Encoding.UTF8.GetString(decodedBytes).Split('&');
                            string username = paramStr[0],
                                   cookieToken = paramStr[1];

                            user = new CusCustomerLogic().GetCustomerByUserName(username);

                            //用户不存在则返回false
                            if (user == null) return null;

                            //  string token = MD5Helper.Encrypt_MD5(username + "U1City$SHOP" + user.UserPwd);

                            //密钥一致，则登录
                            if (String.Compare(user.CustomerPassword, cookieToken, true) == 0)
                            {
                                HttpContext.Current.Session["member"] = user;
                                return user;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return user;
                }
            }

            /// <summary>
            /// 是否登录
            /// </summary>
            public static bool HasLogin { get { return Current != null; } }

            /// <summary>
            /// 会员用户登录
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool Login(string username, string password, double minutes)
            {
                string token = ShopHelper.GenerateEncryptPwd(username, password);
                CusCustomer user = new CusCustomerLogic().GetCustomerByUserName(username);
                if (user == null || String.Compare(token, user.CustomerPassword, true) != 0 || user.Status != 1) return false;

                Exit(); //先退出，清除Cookie

                HttpContext.Current.Session["member"] = user;
                HttpCookie cookie = new HttpCookie(String.Format("_token_{0}_", GeneratorRandomStr()));

                cookie.Expires = DateTime.Now.AddMinutes(minutes);

                //保存到Cookie中的密钥

                byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + token);
                string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                cookie.Value = encodedtokenStr;


                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }

            /// <summary>
            /// 通过邮箱，手机，会员用户登录 by ytq 2013 8-1
            /// </summary>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool LoginName(string username, string password, double minutes, string key)
            {
                string verifyuser = String.Empty;
                #region 判断邮箱手机 设置一个默认用户名
                var p = "^0{0,1}1[3|4|5|6|7|8|9][0-9]{9}$";
                Regex rep = new Regex(p);
                var e = @"[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})";
                Regex re = new Regex(e);
                //string key = ShopHelper.CreateNumber(5);
                if (rep.IsMatch(username))
                {

                    //根据手机 设置用户名
                    verifyuser = username + "_P" + "_" + key;
                }
                else if (re.IsMatch(username))
                {//根据邮箱 设置用户名
                    verifyuser = username.Substring(0, username.IndexOf('@')) + "_M" + "_" + key;
                }
                else
                {
                    verifyuser = username;
                }
                #endregion
                string token = ShopHelper.GenerateEncryptPwd(verifyuser, password);
                CusCustomer user = new CusCustomerLogic().GetCustomerByUserName(username);//根据用户名手机邮箱获取顾客信息GetCustomerByLoginName
                if (user == null || String.Compare(token, user.CustomerPassword, true) != 0 || user.Status != 1) return false;

                Exit(); //先退出，清除Cookie

                HttpContext.Current.Session["member"] = user;
                HttpCookie cookie = new HttpCookie(String.Format("_token_{0}_", GeneratorRandomStr()));

                cookie.Expires = DateTime.Now.AddMinutes(minutes);

                //保存到Cookie中的密钥

                byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + token);
                string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                cookie.Value = encodedtokenStr;


                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }

            /// <summary>
            /// 会员用户状态
            /// </summary>
            /// <param name="username"></param>
            /// <returns></returns>
            public static int AccountStatus(string username)
            {//by ytq 2013 8-9 根据用户名手机邮箱获取顾客信息
                CusCustomer user = new CusCustomerLogic().GetCustomerByLoginName(username);
                //CusCustomer user = new CusCustomerLogic().GetCustomerByUserName(username);
                return Convert.ToInt32(user.Status);
            }



            /// <summary>
            /// SSO登录
            /// </summary>
            /// <param name="token"></param>
            /// <param name="mediaUserID"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool SSOLogin(string token, string mediaUserID, double minutes)
            {

                var sso = new global::U1City.Shop.WebBusiness.LoginFastLogic();
                CusCustomer user = sso.GetUserByMediaUserID(mediaUserID, token);


                if (user != null)
                {

                    string userName = user.CustomerName,
                        ssoPwdToken = user.CustomerPassword;

                    Exit(); //先退出，清除Cookie

                    HttpContext.Current.Session["member"] = user;
                    HttpCookie cookie = new HttpCookie(String.Format("_token_{0}_", GeneratorRandomStr()));

                    cookie.Expires = DateTime.Now.AddMinutes(minutes);

                    //保存到Cookie中的密钥

                    byte[] encodeBytes = Encoding.UTF8.GetBytes(userName + "&" + ssoPwdToken);
                    string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                    cookie.Value = encodedtokenStr;

                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return true;

                }

                return false;
            }

            /// <summary>
            /// 会员用户登录
            /// </summary>
            /// <param name="username"></param>
            /// <param name="loginToken"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool TokenLogin(string username, string loginToken, double minutes)
            {
                WebBusiness.CusCustomerLogic logic = new WebBusiness.CusCustomerLogic();
                if (logic.VerifyLoginUseToken(username, loginToken))
                {

                    CusCustomer user = new CusCustomerLogic().GetCustomerByUserName(username);

                    Exit(); //先退出，清除Cookie

                    HttpContext.Current.Session["member"] = user;
                    HttpCookie cookie = new HttpCookie(String.Format("_token_{0}_", GeneratorRandomStr()));

                    cookie.Expires = DateTime.Now.AddMinutes(minutes);

                    //保存到Cookie中的密钥

                    byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + user.CustomerPassword);
                    string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                    cookie.Value = encodedtokenStr;

                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return true;
                }
                return false;
            }


            /// <summary>
            /// 会员用户手机邮箱登录 by ytq 2013 8-10
            /// </summary>
            /// <param name="username"></param>
            /// <param name="loginToken"></param>
            /// <param name="minutes"></param>
            /// <returns></returns>
            public static bool TokenUserLogin(string username, string loginToken, double minutes)
            {
                WebBusiness.CusCustomerLogic logic = new WebBusiness.CusCustomerLogic();
                if (logic.VerifyLoginUseToken(username, loginToken))
                {

                    CusCustomer user = new CusCustomerLogic().GetCustomerByLoginName(username);

                    Exit(); //先退出，清除Cookie

                    HttpContext.Current.Session["member"] = user;
                    HttpCookie cookie = new HttpCookie(String.Format("_token_{0}_", GeneratorRandomStr()));

                    cookie.Expires = DateTime.Now.AddMinutes(minutes);

                    //保存到Cookie中的密钥

                    byte[] encodeBytes = Encoding.UTF8.GetBytes(username + "&" + user.CustomerPassword);
                    string encodedtokenStr = Convert.ToBase64String(encodeBytes);

                    cookie.Value = encodedtokenStr;

                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return true;
                }
                return false;
            }


            /// <summary>
            /// 会员用户登出
            /// </summary>
            public static void Exit()
            {
                CusCustomer user = Current;
                //移除会话
                HttpContext.Current.Session.Remove("member");


                //移除Cookie
                HttpResponse response = HttpContext.Current.Response;
                HttpCookie cookie = null;
                var keys = HttpContext.Current.Request.Cookies.Keys;
                int keysLength = keys.Count;
                for (int i = 0; i < keysLength; i++)
                {
                    if (Regex.IsMatch(keys[i].ToString(), memberTokenPattern))
                    {
                        cookie = HttpContext.Current.Request.Cookies[i];

                        if (cookie != null)
                        {
                            cookie.Expires = DateTime.Now.AddYears(-1);
                            response.Cookies.Add(cookie);
                        }
                    }
                }
            }
        }

        #endregion
*/
    }

}
