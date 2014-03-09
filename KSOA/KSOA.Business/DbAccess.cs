using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSOA.DataAccess;

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
         
            //_db.SavingChanges += new EventHandler(_db_SavingChanges);
        }



        /// <summary>
        /// 用户数据库操作监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void _db_SavingChanges(object sender, EventArgs e)
        //{
        //    string sql = _db.ToString();
        //}


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
