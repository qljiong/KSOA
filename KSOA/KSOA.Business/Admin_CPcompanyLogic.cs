using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSOA.Model;

namespace KSOA.Business
{
    public class Admin_CPcompanyLogic : DbAccess
    {
        public List<Admin_CPcompany> GetCpList()
        {
            var result = _db.Admin_CPcompany.Select(s => new Admin_CPcompany { ID=s.ID,CPname=s.CPname,AddTime=s.AddTime,IsDelete=s.IsDelete}).ToList();
            return result;
        }
    }
}
