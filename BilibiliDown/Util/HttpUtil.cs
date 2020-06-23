/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.Util
 *文件名：  HttpUtil
 *版本号：  V1.0.0.0
 *唯一标识：63de1a13-7d42-4881-bb03-8c997f515847
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:41:04
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:41:04
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliDown.Util
{
	public class HttpUtil
	{
		public static string cookie = "";

		public static string HttpPost(string Url, string postDataStr)
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(Url);
			obj.Method = "POST";
			obj.ContentType = "application/x-www-form-urlencoded";
			obj.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
			obj.Headers.Add("cookie", cookie);
			Console.WriteLine("cookie:" + cookie);
			StreamWriter streamWriter = new StreamWriter(obj.GetRequestStream(), Encoding.GetEncoding("gb2312"));
			streamWriter.Write(postDataStr);
			streamWriter.Close();
			Stream responseStream = ((HttpWebResponse)obj.GetResponse()).GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			responseStream.Close();
			return result;
		}

		public static CookieCollection HttpPostGetCookie(string Url, string postDataStr)
		{
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create(Url);
			obj.Method = "POST";
			obj.ContentType = "application/x-www-form-urlencoded";
			obj.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
			obj.Headers.Add("cookie", cookie);
			StreamWriter streamWriter = new StreamWriter(obj.GetRequestStream(), Encoding.GetEncoding("gb2312"));
			streamWriter.Write(postDataStr);
			streamWriter.Close();
			return ((HttpWebResponse)obj.GetResponse()).Cookies;
		}

		public static string HttpGet(string Url, string postDataStr, string referer)
		{
			if (postDataStr == null)
			{
				postDataStr = "";
			}
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url + ((postDataStr == "") ? "" : "?") + postDataStr);
			httpWebRequest.Method = "GET";
			httpWebRequest.ReadWriteTimeout = 3000;
			httpWebRequest.Timeout = 3000;
			httpWebRequest.ContentType = "text/html;charset=UTF-8";
			if (referer != null)
			{
				httpWebRequest.Referer = referer;
			}
			Console.WriteLine("Cookie:" + cookie);
			httpWebRequest.Headers.Add("Cookie", cookie);
			httpWebRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			Stream stream = httpWebResponse.GetResponseStream();
			if (httpWebResponse.Headers["Content-Encoding"] != null && httpWebResponse.Headers["Content-Encoding"].ToLower().Contains("gzip"))
			{
				stream = new GZipStream(stream, CompressionMode.Decompress);
			}
			StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			stream.Close();
			return result;
		}
	}
}
