using KSOA.Model;
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
        public Admin_KSCustomer CheckLogin(string UserName, string PassWord)
        {
            Admin_KSCustomer result = _db.Admin_KSCustomer.Where(s => s.CusName == UserName && s.CusPwd == PassWord && s.IsDelete == false).Select(s => new Admin_KSCustomer { ID = s.ID, RoleID = s.RoleID, RealName = s.RealName, CusName = s.CusName, Gender = s.Gender, Age = s.Age, CusEmail = s.CusEmail, CusPhoneNum = s.CusPhoneNum, QQ = s.QQ }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 更新用户(密码)信息
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public bool UpdateCusInfo(Admin_KSCustomer cus)
        {
            var customer = _db.Admin_KSCustomer.Where(s => s.CusName == cus.CusName && s.CusPwd == cus.Oldcuspwd && s.IsDelete == false).FirstOrDefault();
            if (customer != null)
            {
                customer.CusPwd = cus.CusPwd;
            }
            int result = _db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
