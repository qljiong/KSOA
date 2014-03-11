using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class KSCustomerLogic : DbAccess
    {
        public string test()
        {
            var result= _db.KSCustomer.Where(s=>s.ID==1).FirstOrDefault();
            return result==null?"未定义":result.CusName;
        }
    }
}
