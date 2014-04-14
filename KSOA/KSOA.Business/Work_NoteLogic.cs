using KSOA.Common;
using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Work_NoteLogic : DbAccess
    {
        /// <summary>
        /// 获取工作报告列表
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Work_Note> GetDailyList(KSOAEnum.NoteType ntype, int PageSize, int PageIndex, out int totalCount)
        {
            string strtype = ntype.ToString();
            var query = _db.Work_Note.Where(s => s.IsDelete == false && s.WType == strtype).Select(s => new Work_Note { ID = s.ID, WType = s.WType, WriterID = s.WriterID, WriterName = s.WriterName, WTitle = s.WTitle, WConetent = s.WConetent, WTaster = s.WTaster, IsRead = s.IsRead, AddTime = s.AddTime, IsDelete = s.IsDelete }).OrderBy(s => s.AddTime);
            totalCount = query.Count();
            var list = new List<Work_Note>();
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
        /// 新增工作报告
        /// </summary>
        /// <returns></returns>
        public bool AddWorkNote(Work_Note wn, Admin_KSCustomer aks)
        {
            DataAccess.Work_Note wnote = new DataAccess.Work_Note();
            wnote.WTitle = wn.WTitle;
            wnote.WConetent = wn.WConetent;
            wnote.AddTime = DateTime.Now;
            wnote.WriterID = aks.ID;
            wnote.WriterName = aks.CusName;
            wnote.WType = wn.WType;
            wnote.WTaster = wn.WTaster;

            _db.Work_Note.AddObject(wnote);
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
        /// 根据ID获取工作报告的实体
        /// </summary>
        /// <returns></returns>
        public Work_Note GetWork_NoteModel(int id)
        {
            var query = _db.Work_Note.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Work_Note { ID = s.ID, WType = s.WType, WriterID = s.WriterID, WriterName = s.WriterName, WTitle = s.WTitle, WConetent = s.WConetent, WTaster = s.WTaster, IsRead = s.IsRead, AddTime = s.AddTime, IsDelete = s.IsDelete }).SingleOrDefault();
            return query;
        }

        /// <summary>
        /// 标记为已阅
        /// </summary>
        /// <returns></returns>
        public bool UpdateMark(int id)
        {
            var wn = _db.Work_Note.Where(s => s.ID == id).SingleOrDefault();
            wn.IsRead = true;
            _db.SaveChanges();
            return false;
        }

        /// <summary>
        /// 标记为已阅(批量)
        /// </summary>
        /// <returns></returns>
        public bool DelDaily(int[] ids)
        {
            var result = from c in _db.Work_Note
                         where ids.Contains<int>(c.ID)
                         select c;
            foreach (var item in result)
            {
                item.IsRead = true;
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
