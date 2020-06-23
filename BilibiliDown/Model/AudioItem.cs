using System.Collections.Generic;

namespace BilibiliDown.Model
{
	public class AudioItem
	{
		public int id
		{
			get;
			set;
		}

		public string baseUrl
		{
			get;
			set;
		}

		public string base_url
		{
			get;
			set;
		}

		public List<string> backupUrl
		{
			get;
			set;
		}

		public List<string> backup_url
		{
			get;
			set;
		}

		public int bandwidth
		{
			get;
			set;
		}

		public string mimeType
		{
			get;
			set;
		}

		public string mime_type
		{
			get;
			set;
		}

		public string codecs
		{
			get;
			set;
		}

		public int width
		{
			get;
			set;
		}

		public int height
		{
			get;
			set;
		}

		public string frameRate
		{
			get;
			set;
		}

		public string frame_rate
		{
			get;
			set;
		}

		public string sar
		{
			get;
			set;
		}

		public int startWithSap
		{
			get;
			set;
		}

		public int start_with_sap
		{
			get;
			set;
		}

		public SegmentBase SegmentBase
		{
			get;
			set;
		}

		public Segment_base segment_base
		{
			get;
			set;
		}

		public int codecid
		{
			get;
			set;
		}
	}
}
