using Microsoft.Extensions.Caching.Memory;
using MoviesPediaDataAccessLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPediaDataAccessLibrary.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T GetData<T>(string key)
        {
            try
            {
                T item = (T)_memoryCache.Get(key);
                return item;
            }
            catch (Exception ex){throw;}
        }

        public object RemoveData(string key)
        {
            var res = true;
            try
            {
                if (!string.IsNullOrEmpty(key))
                    _memoryCache.Remove(key);
                else
                    res = false;

                return res;
            }
            catch (Exception ex) { throw; }
        }

        public bool SetData<T>(string key, T value, TimeSpan expirationTime)
        {
            var res = true;
            try
            {
                if(!string.IsNullOrEmpty(key) && value is not null)
                    _memoryCache.Set(key, value, expirationTime);
                else
                    res = false;
                
                return res;
            }
            catch (Exception ex){throw; }
        }
    }
}
