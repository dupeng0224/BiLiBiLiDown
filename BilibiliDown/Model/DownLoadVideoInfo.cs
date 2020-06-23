using System.Collections.Generic;

namespace BilibiliDown.Model
{
	public class DownLoadVideoInfo
	{
		public int aid
		{
			get;
			set;
		}

		public int cid
		{
			get;
			set;
		}

		public TypeVideo vtype
		{
			get;
			set;
		}

		public List<DownLoadVideoInfoDetail> videoUrls
		{
			get;
			set;
		}

		public List<string> audioUrls
		{
			get;
			set;
		}
	}
}
