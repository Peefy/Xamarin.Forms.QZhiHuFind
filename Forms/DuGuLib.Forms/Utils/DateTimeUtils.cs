using System;



namespace DuGu.XFLib.Utils
{
	public static class DateTimeUtils
	{
		public static string CommonTime(this DateTime dt)
		{
			TimeSpan span = DateTime.Now.Subtract(dt);
			if (span.Days > 0)
			{
				var month = (DateTime.Now.Year - dt.Year) * 12 + DateTime.Now.Month - dt.Month;

				if (month >= 12)
				{
					return string.Format("{0}年前", (month / 12).ToString());
				}
				else if (month > 0)
				{
					return string.Format("{0}月前", month.ToString());
				}
				else
				{
					return string.Format("{0}天前", span.Days.ToString());
				}
			}
			else
			{
				if (span.Hours > 0)
				{
					return string.Format("{0}小时前", span.Hours.ToString());
				}
				else
				{
					if (span.Minutes > 0)
					{
						return string.Format("{0}分钟前", span.Minutes.ToString());
					}
					else
					{
						if (span.Seconds > 5)
						{
							return string.Format("{0}秒前", span.Seconds.ToString());
						}
						else
						{
							return "刚刚";
						}
					}
				}
			}

		}
	}
}
