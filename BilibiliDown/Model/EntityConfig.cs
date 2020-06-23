using System;
using System.IO;
using System.Xml;

namespace BilibiliDown.Model
{
	public static class EntityConfig
	{
		public static string downPath
		{
			get;
			set;
		}

		public static string certWorld
		{
			get;
			set;
		}

		public static string certPath
		{
			get;
			set;
		}

		public static string configPath
		{
			get;
			set;
		}

		public static string hisPath
		{
			get;
			set;
		}

		static EntityConfig()
		{
			downPath = AppDomain.CurrentDomain.BaseDirectory + "\\Download\\";
			certPath = AppDomain.CurrentDomain.BaseDirectory + "\\cert.mwx";
			configPath = AppDomain.CurrentDomain.BaseDirectory + "\\config\\data.xml";
			hisPath = AppDomain.CurrentDomain.BaseDirectory + "\\config\\history.xml";
			if (File.Exists(configPath))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(configPath);
				XmlNode firstChild = xmlDocument.FirstChild;
				XmlNode xmlNode = firstChild.SelectSingleNode("DOWNPATH");
				if (xmlNode != null && !string.IsNullOrWhiteSpace(xmlNode.InnerText))
				{
					downPath = xmlNode.InnerText;
				}
				XmlNode xmlNode2 = firstChild.SelectSingleNode("CERTWORLD");
				if (xmlNode2 != null && !string.IsNullOrWhiteSpace(xmlNode2.InnerText))
				{
					certWorld = xmlNode2.InnerText;
				}
			}
		}
	}
}
