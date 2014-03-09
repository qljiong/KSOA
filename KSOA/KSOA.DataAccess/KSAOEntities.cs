using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KSOA.Common;
//using log4net;

namespace KSOA.DataAccess
{
    public partial class KSAOEntities
    {
        //private static readonly ILog logger = LogManager.GetLogger("Data");

        /*public int SaveChanges(string method)
        {
            StopWatch stopWatch = new StopWatch();
            StringBuilder addStr = new StringBuilder();
            StringBuilder delStr = new StringBuilder();
            StringBuilder modifiedStr = new StringBuilder();
            int result = 0;
            try
            {
                var modifiedObjects = ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Modified);
                if (modifiedObjects.Count() > 0)
                    foreach (var modifiedObject in modifiedObjects)
                    {
                        modifiedStr.Append(SerializeHelp.Serialize(modifiedObject.Entity));
                    }
                var addObjects = ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added);
                if (addObjects.Count() > 0)
                    foreach (var addObject in addObjects)
                    {
                        addStr.Append(SerializeHelp.Serialize(addObject.Entity));
                    }
                var delObjects = ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Deleted);
                if (delObjects.Count() > 0)
                    foreach (var delObject in delObjects)
                    {
                        delStr.Append(SerializeHelp.Serialize(delObject.Entity));
                    }
                //logger.Info(string.Format("Method={0}:Add=({1}),Del=({2}),Modify=({3})",method,addStr,delStr,modifiedStr));
                result=base.SaveChanges();
                return result;
            }
            catch (Exception e)
            {
                PrepareException(e, method, addStr.ToString(), delStr.ToString(), modifiedStr.ToString());
                throw;
            }
            finally
            {
                stopWatch.Stop();
                long elapsedMs=stopWatch.ElapsedMs();
                //logger.Info(method+" Complete, result=" + result + " ,elapsed=" + stopWatch.ElapsedMs() + " ms");
            }
        }

        private void PrepareException(Exception exception,string method,string addStr,string delStr,string modifiedStr)
        {
            exception.Data.Add("Method="+method, string.Format("Add=({0}),Del=({1}),Modify=({2})", addStr, delStr, modifiedStr));
        }*/
    }
}
