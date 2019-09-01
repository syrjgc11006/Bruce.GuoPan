using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Bruce.GuoPan.Core
{
    public static class CacheHelper
    {
        private static ObjectCache memCache = MemoryCache.Default;
        /// <summary>  
        /// 获取数据缓存  
        /// </summary>  
        /// <param name="CacheKey">键</param>  
        public static object GetCache(string CacheKey)
        {
            return memCache.Get(CacheKey);
        }

        /// <summary>  
        /// 设置数据缓存  
        /// </summary>  
        public static void SetCache(string CacheKey, object objObject, double seconds)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(seconds);
            memCache.Add(CacheKey, objObject, policy);
        }

        /// <summary>  
        /// 移除指定数据缓存  
        /// </summary>  
        public static void RemoveAllCache(string CacheKey)
        {
            memCache.Remove(CacheKey);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static object Get(string key, Func<object> func, double second)
        {
            var data = GetCache(key);
            if (data == null)
            {
                data = func();
                SetCache(key, data, second);
            }
            return data;
        }
    }
}
