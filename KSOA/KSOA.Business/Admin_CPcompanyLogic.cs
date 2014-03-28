using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSOA.Model;

namespace KSOA.Business
{
    public class Admin_CPcompanyLogic : DbAccess
    {
        /// <summary>
        /// 获取CP列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_CPcompany> GetCpList()
        {
            var result = _db.Admin_CPcompany.Select(s => new Admin_CPcompany { ID = s.ID, CPname = s.CPname, AddTime = s.AddTime, IsDelete = s.IsDelete }).ToList();
            return result;
        }

        /// <summary>
        /// 获取CP分页列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_CPcompany> GetCpList(int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Admin_CPcompany.Select(s => new Admin_CPcompany { ID = s.ID, CPname = s.CPname, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.CPname);
            totalCount = query.Count();
            var list = new List<Admin_CPcompany>();
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
        /// 新增CP
        /// </summary>
        /// <param name="acp"></param>
        /// <returns></returns>
        public bool AddCP(Admin_CPcompany acp)
        {
            DataAccess.Admin_CPcompany cp = new DataAccess.Admin_CPcompany();
            cp.CPname = acp.CPname;
            cp.AddTime = DateTime.Now;
            _db.Admin_CPcompany.AddObject(cp);
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
