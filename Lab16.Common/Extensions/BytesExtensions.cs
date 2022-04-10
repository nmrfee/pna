using System;
using System.Text;

namespace Lab16.Common.Extensions
{
    public static class BytesExtensions
	{
		public static string AsBase64String(this byte[] subject) 
			=> Convert.ToBase64String(subject);

		public static string AsString(this byte[] data)
			=> data == null ? string.Empty : Encoding.UTF8.GetString(data);

		public static string AsString(this byte[] data, int length) 
			=> Encoding.UTF8.GetString(data, 0, length);

		public static string AsString(this byte[] data, int offset, int length) 
			=> Encoding.UTF8.GetString(data, offset, length);
	}
}