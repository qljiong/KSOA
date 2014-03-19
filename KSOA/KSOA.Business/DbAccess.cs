using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSOA.DataAccess;
using System.IO;

namespace KSOA.Business
{
    public abstract class DbAccess : IDisposable
    {

        protected DataAccess.KSOAEntities _db
        {
            get;
            set;
        }


        public DbAccess(DataAccess.KSOAEntities db = null)
        {
            if (db == null)
            {
                _db = new KSOAEntities(Connection.ConnectionString);
            }
            else
            {
                _db = db;
            } 
         
            _db.SavingChanges += new EventHandler(_db_SavingChanges);
        }



        /// <summary>
        /// 用户数据库操作监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _db_SavingChanges(object sender, EventArgs e)
        {
            string sql = _db.ToString();
            //ToOrderExceptionLog(sql);
        }

        private void ToOrderExceptionLog(string strMsg)
        {
            String saveUri = "F:\\调试日志";
            if (Directory.Exists(saveUri))
            {
                String saveFileName = @saveUri + "\\" + DateTime.Now.ToLongDateString() + ".txt ";
                FileInfo nfile = new FileInfo(saveFileName);
                if (!nfile.Exists) { FileStream crtorchage = System.IO.File.Create(saveFileName); crtorchage.Flush(); crtorchage.Close(); }
                StreamWriter wt = new StreamWriter(saveFileName, true);//以可以追加文本的方式打开nfile流  
                wt.WriteLine(strMsg); wt.Flush(); wt.Close();
            }
            else
            {
                Directory.CreateDirectory(saveUri);
                String saveFileName = @saveUri + "\\" + DateTime.Now.ToLongDateString() + ".txt ";
                FileStream crtorchage = System.IO.File.Create(saveFileName);
                crtorchage.Flush(); crtorchage.Close();
                StreamWriter wt = new StreamWriter(saveFileName);//不可追加文本  
                wt.WriteLine(strMsg); wt.Flush(); wt.Close();
            }
        }

        #region IDisposable 成员

        public void Dispose()
        {

            _db.Connection.Close();
            //_db = null;
            _db.Dispose();
        }


        ~DbAccess()
        {
            this.Dispose();
        }

        #endregion
    }
}
