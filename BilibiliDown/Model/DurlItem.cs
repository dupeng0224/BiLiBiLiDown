using System.Collections.Generic;

namespace BilibiliDown.Model
{
	public class DurlItem
	{
		public int order
		{
			get;
			set;
		}

		public long length
		{
			get;
			set;
		}

		public long size
		{
			get;
			set;
		}

		public string ahead
		{
			get;
			set;
		}

		public string vhead
		{
			get;
			set;
		}

		public string url
		{
			get;
			set;
		}

		public List<string> backup_url
		{
			get;
			set;
		}
	}
}
