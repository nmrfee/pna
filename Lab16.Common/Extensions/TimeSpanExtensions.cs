using System;
using System.Linq;

namespace Lab16.Common.Extensions
{
	public static class TimeSpanExtensions
	{
        public static long AsMilliseconds(this TimeSpan subject)
			=> (long)subject.TotalMilliseconds;

        public static string TimeString(this TimeSpan subject)
		{
			if (subject.Ticks < TimeSpan.TicksPerMillisecond)
			{
				return "Less than a millisecond";
			}

			var days = subject.Days > 0 ? $"{subject.Days} days" : "";
			var hours = subject.Hours > 0 ? $"{subject.Hours} hours" : "";
			var minutes = subject.Minutes > 0 ? $"{subject.Minutes} min." : "";
			var seconds = subject.Seconds > 0 ? $"{subject.Seconds} sec." : "";
			var milliseconds = subject.Milliseconds > 0 ? $"{subject.Milliseconds} ms." : "";

			return
				 new[] { days, hours, minutes, seconds, milliseconds }
					.Where(@string => !@string.IsNullOrWhitespace())
					.ToAggregateString(" ");
		}
	}
}