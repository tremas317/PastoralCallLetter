using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace PCLService
{
    public static class DataCache
    {
        public static void Add<T>(string key, T value)
        {
            MemoryCache.Default.Set(key, value, new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddHours(1) });
        }

        public static T Get<T>(string key)
        {
            object item = MemoryCache.Default.Get(key);

            if (item == null)
            {
                return default(T);
            }

            else if (typeof(T).IsAssignableFrom(item.GetType()))
            {
                return (T)item;
            }

            return default(T);
        }


    }
}