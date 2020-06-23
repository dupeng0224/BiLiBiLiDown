using BilibiliDown.Common;
using System;

namespace BilibiliDown.Model
{
	public class PageVideo
	{
		public int aid
		{
			get;
			set;
		}

		public int p
		{
			get;
			set;
		}

		public int cid
		{
			get;
			set;
		}

		public int mid
		{
			get;
			set;
		}

		public TypeVideo videoType
		{
			get;
			set;
		}

		public CData title
		{
			get;
			set;
		}

		public int pageIndex
		{
			get;
			set;
		}

		public TypeDown DownType
		{
			get;
			set;
		}

		public long totalSize
		{
			get;
			set;
		}

		public long downSize
		{
			get;
			set;
		}

		public int processbar
		{
			get
			{
				if (totalSize <= 0)
				{
					return 0;
				}
				return Convert.ToInt32(downSize * 100 / totalSize);
			}
		}

		public CData SavePath
		{
			get;
			set;
		}
	}
}
