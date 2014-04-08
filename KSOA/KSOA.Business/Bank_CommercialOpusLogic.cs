using KSOA.Common;
using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Bank_CommercialOpusLogic : DbAccess
    {
        /// <summary>
        ///获取作品分页列表
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Bank_CommercialOpus> GetCommercialOpusList(KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Bank_CommercialOpus.Join(_db.Bank_Opus, s => s.OpusID, Opus => Opus.ID, (s, Opus) => new { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, Oupsname = Opus.OpTitle, AddTime = s.AddTime, IsDelete = s.IsDelete }).Where(s => s.IsDelete == false).Select(s => new Bank_CommercialOpus { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, Oupsname = s.Oupsname, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

            totalCount = query.Count();
            var list = new List<Bank_CommercialOpus>();
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
        public List<Bank_CommercialOpus> GetCommercialOpusList(string keyword, KSOAEnum.OpusType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            string strtype = ntype.ToString();
            var query = _db.Bank_CommercialOpus.Where(s => s.IsDelete == false).Select(s => new Bank_CommercialOpus { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);

            if (strtype != "A")
            {
                query = _db.Bank_CommercialOpus.Where(s => s.IsDelete == false).Select(s => new Bank_CommercialOpus { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);
            }

            totalCount = query.Count();
            var list = new List<Bank_CommercialOpus>();
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
        public Bank_CommercialOpus GetCommercialOpusModel(int id)
        {
            var query = _db.Bank_CommercialOpus.Join(_db.Bank_Opus, s => s.OpusID, Opus => Opus.ID, (s, Opus) => new { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, Oupsname = Opus.OpTitle, AddTime = s.AddTime, IsDelete = s.IsDelete }).Where(s => s.IsDelete == false && s.ID == id).Select(s => new Bank_CommercialOpus { ID = s.ID, CompanyName = s.CompanyName, ChannelAddress = s.ChannelAddress, CpAddress = s.CpAddress, OpusID = s.OpusID, Oupsname = s.Oupsname, AddTime = s.AddTime, IsDelete = s.IsDelete }).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// 新增作品
        /// </summary>
        /// <returns></returns>
        public bool AddCommercialOpus(Bank_CommercialOpus s, Admin_KSCustomer aks)
        {
            DataAccess.Bank_CommercialOpus wnote = new DataAccess.Bank_CommercialOpus();
            wnote.CompanyName = s.CompanyName;
            wnote.ChannelAddress = s.ChannelAddress;
            wnote.CpAddress = s.CpAddress;
            wnote.OpusID = s.OpusID;
            wnote.AddTime = DateTime.Now;
            _db.Bank_CommercialOpus.AddObject(wnote);
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
        public bool EditCommercialOpus(Bank_CommercialOpus wn, Admin_KSCustomer aks, int id)
        {
            DataAccess.Bank_CommercialOpus wnote = _db.Bank_CommercialOpus.Where(s => s.ID == id).FirstOrDefault();
            wnote.CompanyName = wn.CompanyName;
            wnote.ChannelAddress = wn.ChannelAddress;
            wnote.CpAddress = wn.CpAddress;
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
        public bool DelCommercialOpus(int[] ids)
        {
            var result = from c in _db.Bank_CommercialOpus
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
