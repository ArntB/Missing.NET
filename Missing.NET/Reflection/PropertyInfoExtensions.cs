using System.Reflection;

namespace Missing.Reflection
{
    public static class PropertyInfoExtensions
    {
        public static object GetValue(this PropertyInfo info, object thisObject)
        {
            return info.GetValue(thisObject, new object[]{});
        }

        public static void SetValue1(this PropertyInfo info,object thisObject, object value)
        {
            info.SetValue(thisObject,value, new object[] {});
        }

        public static object GetValue(this object self, string propertyName)
        {
            PropertyInfo property = GetProperyInfo(self, propertyName);
            return property.GetValue(self);
        }

        public static void SetValue1(this object self, string propertyName, object value)
        {
            PropertyInfo property = GetProperyInfo(self, propertyName);
            property.SetValue1(self,value);
        }

        private static PropertyInfo GetProperyInfo(object self, string propertyName)
        {
            return self.GetType().GetProperty(propertyName);
        }
    }
}