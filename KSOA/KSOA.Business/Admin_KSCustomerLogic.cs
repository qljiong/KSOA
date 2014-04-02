using KSOA.Model;
using KSOA.Common;
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
            Admin_KSCustomer result = _db.Admin_KSCustomer.Where(s => s.CusName == UserName && s.CusPwd == PassWord && s.IsDelete == false).Select(s => new Admin_KSCustomer { ID = s.ID, RoleID = s.RoleID, RealName = s.RealName, CusName = s.CusName, Gender = s.Gender, Age = s.Age??0, CusEmail = s.CusEmail, CusPhoneNum = s.CusPhoneNum, QQ = s.QQ }).FirstOrDefault();
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

        /// <summary>
        /// 获取人员信息列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_KSCustomer> GetPopList(int PageSize, int PageIndex, out int totalCount)
        {
            //过滤Admin的role1
            var query = _db.Admin_KSCustomer.Where(s => s.IsDelete == false && s.RoleID != (int)KSOAEnum.Role.超级管理).Select(s => new Admin_KSCustomer { ID = s.ID, RealName = s.RealName, CusName = s.CusName, Gender = s.Gender, Age = s.Age??0, CusPwd = s.CusPwd, CusEmail = s.CusEmail, CusPhoneNum = s.CusPhoneNum, QQ = s.QQ, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.CusName);
            totalCount = query.Count();
            var list = new List<Admin_KSCustomer>();
            if (PageIndex < 0 || PageSize < 0)
            {
                return null;
            }
            if (PageIndex == 1 && PageSize > totalCount)
            {
                list = query.ToList();
            }
            else if (PageIndex == 1 && PageSize > 0)
            {
                list = query.Take(PageSize).ToList();
            }
            else
            {
                list = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            }
            return list;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin_KSCustomer GetCusbyID(int id)
        {
            var query = _db.Admin_KSCustomer.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Admin_KSCustomer { ID = s.ID, RealName = s.RealName, CusName = s.CusName, Gender = s.Gender, Age = s.Age??0, CusPwd = s.CusPwd, CusEmail = s.CusEmail, CusPhoneNum = s.CusPhoneNum, QQ = s.QQ, AddTime = s.AddTime, IsDelete = s.IsDelete }).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Admin_KSCustomer GetCusbyCusName(string Name)
        {
            var query = _db.Admin_KSCustomer.Where(s => s.IsDelete == false && s.CusName == Name).Select(s => new Admin_KSCustomer { ID = s.ID, RealName = s.RealName, CusName = s.CusName, Gender = s.Gender, Age = s.Age ?? 0, CusPwd = s.CusPwd, CusEmail = s.CusEmail, CusPhoneNum = s.CusPhoneNum, QQ = s.QQ, AddTime = s.AddTime, IsDelete = s.IsDelete }).FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 根据用户ID假删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelCusByID(int[] ids)
        {
            var result = from c in _db.Admin_KSCustomer
                         where ids.Contains<int>(c.ID)
                         select c;
            foreach (var item in result)
            {
                item.IsDelete = true;
            }
            int re = _db.SaveChanges();
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 编辑人员信息
        /// </summary>
        /// <returns></returns>
        public bool EditCusInfo(Admin_KSCustomer cus, int id)
        {
            var customer = _db.Admin_KSCustomer.Where(s => s.ID == id && s.IsDelete == false).FirstOrDefault();
            if (customer != null)
            {
                customer.RealName = cus.RealName;
                customer.CusName = cus.CusName;
                customer.Gender = cus.Gender;
                customer.Age = cus.Age;
                customer.CusPwd = cus.CusPwd;
                customer.CusEmail = cus.CusEmail;
                customer.CusPhoneNum = cus.CusPhoneNum;
                customer.QQ = cus.QQ;
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

        /// <summary>
        /// 新增人员信息
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public bool AddCusInfo(Admin_KSCustomer cus)
        {
            DataAccess.Admin_KSCustomer customer = new DataAccess.Admin_KSCustomer();
            if (customer != null)
            {
                customer.RealName = cus.RealName;
                customer.RoleID = (int)KSOAEnum.Role.普通员工;
                customer.CusName = cus.CusName;
                customer.Gender = cus.Gender;
                customer.Age = cus.Age;
                customer.CusPwd = cus.CusPwd;
                customer.CusEmail = cus.CusEmail;
                customer.CusPhoneNum = cus.CusPhoneNum;
                customer.QQ = cus.QQ;
            }
            _db.Admin_KSCustomer.AddObject(customer);
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
