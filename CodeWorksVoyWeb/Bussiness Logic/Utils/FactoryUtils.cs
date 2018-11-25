using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeWorksVoyWebService.Bussiness_Logic.Bussiness_Objects
{


    public class FactoryUtils
    {

        public static List<T> CheckCache<T>(ref IMemoryCache cache, DbContext context, List<T> chkObj, string objName) where T : class {
 
            try
            {
                
                cache.TryGetValue(objName, out chkObj);
                if (chkObj == null)
                {
                    cache.CreateEntry(objName);
                    context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    chkObj = context.Set<T>().ToList();
                    cache.Set(objName, chkObj);

                }
             return chkObj;
                
            }
            catch(Exception e)  { string message=e.Message;}
            return null;
        }
        public static T CheckCache<T>(ref IMemoryCache cache, T chkObj, string objName) where T : class
        {

            try
            {

                cache.TryGetValue(objName, out chkObj);
                if (chkObj == null)
                {
                    cache.CreateEntry(objName);
                    chkObj = Activator.CreateInstance<T>();
                    cache.Set(objName, chkObj);

                }
                return chkObj;

            }
            catch (Exception e) { string message = e.Message; }
            return null;
        }

        public static void WriteCache<T>(ref IMemoryCache cache, T chkObj, string objName) where T : class
        {

            try
            {
                cache.Set(objName, chkObj);

            }
            catch (Exception e) { string message = e.Message; }            
        }
    }
}
