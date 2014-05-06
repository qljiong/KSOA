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
            包月源数据,
            非包月付费源数据
        }

        /// <summary>
        /// 角色类型
        /// </summary>
        public enum Role
        {
            超级管理=1,
            普通员工
        }

        /// <summary>
        /// 工作报告类型
        /// </summary>
        public enum NoteType
        {
            /// <summary>
            /// 日报
            /// </summary>
            D=1,
            /// <summary>
            /// 周报
            /// </summary>
            W,
            /// <summary>
            /// 月报
            /// </summary>
            M
        }

        /// <summary>
        /// 作品购销类型
        /// </summary>
        public enum OpusType
        {
            /// <summary>
            /// 作品购买
            /// </summary>
            B = 1,
            /// <summary>
            /// 销售
            /// </summary>
            S,
            /// <summary>
            /// 全部类型
            /// </summary>
            A
        }
    }
}
