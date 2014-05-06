using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Admin_ChannelInfoLogic : DbAccess
    {
        /// <summary>
        /// 根据ID获取CP信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Admin_ChannelInfo GetCPbyID(int id)
        {
            var result = _db.Admin_ChannelInfo.Where(s => s.ID == id).Select(s => new Admin_ChannelInfo { ID = s.ID,ChannelName = s.ChannelName, AddTime = s.AddTime, IsDelete = s.IsDelete }).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// 更新CP信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateCPbyID(int id, string ChannelName)
        {
            var result = _db.Admin_ChannelInfo.Where(s => s.ID == id).FirstOrDefault();
            result.ChannelName = ChannelName;
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
        /// 获取CP列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_ChannelInfo> GetCpList()
        {
            var result = _db.Admin_ChannelInfo.Where(s => s.IsDelete == false).Select(s => new Admin_ChannelInfo { ID = s.ID, ChannelName = s.ChannelName, AddTime = s.AddTime, IsDelete = s.IsDelete }).ToList();
            return result;
        }

        /// <summary>
        /// 获取CP分页列表
        /// </summary>
        /// <returns></returns>
        public List<Admin_ChannelInfo> GetCpList(int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Admin_ChannelInfo.Where(s => s.IsDelete == false).Select(s => new Admin_ChannelInfo { ID = s.ID, ChannelName = s.ChannelName, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.ChannelName);
            totalCount = query.Count();
            var list = new List<Admin_ChannelInfo>();
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
        public bool AddCP(Admin_ChannelInfo acp)
        {
            DataAccess.Admin_ChannelInfo cp = new DataAccess.Admin_ChannelInfo();
            cp.ChannelName = acp.ChannelName;
            cp.AddTime = DateTime.Now;
            _db.Admin_ChannelInfo.AddObject(cp);
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
        /// 标记制定的CPid为删除
        /// </summary>
        /// <returns></returns>
        public bool DelCP(int[] ids)
        {
            var result = from c in _db.Admin_ChannelInfo
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
    }
}
