using System;
using System.Linq;
using System.Reflection;

namespace Missing.Reflection
{
    public static class NameSpaceQuerys
    {
        public static Type[] GetTypesInNamespace(this Assembly assembly, string nameSpaceFilter)
        {
            return(from type in assembly.GetTypes()
                   where type.Namespace.StartsWith(nameSpaceFilter)
                   select type).ToArray();
        }
    }
}