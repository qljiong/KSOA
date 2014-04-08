using KSOA.Common;
using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Bank_OpusLogic : DbAccess
    {
        /// <summary>
        ///获取作品分页列表
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Bank_Opus> GetOpusList(KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            string strtype = ntype.ToString();
            var query = _db.Bank_Opus.Where(s => s.IsDelete == false).Select(s => new Bank_Opus { ID = s.ID, OpTitle = s.OpTitle, OpBeginTime = s.OpBeginTime, OpAuthor = s.OpAuthor, OpType = s.OpType, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

            if (strtype != "A")
            {
                query = _db.Bank_Opus.Where(s => s.IsDelete == false && s.OpType == strtype).Select(s => new Bank_Opus { ID = s.ID, OpTitle = s.OpTitle, OpBeginTime = s.OpBeginTime, OpAuthor = s.OpAuthor, OpType = s.OpType, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);
            }

            totalCount = query.Count();
            var list = new List<Bank_Opus>();
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
        /// 选取作品
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Bank_Opus> GetOpusList(string keyword,KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            string strtype = ntype.ToString();
            var query = _db.Bank_Opus.Where(s => s.IsDelete == false && s.OpTitle.Contains(keyword)).Select(s => new Bank_Opus { ID = s.ID, OpTitle = s.OpTitle, OpBeginTime = s.OpBeginTime, OpAuthor = s.OpAuthor, OpType = s.OpType, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

            if (strtype != "A")
            {
                query = _db.Bank_Opus.Where(s => s.IsDelete == false && s.OpType == strtype && s.OpTitle.Contains(keyword)).Select(s => new Bank_Opus { ID = s.ID, OpTitle = s.OpTitle, OpBeginTime = s.OpBeginTime, OpAuthor = s.OpAuthor, OpType = s.OpType, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);
            }

            totalCount = query.Count();
            var list = new List<Bank_Opus>();
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
        /// 获取作品对象
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public Bank_Opus GetOpusModel(int id)
        {
            var query = _db.Bank_Opus.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Bank_Opus { ID = s.ID, OpTitle = s.OpTitle, OpBeginTime = s.OpBeginTime, OpAuthor = s.OpAuthor, OpType = s.OpType, AddTime = s.AddTime, IsDelete = s.IsDelete }).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        public bool AddOpus(Bank_Opus s, Admin_KSCustomer aks)
        {
            DataAccess.Bank_Opus wnote = new DataAccess.Bank_Opus();
            wnote.OpTitle = s.OpTitle;
            wnote.OpBeginTime = s.OpBeginTime;
            wnote.OpAuthor = s.OpAuthor;
            wnote.OpType = s.OpType;
            wnote.AddTime = DateTime.Now;
            _db.Bank_Opus.AddObject(wnote);
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
        /// 编辑作品
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public bool EditOpus(Bank_Opus wn, Admin_KSCustomer aks, int id)
        {
            DataAccess.Bank_Opus wnote = _db.Bank_Opus.Where(s => s.ID == id).FirstOrDefault();
            wnote.OpTitle = wn.OpTitle;
            wnote.OpBeginTime = wn.OpBeginTime;
            wnote.OpAuthor = wn.OpAuthor;
            wnote.OpType = wn.OpType;
            wnote.AddTime = DateTime.Now;
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
        /// 标记为删除
        /// </summary>
        /// <returns></returns>
        public bool DelOpus(int[] ids)
        {
            var result = from c in _db.Bank_Opus
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
