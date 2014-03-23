using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KSOA.Model;

namespace KSOA.Business
{
    public class Admin_NotBaoyuePayBillPlayCountLogic:DbAccess
    {
        /// <summary>
        /// 获取非包月付费用户统计表信息
        /// </summary>
        /// <returns></returns>
        public List<Admin_NotBaoyuePayBillPlayCount> GetCountList()
        {
            var query= _db.Admin_NotBaoyuePayBillPlayCount.Select(s=>new {
                id=s.ID,
                cpname=s.CpName,
                cpid=s.CpID,
                province=s.Province,
                leavenum=s.LeaveNum,
                addnum=s.AddNum,
                numtotal=s.NumTotal,
                addtime=s.AddTime,
                isdelete=s.IsDelete
            });
            List<Admin_NotBaoyuePayBillPlayCount> list = new List<Admin_NotBaoyuePayBillPlayCount>();
            foreach (var item in query)
            {
                Admin_NotBaoyuePayBillPlayCount abp = new Admin_NotBaoyuePayBillPlayCount();
                abp.ID = item.id;
                abp.CpName = item.cpname;
                abp.CpID = item.cpid;
                abp.Province = item.province;
                abp.LeaveNum = item.leavenum;
                abp.AddNum = item.addnum;
                abp.NumTotal = item.numtotal;
                abp.AddTime = item.addtime;
                abp.IsDelete = item.isdelete;
            }
            return list;
        }
    }
}
