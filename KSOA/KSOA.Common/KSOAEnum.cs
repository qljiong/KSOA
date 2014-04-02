using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Common
{
    public class KSOAEnum
    {
        /// <summary>
        /// Excel导入文件,类型区分
        /// </summary>
        public enum ImportExcelType
        {
            投诉源数据=1,
            包月源数据
        }

        public enum Role
        {
            超级管理=1,
            普通员工
        }
    }
}
