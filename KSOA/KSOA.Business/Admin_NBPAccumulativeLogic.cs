using KSOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class Admin_NBPAccumulativeLogic : DbAccess
    {
        /// <summary>
        /// 批量保存导入的非包月付费用户数累计
        /// </summary>
        /// <param name="dt">非包月付费用户数集合</param>
        /// <returns></returns>
        public bool SaveImportDatas(List<Admin_NBPAccumulative> ListModel)
        {
            DataAccess.Admin_NBPAccumulative query = null;
            foreach (var Model in ListModel)
            {
                query = new DataAccess.Admin_NBPAccumulative();
                query.CountTime = Model.CountTime;
                query.CpName = Model.CpName;
                query.Province = Model.Province;
                query.NBPCount = Model.NBPCount;
                _db.Admin_NBPAccumulative.AddObject(query);
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
        /// 获取非包月付费用户数数据列表
        /// </summary>
        /// <returns></returns>
        public ExtentionNBP GetNBPList(int PageSize, int PageIndex, out int totalCount, NBPParam pra)
        {
            var query = from s in _db.Admin_NBPAccumulative orderby s.CountTime select new Admin_NBPAccumulative { CountTime=s.CountTime,CpName=s.CpName,NBPCount=s.NBPCount,Province=s.Province,ID=s.ID};


            #region 查询条件过滤
            //cp名称
            if (!string.IsNullOrEmpty(pra.cpName))//关键词非空
            {
                query = query.Where(s => s.CpName.Contains(pra.cpName));
            }
            //选择时间
            if (pra.seltime != new DateTime(1970, 1, 1))
            {
                query = query.Where(s => s.CountTime == pra.seltime);
            }
            #endregion
            totalCount = query.Count();
            var cbag = new ExtentionNBP();
            if (PageIndex < 0 || PageSize < 0)
            {
                return null;
            }
            if (PageIndex == 1 && PageSize > totalCount)
            {
                cbag.list = query.ToList<Admin_NBPAccumulative>();
            }
            else if (PageIndex == 1 && PageSize > 0)
            {
                cbag.list = query.Take(PageSize).ToList();
            }
            else
            {
                cbag.list = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            }
            cbag.par = pra;

            return cbag;
        }
    }
}
