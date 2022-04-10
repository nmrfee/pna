using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab16.Common.Extensions
{
    public static class CharExtensions
	{
		public static bool IsControlCode(this char subject)
			=> char.IsControl(subject);

		public static bool IsDigit(this char subject)
			=> char.IsDigit(subject);

		public static bool IsLetter(this char subject)
			=> char.IsLetter(subject);

		public static bool IsLowercaseLetter(this char subject)
		{
			var s = (int) subject;

			return 'a' <= s && s <= 'z';
		}

		public static bool IsUppercaseLetter(this char subject)
		{
			var s = (int) subject;

			return 'A' <= s && s <= 'Z';
		}

		public static bool IsNumber(this char subject)
			=> char.IsDigit(subject);

		public static bool IsPunctuation(this char subject)
			=> _punctuation.Contains(subject);

		public static bool IsWhitespace(this char subject)
			=> char.IsWhiteSpace(subject);

		public static byte ToByte(this char subject)
			=> (byte)subject;

		// todo
		private static readonly IEnumerable<char> _punctuation = new[]
		{
			',', '<', '>', '\'', '"', '?', '/', '|', '\\', '{', '}', '[', ']', '+', '=', ')', '(', '!', '.', '@', '#',
			'$', '%', '^', '&', '*', '`', '~', ':', ';', '-'
		};

        public static bool IsMinus(this char subject)
        {
            return subject.Equals('-');
        }

        public static bool IsDecimalPoint(this char subject)
        {
            return subject.Equals('.');
        }

        //public static bool IsLetter(this char subject)
        //{
        //    return char.IsLetter(subject);
        //}

        //public static bool IsDigit(this char subject)
        //{
        //    return char.IsDigit(subject);
        //}

        //public static bool IsNumber(this char subject)
        //{
        //    return char.IsDigit(subject);
        //}

        //public static bool IsControlCode(this char subject)
        //{
        //    return char.IsControl(subject);
        //}

        public static int ParseInt(this char subject)
        {
            if (!subject.IsNumber())
            {
                throw new ArgumentException(nameof(subject));
            }

            return subject - '0';
        }

        //public static string RepeatString(char subject, int count)
        //{
        //    return YieldOfCharacter.RepetitionsOf(subject, count).ToUnformattedString();
        //}

        //public static string RepeatString(char subject, int count)
        //{
        //    return RepeatString(subject, count);
        //}

        //public static CharacterType Type(this char subject)
        //{
        //    if (char.IsLetter(subject))
        //    {
        //        return CharacterType.Letter;
        //    }

        //    if (char.IsDigit(subject))
        //    {
        //        return CharacterType.Number;
        //    }

        //    if (char.IsWhiteSpace(subject))
        //    {
        //        return CharacterType.Whitespace;
        //    }

        //    if (subject.IsPunctuation())
        //    {
        //        return CharacterType.Punctuation;
        //    }

        //    if (char.IsControl(subject))
        //    {
        //        return CharacterType.ControlCode;
        //    }

        //    //if (subject == ' ')
        //    //{
        //    //	return CharacterType.Space;
        //    //}

        //    throw new ArgumentException($"Unknown type for '{subject}' ({(int)subject})");
        //}

        // todo
        private static readonly IEnumerable<char> Punctuation = new[]
        {
            ',', '<', '>', '\'', '"', '?', '/', '|', '\\', '{', '}', '[', ']', '+', '=', ')', '(', '!', '.', '@', '#',
            '$', '%', '^', '&', '*', '`', '~', ':', ';','-'
        };
    }
}