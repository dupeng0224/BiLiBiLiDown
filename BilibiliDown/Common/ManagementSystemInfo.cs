using System.Collections.Generic;
using System.Management;

namespace BilibiliDown.Common
{
	internal class ManagementSystemInfo
	{
		public static string getMac()
		{
			List<string> list = new List<string>();
			foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
			{
				if (instance["IPEnabled"].ToString() == "True")
				{
					list.Add(instance["MacAddress"].ToString());
				}
			}
			return list[0].Replace(":", "");
		}
	}
}
