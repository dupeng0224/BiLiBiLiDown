using System.Collections.Generic;

namespace BilibiliDown.Model
{
	public class Dash
	{
		public int duration
		{
			get;
			set;
		}

		public double minBufferTime
		{
			get;
			set;
		}

		public double min_buffer_time
		{
			get;
			set;
		}

		public List<VideoItem> video
		{
			get;
			set;
		}

		public List<AudioItem> audio
		{
			get;
			set;
		}
	}
}
