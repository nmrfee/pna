using System.Linq;
using System.Reflection;

namespace Lab16.Common.Extensions
{
    public static class MethodInfoExtensions
	{
        public static bool HasAttribute<TAttribute>(this MethodInfo subject) 
            => subject.CustomAttributes
                .Any(attribute => attribute.AttributeType.Extends<TAttribute>());
    }
}