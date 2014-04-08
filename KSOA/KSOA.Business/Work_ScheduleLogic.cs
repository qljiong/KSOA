using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Work_ScheduleLogic : DbAccess
    {
        /// <summary>
        /// 获取项目进度对象
        /// </summary>
        /// <param name="ntype"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public Work_Schedule GetScheduleModel(int id)
        {
            var query = _db.Work_Schedule.Where(s => s.IsDelete == false && s.ID == id).Select(s => new Work_Schedule { ID = s.ID, AddTime = s.AddTime, IsDelete = s.IsDelete, ItemName = s.ItemName, ItemLaunchTime = s.ItemLaunchTime, ItemIntro = s.ItemIntro }).SingleOrDefault();

            return query;
        }

        /// <summary>
        /// 新增项目进度
        /// </summary>
        /// <returns></returns>
        public bool AddSchedule(Work_Schedule wn, Admin_KSCustomer aks)
        {
            DataAccess.Work_Schedule wnote = new DataAccess.Work_Schedule();
            wnote.ItemName = wn.ItemName;
            wnote.ItemLaunchTime = wn.ItemLaunchTime;
            wnote.ItemIntro = wn.ItemIntro;
            wnote.AddTime = DateTime.Now;
            _db.Work_Schedule.AddObject(wnote);
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
        /// 获取列表
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Work_Schedule> GetScheduleList(int PageSize, int PageIndex, out int totalCount)
        {
            var query = _db.Work_Schedule.Where(s => s.IsDelete == false).Select(s => new Work_Schedule { ID = s.ID, AddTime = s.AddTime, IsDelete = s.IsDelete, ItemName = s.ItemName, ItemLaunchTime = s.ItemLaunchTime, ItemIntro = s.ItemIntro }).OrderByDescending(s => s.AddTime);
            totalCount = query.Count();
            var list = new List<Work_Schedule>();
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
        /// 编辑工作进度
        /// </summary>
        /// <param name="wn"></param>
        /// <returns></returns>
        public bool EditSchedule(Work_Schedule wn, Admin_KSCustomer aks, int id)
        {
            DataAccess.Work_Schedule wnote = _db.Work_Schedule.Where(s => s.ID == id).FirstOrDefault();
            wnote.ItemName = wn.ItemName;
            wnote.ItemLaunchTime = wn.ItemLaunchTime;
            wnote.ItemIntro = wn.ItemIntro;
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
        public bool Delschedule(int[] ids)
        {
            var result = from c in _db.Work_Schedule
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
