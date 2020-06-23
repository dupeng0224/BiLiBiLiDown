using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BilibiliDown.Common
{
	public static class Common
	{
		public static string ToJson(this object obj)
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
			jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			jsonSerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
			jsonSerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
			return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
		}

		public static string ToXml(this object obj)
		{
			XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
			object[] customAttributes = obj.GetType().GetCustomAttributes(inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				XmlRootAttribute xmlRootAttribute = customAttributes[i] as XmlRootAttribute;
				if (xmlRootAttribute != null)
				{
					xmlSerializerNamespaces.Add(string.Empty, xmlRootAttribute.Namespace);
				}
			}
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = Encoding.UTF8;
			xmlWriterSettings.OmitXmlDeclaration = true;
			if (xmlSerializerNamespaces.Count == 0)
			{
				xmlSerializerNamespaces.Add(string.Empty, string.Empty);
			}
			MemoryStream memoryStream = new MemoryStream();
			XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
			{
				xmlSerializer.Serialize(xmlWriter, obj, xmlSerializerNamespaces);
				xmlWriter.Close();
			}
			memoryStream.Position = 0L;
			StreamReader streamReader = new StreamReader(memoryStream);
			string result = streamReader.ReadToEnd();
			streamReader.Dispose();
			memoryStream.Dispose();
			return result;
		}

		public static void ToXml(this object obj, string path)
		{
			string path2 = Path.GetDirectoryName(path) + "\\";
			Path.GetFileName(path);
			try
			{
				if (!Directory.Exists(path2))
				{
					Directory.CreateDirectory(path2);
				}
				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
			catch (Exception)
			{
			}
			XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
			object[] customAttributes = obj.GetType().GetCustomAttributes(inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				XmlRootAttribute xmlRootAttribute = customAttributes[i] as XmlRootAttribute;
				if (xmlRootAttribute != null)
				{
					xmlSerializerNamespaces.Add(string.Empty, xmlRootAttribute.Namespace);
				}
			}
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "    ";
			xmlWriterSettings.NewLineChars = "\r\n";
			xmlWriterSettings.Encoding = Encoding.UTF8;
			if (xmlSerializerNamespaces.Count == 0)
			{
				xmlSerializerNamespaces.Add(string.Empty, string.Empty);
			}
			using (FileStream output = new FileStream(path, FileMode.Create))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
				using (XmlWriter xmlWriter = XmlWriter.Create(output, xmlWriterSettings))
				{
					xmlSerializer.Serialize(xmlWriter, obj, xmlSerializerNamespaces);
					xmlWriter.Close();
				}
			}
		}

		public static T ToXmlObject<T>(this string xml) where T : class, new()
		{
			try
			{
				using (StringReader textReader = new StringReader(xml))
				{
					return (T)new XmlSerializer(typeof(T)).Deserialize(textReader);
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static string ToMD5(this string clearCode)
		{
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(clearCode));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("x2"));
			}
			return stringBuilder.ToString().ToUpper();
		}

		public static string JsapiSignToSha1(this string inStr)
		{
			try
			{
				byte[] source = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(inStr));
				return string.Join("", source.Select((byte b) => b.ToString("x2")).ToArray()).ToLower();
			}
			catch (Exception ex)
			{
				throw new Exception("Sha1加密出错：" + ex.Message);
			}
		}

		public static string GetLocalIP()
		{
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				for (int i = 0; i < hostEntry.AddressList.Length; i++)
				{
					if (hostEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						string text = hostEntry.AddressList[i].ToString();
						if (!(text.Split('.')[0] == "127") && !(text.Split('.')[0] == "169"))
						{
							return text;
						}
					}
				}
				return "";
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
	}
}
