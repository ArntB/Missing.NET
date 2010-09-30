using System;
using System.Web;
using System.Web.Routing;
using Missing.Context;

namespace Missing.Web
{

    /// <summary>
    /// Credits go to: Fredrik Kalseth
    /// http://iridescence.no/
    /// </summary>
    public class HttpContextSessionCache : ICacheSessionData
    {
        private readonly RequestContext context;

        public HttpContextSessionCache(RequestContext context)
        {
            this.context = context;
        }
 
        public T Get<T>(string key)
        {
            object value = context.HttpContext.Session[key];
 
            return value == null ? default(T) : (T) value;
        }

        public object this[string name]
        {
            get { return context.HttpContext.Session[name]; }
            set { context.HttpContext.Session[name] = value; }
        }
    }
}