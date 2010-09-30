using System;
using System.Collections.Generic;

namespace Missing.Context
{
    public class TestContextSessionCache : ICacheSessionData
    {
        private IDictionary<string, object> cache = new Dictionary<string, object>();
        public T Get<T>(string key)
        {
            object value = this[key];
            return value == null ? default(T) : (T) value;
        }

        public object this[string name]
        {
            get
            {
                if (cache.ContainsKey(name))
                    return cache[name];
                return null;
            }
            set {
                if(cache.ContainsKey(name))
                    cache[name] = value;
                else
                    cache.Add(name, value);
            }
        }
    }
}