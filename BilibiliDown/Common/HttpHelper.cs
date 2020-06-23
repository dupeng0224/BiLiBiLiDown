using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace BilibiliDown.Common
{
	public class HttpHelper
	{
		public static string cookie = "";

		private Encoding encoding = Encoding.Default;

		private Encoding postencoding = Encoding.Default;

		private HttpWebRequest request;

		private HttpWebResponse response;

		private IPEndPoint _IPEndPoint;

		public HttpResult GetHtml(HttpItem item)
		{
			HttpResult httpResult = new HttpResult();
			try
			{
				SetRequest(item);
			}
			catch (Exception ex)
			{
				return new HttpResult
				{
					Cookie = cookie,
					Header = null,
					Html = ex.Message,
					StatusDescription = "配置参数时出错：" + ex.Message
				};
			}
			try
			{
				using (response = (HttpWebResponse)request.GetResponse())
				{
					GetData(item, httpResult);
				}
			}
			catch (WebException ex2)
			{
				if (ex2.Response != null)
				{
					using (response = (HttpWebResponse)ex2.Response)
					{
						GetData(item, httpResult);
					}
				}
				else
				{
					httpResult.Html = ex2.Message;
				}
			}
			catch (Exception ex3)
			{
				httpResult.Html = ex3.Message;
			}
			if (item.IsToLower)
			{
				httpResult.Html = httpResult.Html.ToLower();
			}
			return httpResult;
		}

		private void GetData(HttpItem item, HttpResult result)
		{
			if (response != null)
			{
				result.StatusCode = response.StatusCode;
				result.StatusDescription = response.StatusDescription;
				result.Header = response.Headers;
				result.ResponseUri = response.ResponseUri.ToString();
				if (response.Cookies != null)
				{
					result.CookieCollection = response.Cookies;
				}
				if (response.Headers["set-cookie"] != null)
				{
					result.Cookie = response.Headers["set-cookie"];
				}
				byte[] @byte = GetByte();
				if (@byte != null && @byte.Length != 0)
				{
					SetEncoding(item, result, @byte);
					result.Html = encoding.GetString(@byte);
				}
				else
				{
					result.Html = string.Empty;
				}
			}
		}

		private void SetEncoding(HttpItem item, HttpResult result, byte[] ResponseByte)
		{
			if (item.ResultType == ResultType.Byte)
			{
				result.ResultByte = ResponseByte;
			}
			if (encoding == null)
			{
				Match match = Regex.Match(Encoding.Default.GetString(ResponseByte), "<meta[^<]*charset=([^<]*)[\"']", RegexOptions.IgnoreCase);
				string text = string.Empty;
				if (match != null && match.Groups.Count > 0)
				{
					text = match.Groups[1].Value.ToLower().Trim();
				}
				if (text.Length > 2)
				{
					try
					{
						encoding = Encoding.GetEncoding(text.Replace("\"", string.Empty).Replace("'", "").Replace(";", "")
							.Replace("iso-8859-1", "gbk")
							.Trim());
					}
					catch
					{
						if (string.IsNullOrEmpty(response.CharacterSet))
						{
							encoding = Encoding.UTF8;
						}
						else
						{
							encoding = Encoding.GetEncoding(response.CharacterSet);
						}
					}
				}
				else if (string.IsNullOrEmpty(response.CharacterSet))
				{
					encoding = Encoding.UTF8;
				}
				else
				{
					encoding = Encoding.GetEncoding(response.CharacterSet);
				}
			}
		}

		private byte[] GetByte()
		{
			byte[] array = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				if (response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
				{
					new GZipStream(response.GetResponseStream(), CompressionMode.Decompress).CopyTo(memoryStream, 10240);
				}
				else
				{
					response.GetResponseStream().CopyTo(memoryStream, 10240);
				}
				return memoryStream.ToArray();
			}
		}

		private void SetRequest(HttpItem item)
		{
			SetCer(item);
			if (item.IPEndPoint != null)
			{
				_IPEndPoint = item.IPEndPoint;
				request.ServicePoint.BindIPEndPointDelegate = BindIPEndPointCallback;
			}
			if (item.Header != null && item.Header.Count > 0)
			{
				string[] allKeys = item.Header.AllKeys;
				foreach (string name in allKeys)
				{
					request.Headers.Add(name, item.Header[name]);
				}
			}
			SetProxy(item);
			if (item.ProtocolVersion != null)
			{
				request.ProtocolVersion = item.ProtocolVersion;
			}
			request.ServicePoint.Expect100Continue = item.Expect100Continue;
			request.Method = item.Method;
			request.Timeout = item.Timeout;
			request.KeepAlive = item.KeepAlive;
			request.ReadWriteTimeout = item.ReadWriteTimeout;
			if (!string.IsNullOrWhiteSpace(item.Host))
			{
				request.Host = item.Host;
			}
			if (item.IfModifiedSince.HasValue)
			{
				request.IfModifiedSince = Convert.ToDateTime(item.IfModifiedSince);
			}
			request.Accept = item.Accept;
			request.ContentType = item.ContentType;
			request.UserAgent = item.UserAgent;
			encoding = item.Encoding;
			request.Credentials = item.ICredentials;
			SetCookie(item);
			request.Referer = item.Referer;
			request.AllowAutoRedirect = item.Allowautoredirect;
			if (item.MaximumAutomaticRedirections > 0)
			{
				request.MaximumAutomaticRedirections = item.MaximumAutomaticRedirections;
			}
			SetPostData(item);
			if (item.Connectionlimit > 0)
			{
				request.ServicePoint.ConnectionLimit = item.Connectionlimit;
			}
		}

		private void SetCer(HttpItem item)
		{
			if (!string.IsNullOrWhiteSpace(item.CerPath))
			{
				ServicePointManager.ServerCertificateValidationCallback = CheckValidationResult;
				request = (HttpWebRequest)WebRequest.Create(item.URL);
				SetCerList(item);
				request.ClientCertificates.Add(new X509Certificate(item.CerPath));
			}
			else
			{
				request = (HttpWebRequest)WebRequest.Create(item.URL);
				SetCerList(item);
			}
		}

		private void SetCerList(HttpItem item)
		{
			if (item.ClentCertificates != null && item.ClentCertificates.Count > 0)
			{
				foreach (X509Certificate clentCertificate in item.ClentCertificates)
				{
					request.ClientCertificates.Add(clentCertificate);
				}
			}
		}

		private void SetCookie(HttpItem item)
		{
			if (!string.IsNullOrEmpty(item.Cookie))
			{
				request.Headers[HttpRequestHeader.Cookie] = item.Cookie;
			}
			if (item.ResultCookieType == ResultCookieType.CookieCollection)
			{
				request.CookieContainer = new CookieContainer();
				if (item.CookieCollection != null && item.CookieCollection.Count > 0)
				{
					request.CookieContainer.Add(item.CookieCollection);
				}
			}
		}

		private void SetPostData(HttpItem item)
		{
			if (!request.Method.Trim().ToLower().Contains("get"))
			{
				if (item.PostEncoding != null)
				{
					postencoding = item.PostEncoding;
				}
				byte[] array = null;
				if (item.PostDataType == PostDataType.Byte && item.PostdataByte != null && item.PostdataByte.Length != 0)
				{
					array = item.PostdataByte;
				}
				else if (item.PostDataType == PostDataType.FilePath && !string.IsNullOrWhiteSpace(item.Postdata))
				{
					StreamReader streamReader = new StreamReader(item.Postdata, postencoding);
					array = postencoding.GetBytes(streamReader.ReadToEnd());
					streamReader.Close();
				}
				else if (!string.IsNullOrWhiteSpace(item.Postdata))
				{
					array = postencoding.GetBytes(item.Postdata);
				}
				if (array != null)
				{
					request.ContentLength = array.Length;
					request.GetRequestStream().Write(array, 0, array.Length);
				}
			}
		}

		private void SetProxy(HttpItem item)
		{
			bool flag = false;
			if (!string.IsNullOrWhiteSpace(item.ProxyIp))
			{
				flag = item.ProxyIp.ToLower().Contains("ieproxy");
			}
			if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !flag)
			{
				if (item.ProxyIp.Contains(":"))
				{
					string[] array = item.ProxyIp.Split(':');
					WebProxy webProxy = new WebProxy(array[0].Trim(), Convert.ToInt32(array[1].Trim()));
					webProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
					request.Proxy = webProxy;
				}
				else
				{
					WebProxy webProxy2 = new WebProxy(item.ProxyIp, BypassOnLocal: false);
					webProxy2.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
					request.Proxy = webProxy2;
				}
			}
			else if (!flag)
			{
				request.Proxy = item.WebProxy;
			}
		}

		private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}

		private IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
		{
			return _IPEndPoint;
		}
	}
}
