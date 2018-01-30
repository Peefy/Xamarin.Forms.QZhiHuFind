﻿using System;

namespace DuGu.XFLib.Utils
{
	public class HtmlUtils
	{
		public static string ReplaceHtmlTag(string html, int length = 0)
		{
			string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
			strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

			if (length > 0 && strText.Length > length)
				return strText.Substring(0, length);
			return strText;
		}
	}
}
