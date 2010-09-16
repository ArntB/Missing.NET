using System.Reflection;

namespace Missing.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static object GetValue(this PropertyInfo info, object thisObject)
        {
            return info.GetValue(thisObject, new object[]{});
        }

        public static void SetValue(this PropertyInfo info,object thisObject, object value)
        {
            info.SetValue(thisObject, new[] { value});
        }

        public static object GetValue(this object self, string propertyName)
        {
            
        }
    }
}