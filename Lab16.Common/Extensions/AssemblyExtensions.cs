using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab16.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetClasses(this Assembly subject)
            => subject
                .GetTypes()
                .Where(type => !type.IsInterface);

        public static IEnumerable<Type> GetImplementationsOf<TBaseType>(this Assembly subject) 
            => subject
                   .GetClasses()
                   .Where(@class => @class.Extends<TBaseType>());
    }
}