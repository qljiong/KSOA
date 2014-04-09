using KSOA.Common;
using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Bank_OriginalGroupLogic : DbAccess
    {
        /// <summary>
        ///获取原创组信息列表
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Bank_OriginalGroup> GetOriginalGroupList(KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Bank_OriginalGroup.Where(s => s.IsDelete == false).Select(s => new Bank_OriginalGroup { ID = s.ID, OpusCopyright = s.OpusCopyright, CreationInfo = s.CreationInfo, OpusName = s.OpusName, OpusAuthor = s.OpusAuthor, SalePrice = s.SalePrice, AccreditPlatform = s.AccreditPlatform, AccreditCompany = s.AccreditCompany, AccreditTime = s.AccreditTime, AccreditType = s.AccreditType, Awards = s.Awards, OpusMascot = s.OpusMascot, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

            totalCount = query.Count();
            var list = new List<Bank_OriginalGroup>();
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
        /// 选取原创组信息
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        /* public List<Bank_OriginalGroup> GetOriginalGroupList(string keyword, KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
         {
             string strtype = ntype.ToString();
             var query = _db.Bank_OriginalGroup.Where(s => s.IsDelete == false).Select(s => new Bank_OriginalGroup { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

             if (strtype != "A")
             {
                 query = _db.Bank_OriginalGroup.Where(s => s.IsDelete == false).Select(s => new Bank_OriginalGroup { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);
             }

             totalCount = query.Count();
             var list = new List<Bank_OriginalGroup>();
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
         */
        /// <summary>
        /// 获取原创组对象
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public Bank_OriginalGroup GetOriginalGroupModel(int id)
        {
            var query = _db.Bank_OriginalGroup.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Bank_OriginalGroup { ID = s.ID, OpusCopyright = s.OpusCopyright, CreationInfo = s.CreationInfo, OpusName = s.OpusName, OpusAuthor = s.OpusAuthor, SalePrice = s.SalePrice, AccreditPlatform = s.AccreditPlatform, AccreditCompany = s.AccreditCompany, AccreditTime = s.AccreditTime, AccreditType = s.AccreditType, Awards = s.Awards, OpusMascot = s.OpusMascot, AddTime = s.AddTime, IsDelete = s.IsDelete }).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// 新增原创组信息
        /// </summary>
        /// <returns></returns>
        public bool AddOriginalGroup(Bank_OriginalGroup s, Admin_KSCustomer aks)
        {
            DataAccess.Bank_OriginalGroup wnote = new DataAccess.Bank_OriginalGroup();
            wnote.OpusCopyright = s.OpusCopyright;
            wnote.CreationInfo = s.CreationInfo;
            wnote.OpusName = s.OpusName;
            wnote.OpusAuthor = s.OpusAuthor;
            wnote.SalePrice = s.SalePrice;
            wnote.AccreditPlatform = s.AccreditPlatform;
            wnote.AccreditCompany = s.AccreditCompany;
            wnote.AccreditTime = s.AccreditTime;
            wnote.AccreditType = s.AccreditType;
            wnote.Awards = s.Awards;
            wnote.OpusMascot = s.OpusMascot;
            wnote.AddTime = DateTime.Now;
            _db.Bank_OriginalGroup.AddObject(wnote);
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
        /// 编辑原创组信息
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public bool EditOriginalGroup(Bank_OriginalGroup wn, Admin_KSCustomer aks, int id)
        {
            DataAccess.Bank_OriginalGroup wnote = _db.Bank_OriginalGroup.Where(s => s.ID == id).FirstOrDefault();
            wnote.OpusCopyright = wn.OpusCopyright;
            wnote.CreationInfo = wn.CreationInfo;
            wnote.OpusName = wn.OpusName;
            wnote.OpusAuthor = wn.OpusAuthor;
            wnote.SalePrice = wn.SalePrice;
            wnote.AccreditPlatform = wn.AccreditPlatform;
            wnote.AccreditCompany = wn.AccreditCompany;
            wnote.AccreditTime = wn.AccreditTime;
            wnote.AccreditType = wn.AccreditType;
            wnote.Awards = wn.Awards;
            wnote.OpusMascot = wn.OpusMascot;
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
        public bool DelOriginalGroup(int[] ids)
        {
            var result = from c in _db.Bank_OriginalGroup
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
