using System;
using System.IO;

namespace DuGu.XFLib.Extensions
{
    public static class StreamExtension
    {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stm"></param>
		/// <param name="perCount"></param>
		/// <returns></returns>
		public static byte[] GetBytes(this Stream stm, int perCount = 1024)
		{
			if (stm == null)
				throw new ArgumentNullException("stm");
			if (perCount <= 0)
				throw new ArgumentOutOfRangeException("perCount", "perCount 必须大于等于0");

			if (stm.CanSeek)
				stm.Position = 0;

			byte[] bytes = new byte[stm.Length];
			var offset = 0;
			var count = 0;
			while (0 != (count = stm.Read(bytes, offset, stm.Length - stm.Position > perCount ? perCount : (int)(stm.Length - stm.Position))))
			{
				offset += count;
			}

			return bytes;
		}
    }
}
