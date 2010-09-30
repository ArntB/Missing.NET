using System;
using System.Linq;
using System.Reflection;

namespace Missing.Reflection
{
    public static class NameSpaceQuerys
    {
        public static Type[] GetTypesInNamespace(this Assembly assembly, string nameSpaceFilter)
        {
            Type[] types = assembly.GetTypes();
            return(from typ in types
                   where typ.Namespace != null && typ.Namespace.StartsWith(nameSpaceFilter)
                   select typ).ToArray();
        }
    }
}