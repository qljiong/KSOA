using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Admin_KSCustomerLogic : DbAccess
    {
        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <returns>0:登陆失败;1:登陆成功</returns>
        public int CheckLogin(string UserName, string PassWord)
        {
            var result = _db.Admin_KSCustomer.Where(s => s.CusName == UserName && s.CusPwd == PassWord).FirstOrDefault();
            if (result == null)
            {
                return 0;
            }
            return 1;
        }
    }
}
