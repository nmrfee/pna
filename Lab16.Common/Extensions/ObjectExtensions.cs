using System;
using System.Collections.Generic;
using System.Reflection;
using SystemDebug = System.Diagnostics.Debug;

namespace Lab16.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void Call(this object subject, MethodInfo method, params object[] arguments)
            => method.Invoke(subject, arguments);

        public static TObject CallResult<TObject>(this object subject, MethodInfo method, params object[] arguments)
            => (TObject)method.Invoke(subject, arguments);

        public static void CallOrDefault(this object subject, MethodInfo method, params object[] arguments)
        {
            if (method is null)
            {
                return;
            }

            subject.Call(method, arguments);
        }

        public static bool Extends<TType>(this object subject)
            => subject.GetType().Extends<TType>();

        public static bool Extends<TType>(this object subject, out TType reference)
        {
            if (subject.GetType().Extends<TType>())
            {
                reference = (TType)subject;
                return true;
            }

            reference = default;

            return false;
        }

        public static bool Extends(this object subject, Type reference)
            => reference.IsInstanceOfType(subject);

        public static string GetTypeName(this object subject)
            => subject?.GetType().GetTypeName();

        public static IEnumerable<TObject> Singly<TObject>(this TObject subject)
            => new TObject[] { subject };

        public static IEnumerable<TObject> Then<TObject>(this TObject subject, TObject reference)
            => new TObject[] { subject, reference };

        public static IEnumerable<TObject> ThenAll<TObject>(this TObject subject, IEnumerable<TObject> reference)
        {
            var result = new LinkedList<TObject>();

            result.AddLast(subject);
            
            foreach(var element in reference)
            {
                result.AddLast(element);
            }

            return result;
        }

        public static TObject WriteLineToConsole<TObject>(this TObject subject)
        {
            Console.WriteLine(subject == null ? "Null" : $"{subject}");

            return subject;
        }

        public static TObject WriteToConsole<TObject>(this TObject subject)
        {
            Console.Write(subject == null ? "Null" : $"{subject}");

            return subject;
        }

        public static TObject WriteLineToDebug<TObject>(this TObject subject)
        {
            SystemDebug.WriteLine(subject == null ? "Null" : $"{subject}");

            return subject;
        }
    }
}