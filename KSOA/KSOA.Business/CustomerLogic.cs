using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSOA.Business
{
    public class CustomerLogic : DbAccess
    {
        public string test()
        {
            var result= _db.Customer.Where(s=>s.ID==1).FirstOrDefault();
            return result.Name;
        }
    }
}
