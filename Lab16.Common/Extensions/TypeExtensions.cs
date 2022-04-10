using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab16.Common.Extensions
{
    public static class TypeExtensions
	{
		public static TObject CreateInstance<TObject>(this Type subject)
			=> (TObject) Activator.CreateInstance(subject);

		public static bool Extends<TObject>(this Type subject)
			=> typeof(TObject).IsAssignableFrom(subject);

		public static MethodInfo GetMethodWith<TAttribute>(this Type subject)
			where TAttribute : Attribute
			=> subject.GetMethodsWith<TAttribute>().FirstOrDefault();

		public static IEnumerable<MethodInfo> GetMethodsWith<TAttribute>(this Type subject)
			where TAttribute : Attribute 
			=> subject.GetMethods().Where(method => method.HasAttribute<TAttribute>());

        public static string GetTypeName(this Type subject)
			=> subject.Name;

		public static string GetTypeName<TObject>()
			=> typeof(TObject).Name;

		public static bool HasAttribute<TAttribute>(this Type subject)
			=> throw new System.NotImplementedException();
		
		public static TObject New<TObject>(this Type subject)
			=> (TObject)Activator.CreateInstance(subject);

		public static TObject New<TObject>(this Type subject, params object[] arguments)
			=> (TObject)Activator.CreateInstance(subject, arguments);

		public static int SizeOf(this Type subject)
		{
			if (subject == typeof(byte))
			{
				return sizeof(byte);
			}

			if (subject == typeof(int))
			{
				return sizeof(int);
			}

			if (subject == typeof(uint))
			{
				return sizeof(uint);
			}

			if (subject == typeof(ulong))
			{
				return sizeof(ulong);
			}

			if (subject == typeof(long))
			{
				return sizeof(long);
			}

			if (subject == typeof(bool))
			{
				return sizeof(bool);
			}

			if (subject == typeof(ushort))
			{
				return sizeof(ushort);
			}

			if (subject == typeof(short))
			{
				return sizeof(short);
			}

			if (subject == typeof(double))
			{
				return sizeof(double);
			}

			if (subject == typeof(float))
			{
				return sizeof(float);
			}

			if (subject == typeof(decimal))
			{
				return sizeof(decimal);
			}

			throw new NotImplementedException();
		}

		public static bool Supersedes<TObject>(this Type subject)
			=> subject.IsAssignableFrom(typeof(TObject));
	}
}