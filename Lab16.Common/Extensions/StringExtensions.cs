using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab16.Common.Extensions
{
    public static partial class StringExtensions
    {
        public static DirectoryInfo AsDirectory(this string subject)
            => new DirectoryInfo(subject);

        public static FileInfo AsFile(this string subject)
            => new FileInfo(subject);

        public static IEnumerable<char> Characters(this string subject)
            => subject.ToCharArray();

        public static IEnumerable<string> CharactersAsStrings(this string subject)
            => subject.ToCharArray().Select(@char => $"{@char}").ToArray();

        public static string ConstantWidth(this string subject, int width)
        {
            if (subject is null)
            {
                return Yield.RepetitionsOf(' ').Times(width).AsString();
            }

            if (width >= subject.Length)
            {
                var parity = (width - subject.Length) % 2 == 0 ? "" : " ";

                return
                    $"{Yield.RepetitionsOf(' ').Times((width - subject.Length) / 2).AsString()}{subject}{parity}{Yield.RepetitionsOf(' ').Times((width - subject.Length) / 2).AsString()}";
            }

            if (subject.Length - width >= 3)
            {
                return $"{subject.Substring(0, width - 3)}...";
            }

            if (subject.Length - width == 2)
            {
                return $"{subject.Substring(0, width - 1)}...";
            }

            return $"{subject.Substring(0, width - 2)}...";
        }

        public static string ConstantWidthLeftAligned(this string subject, int width)
        {
            if (subject == null)
            {
                return Yield.RepetitionsOf(' ').Times(width).AsString();
            }

            if (width >= subject.Length)
            {
                return $"{subject}{Yield.RepetitionsOf(' ').Times(width - subject.Length).AsString()}";
            }

            if (subject.Length - width >= 3)
            {
                return $"{subject.Substring(0, width - 3)}...";
            }

            if (subject.Length - width == 2)
            {
                return $"{subject.Substring(0, width - 1)}...";
            }

            return $"{subject.Substring(0, width - 2)}...";
        }

        public static string ConstantWidthRightAligned(this string subject, int width)
        {
            if (subject == null)
            {
                return Yield.RepetitionsOf(' ').Times(width).AsString();
            }

            if (width >= subject.Length)
            {
                return $"{Yield.RepetitionsOf(' ').Times(width - subject.Length).AsString()}{subject}";
            }

            if (subject.Length - width >= 3)
            {
                return $"{subject.Substring(0, width - 3)}...";
            }

            if (subject.Length - width == 2)
            {
                return $"{subject.Substring(0, width - 1)}...";
            }

            return $"{subject.Substring(0, width - 2)}...";
        }

        public static string CyclicSubstring(this string subject, int startIndex, int length)
        {
            if (length.IsNegative())
            {
                throw new ArgumentException($"{nameof(length)} ({length}) cant be negative");
            }

            if (startIndex.NotNegative())
            {
                return subject.Substring(startIndex, length);
            }

            return subject.Substring(subject.Length + startIndex, length);
        }

        public static bool EqualsSafely(this string subject, string reference, StringComparison comparison)
        {
            if (subject is null)
            {
                return reference is null;
            }

            return subject.Equals(reference, comparison);
        }

        public static string FillLine(this string subject, int width)
        {
            if (subject.Length >= width)
            {
                return _constantWidth(subject, width);
            }

            return $"{subject}{_repetitionsOf('-', width - subject.Length)}";
        }

        public static char FirstCharacter(this string subject)
        {
            if (subject == null)
            {
                return default;
            }

            return subject[0];
        }

        public static string FormatWith(this string subject, params object[] objects)
            => string.Format(subject, objects);

        public static string FromBase64String(this string subject)
        {
            //https://en.wikipedia.org/wiki/Base64#Output_padding

            try
            {
                return Convert.FromBase64String(subject).AsString();
            }
            catch
            {
                try
                {
                    return Convert.FromBase64String($"{subject}=").AsString();
                }
                catch
                {
                    return Convert.FromBase64String($"{subject}==").AsString();
                }
            }
        }

        public static string FromBase64UrlString(this string subject)
            => subject.Replace('-', '+').Replace('_', '/').FromBase64String();

        public static bool IsAnyOfTheWords(this string subject, IEnumerable<string> words)
            => words.Any(subject.IsTheWord);

        public static bool IsInt(this string subject)
            => int.TryParse(subject, out _);

        public static bool IsLetters(this string subject)
            => subject.Characters().All(character => character.IsLetter());

        public static bool IsNothing(this string text)
            => string.IsNullOrEmpty(text?.Trim());

        public static bool IsNullOrWhitespace(this string text)
            => string.IsNullOrWhiteSpace(text);

        public static bool IsTheWord(this string subject, string word)
            => subject.TrimSafely().EqualsSafely(word.TrimSafely(), StringComparison.OrdinalIgnoreCase);

        public static char LastCharacter(this string subject)
        {
            if (subject == null)
            {
                return default;
            }

            return subject[subject.Length - 1];
        }

        public static string NewLine(this string subject)
            => $"{subject}\r\n";

        public static bool NotNullNotEmpty(this string text)
            => !string.IsNullOrEmpty(text);

        public static bool OrdinalEqual(this string lhs, string rhs)
            => string.CompareOrdinal(lhs, rhs).IsZero();

        public static DateTime ParseAdjustToUniversal(this string value) 
            => DateTime.TryParse(value, null, DateTimeStyles.AdjustToUniversal, out var dateTime)
                ? dateTime
                : DateTime.MinValue;

        public static TEnum ParseAsEnum<TEnum>(this string value)
            => (TEnum) Enum.Parse(typeof(TEnum), value);

        public static string RemoveNewLines(this string text)
        {
            var builder = new StringBuilder();

            foreach (var ch in text)
            {
                if (ch != '\r' && ch != '\n')
                {
                    builder.Append(ch);
                }

                // TODO unless its at the end of the text
                if (ch == '\n')
                {
                    builder.Append(' ');
                }
            }

            return $"{builder}";
        }

        public static string RemovePunctuation(this string subject)
            => new string(subject
                       .Characters()
                       .Where(@char => !@char.IsPunctuation() && !@char.IsWhitespace())
                       .ToArray());

        public static string RemoveWhitespace(this string text)
        {
            var builder = new StringBuilder();

            foreach (var ch in text)
            {
                if (!ch.IsWhitespace())
                {
                    builder.Append(ch);
                }
            }

            return $"{builder}";
        }

        public static string[] SplitBy(this string subject, char splitCharacter)
            => subject.SplitBy(new[] { splitCharacter });

        public static string[] SplitBy(this string subject, IEnumerable<char> splitCharacters)
        {
            if (subject.IsNothing())
            {
                return new string[0];
            }

            return subject.Split(splitCharacters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public static string[] SplitByCommas(this string subject)
            => subject.SplitBy(',');

        public static IEnumerable<string> SplitByPunctuation(this string subject)
            => subject.Split(_punctuation, StringSplitOptions.RemoveEmptyEntries);

        //public static IEnumerable<string> SplitByPunctuationOrWhitespace(this string subject)
        //{
        //    var result = new Enumerable<string>();

        //    var tokenReader = new TokenReader(subject);

        //    while (tokenReader.CanRead())
        //    {
        //        if (tokenReader.Peek().IsPunctuation())
        //        {
        //            tokenReader.Continue();

        //            continue;
        //        }

        //        result.Add(tokenReader.Read());
        //    }

        //    return result;
        //}

        public static IEnumerable<string> SplitLines(this string subject)
            => subject.Split(Yield.Parameters('\r', '\n').ToArray(), StringSplitOptions.RemoveEmptyEntries);

        public static byte[] ToAsciiBytes(this string subject)
            => string.IsNullOrEmpty(subject) ? new byte[0] : Encoding.ASCII.GetBytes(subject);   

        public static string ToBase64String(this string subject)
            => subject == default ? default : Convert.ToBase64String(subject.ToUtf8Bytes());

        public static bool ToBool(this string value)
        {
            bool.TryParse(value, out var result);
            return result;
        }

        public static string ToCamelCase(this string subject)
        {
            if (subject.IsNothing() || !char.IsUpper(subject[0]))
            {
                return subject;
            }

            var chars = subject.ToCharArray();
            for (var i = 0; i < chars.Length; i++)
            {
                if (i > 0)
                {
                    var isNextCharUpper = i + 1 < chars.Length && char.IsUpper(subject[i + 1]);
                    if (!isNextCharUpper && char.IsUpper(subject[i]))
                    {
                        break;
                    }
                }

                chars[i] = char.ToLowerInvariant(chars[i]);
            }

            return new string(chars);
        }

        public static decimal ToDecimal(this string value)
        {
            decimal.TryParse(value, out var result);
            return result;
        }

        public static double ToDouble(this string value)
        {
            double.TryParse(value, out var result);
            return result;
        }

        public static int ToInt(this string value)
        {
            int.TryParse(value, out var result);
            return result;
        }

        public static long ToLong(this string value)
        {
            long.TryParse(value, out var result);
            return result;
        }

        public static byte[] ToNBytes(this string subject, int n)
        {
            if (string.IsNullOrEmpty(subject))
            {
                return new byte[0];
            }

            return Encoding.UTF8.GetBytes(subject.Substring(0, n));
        }

        public static byte[] ToUtf8Bytes(this string subject) =>
            string.IsNullOrEmpty(subject) ? new byte[0] : Encoding.UTF8.GetBytes(subject);

        public static string TrimSafely(this string subject)
            => subject?.Trim() ?? default;

        public static void WriteFile(this string subject, string path)
            => File.WriteAllText(path, subject);

        private static string _constantWidthRightAligned(string subject, int width)
        {
            if (subject == null)
            {
                _repetitionsOf(' ', width);
            }

            if (width >= subject.Length)
            {
                return $"{_repetitionsOf(' ', width - subject.Length)}{subject}";
            }

            if (subject.Length - width >= 3)
            {
                return $"{subject.Substring(0, width - 3)}...";
            }

            if (subject.Length - width == 2)
            {
                return $"{subject.Substring(0, width - 1)}...";
            }

            return $"{subject.Substring(0, width - 2)}...";
        }

        private static string _constantWidth(string subject, int width)
        {
            if (subject == null)
            {
                _repetitionsOf(' ', width);
            }

            if (width >= subject.Length)
            {
                return $"{subject}{_repetitionsOf(' ', width - subject.Length)}";
            }

            if (subject.Length - width >= 3)
            {
                return $"{subject.Substring(0, width - 3)}...";
            }

            if (subject.Length - width == 2)
            {
                return $"{subject.Substring(0, width - 1)}...";
            }

            return $"{subject.Substring(0, width - 2)}...";
        }

        private static readonly char[] _punctuation = new[]
        {
            ',', '<', '>', '\'', '"', '?', '/', '|', '\\', '{', '}', '[', ']', '+', '=', ')', '(', '!', '.', '@', '#',
            '$', '%', '^', '&', '*', '`', '~', ':', ';', '-'
        };

        private static string _repetitionsOf(char character, int count)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                builder.Append(character);
            }

            return $"{builder}";
        }
    }
}