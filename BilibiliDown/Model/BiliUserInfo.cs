namespace BilibiliDown.Model
{
	public class BiliUserInfo
	{
		public class Level_info
		{
			public string current_level
			{
				get;
				set;
			}

			public string current_min
			{
				get;
				set;
			}

			public string current_exp
			{
				get;
				set;
			}

			public string next_exp
			{
				get;
				set;
			}
		}

		public class Data
		{
			public Level_info level_info
			{
				get;
				set;
			}

			public int bCoins
			{
				get;
				set;
			}

			public double coins
			{
				get;
				set;
			}

			public string face
			{
				get;
				set;
			}

			public string nameplate_current
			{
				get;
				set;
			}

			public string pendant_current
			{
				get;
				set;
			}

			public string uname
			{
				get;
				set;
			}

			public string userStatus
			{
				get;
				set;
			}

			public int vipType
			{
				get;
				set;
			}

			public int vipStatus
			{
				get;
				set;
			}

			public int official_verify
			{
				get;
				set;
			}

			public int pointBalance
			{
				get;
				set;
			}
		}

		public int code
		{
			get;
			set;
		}

		public string status
		{
			get;
			set;
		}

		public Data data
		{
			get;
			set;
		}
	}
}
