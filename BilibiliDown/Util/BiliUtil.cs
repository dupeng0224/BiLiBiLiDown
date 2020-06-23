using BilibiliDown.Model;
using Newtonsoft.Json;

namespace BilibiliDown.Util
{
	internal class BiliUtil
	{
		public static BiliUserInfo getAccountInfo()
		{
			return JsonConvert.DeserializeObject<BiliUserInfo>(HttpUtil.HttpGet("https://api.bilibili.com/x/web-interface/nav?from=report", null, null));
		}
	}
}
