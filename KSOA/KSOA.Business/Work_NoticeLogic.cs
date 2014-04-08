using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Work_NoticeLogic : DbAccess
    {
        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Work_Notice> GetNoticeList(int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Work_Notice.Where(s => s.IsDelete == false).Select(s => new Work_Notice { ID = s.ID, AddTime = s.AddTime, IsDelete = s.IsDelete, NTitle = s.NTitle, NContent = s.NContent, NCustomerID = s.NCustomerID, NCustomerName = s.NCustomerName, Nlevel = s.Nlevel }).OrderByDescending(s => s.AddTime);
            totalCount = query.Count();
            var list = new List<Work_Notice>();
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
        /// 新增公告
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public bool AddNotice(Work_Notice wn, Admin_KSCustomer aks)
        {
            DataAccess.Work_Notice wnote = new DataAccess.Work_Notice();
            wnote.NTitle = wn.NTitle;
            wnote.NContent = wn.NContent;
            wnote.AddTime = DateTime.Now;
            wnote.NCustomerID = aks.ID;
            wnote.NCustomerName = aks.CusName;
            wnote.Nlevel = wnote.Nlevel;
            _db.Work_Notice.AddObject(wnote);
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
        /// 编辑公告
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public bool EditNotice(Work_Notice wn, Admin_KSCustomer aks,int id)
        {
            DataAccess.Work_Notice wnote = _db.Work_Notice.Where(s => s.ID == id).FirstOrDefault();
            wnote.NTitle = wn.NTitle;
            wnote.NContent = wn.NContent;
            wnote.NCustomerID = aks.ID;
            wnote.NCustomerName = aks.CusName;
            wnote.Nlevel = wnote.Nlevel;
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
        /// 获取公告对象
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public Work_Notice GetNoticeModel(int id)
        {
            var query = _db.Work_Notice.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Work_Notice { ID = s.ID, AddTime = s.AddTime, IsDelete = s.IsDelete, NTitle = s.NTitle, NContent = s.NContent, NCustomerID = s.NCustomerID, NCustomerName = s.NCustomerName, Nlevel = s.Nlevel }).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// 标记制定的noticeid为删除
        /// </summary>
        /// <returns></returns>
        public bool Delnotice(int[] ids)
        {
            var result = from c in _db.Work_Notice
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
