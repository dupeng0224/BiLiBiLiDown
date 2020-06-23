using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace BilibiliDown.Common
{
	internal class XMLUtil
	{
		public static string SESSION_DATA = "SESSION_DATA";

		private static string configPath = "config\\Settings.xml";

		public static void saveConfig(string key, string value)
		{
			if (!Directory.Exists("config"))
			{
				Directory.CreateDirectory("config");
			}
			if (!File.Exists(configPath))
			{
				File.Create(configPath).Close();
			}
			XmlTextWriter xmlTextWriter = new XmlTextWriter(configPath, Encoding.UTF8);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Settings");
			xmlTextWriter.WriteStartElement(key);
			xmlTextWriter.WriteCData(value);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
		}

		public static string getConfig(string key)
		{
			if (!File.Exists(configPath))
			{
				return "";
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(configPath);
			IEnumerator enumerator = xmlDocument.SelectNodes("Settings").GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					XmlNodeList elementsByTagName = ((XmlElement)enumerator.Current).GetElementsByTagName(key);
					if (elementsByTagName != null && elementsByTagName.Count > 0)
					{
						return elementsByTagName[0].InnerText;
					}
					return "";
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return "";
		}
	}
}
