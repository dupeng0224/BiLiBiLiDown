using BilibiliDown.Common;
using BilibiliDown.Model;
using BilibiliDown.Pojo;
using BilibiliDown.Pojo.BV;
using BilibiliDown.SubForms;
using BilibiliDown.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace BilibiliDown
{
	public partial class Form1 : Form
    {
		public delegate void deleBtnAnalysisEnabled(bool enabled);

		public delegate void deleBtnAnalysisText(string mess);

		public delegate void deleLabErrorText(string mess);

		public delegate void deleListboxItem(object item);

		public delegate void deleDatagridBind(object obj);

		private object objMoniter = new object();

		private deleBtnAnalysisText SetMyBtnAnalysisText;

		private deleBtnAnalysisEnabled SetMyBtnAnalysisEnabled;

		private deleLabErrorText SetMyLabErrorText;

		private deleListboxItem SetMyListboxItem;

		private deleDatagridBind SetMyDatagridBind;

		private static HttpListener httpobj;

		private static bool isChecked;		

		public List<PageVideo> pageVideos
		{
			get;
			set;
		}

		public List<PageVideo> DownVideos
		{
			get;
			set;
		} = new List<PageVideo>();


		private int gridRowIndex
		{
			get;
			set;
		}

		private int gridColIndex
		{
			get;
			set;
		}

		private int gridScroll
		{
			get;
			set;
		}

		public void setBtnAnalysisEnabled(bool enabled)
		{
			btnAnalysis.Enabled = enabled;
		}

		public void setBtnAnalysisText(string mess)
		{
			btnAnalysis.Text = mess;
		}

		public void setLabErrorText(string mess)
		{
			labError.Text = mess;
		}

		public void setListboxItem(object item)
		{
			lsbAnalysisResult.Items.Add(item);
		}

		public void setDatagridBind(object obj)
		{
			try
			{
				pageVideoBindingSource.DataSource = null;
				pageVideoBindingSource.DataSource = obj;
				gridDowntable.ClearSelection();
				if (gridDowntable.Rows.Count > gridRowIndex)
				{
					gridDowntable.CurrentCell = gridDowntable.Rows[gridRowIndex].Cells[gridColIndex];
				}
				gridDowntable.FirstDisplayedScrollingRowIndex = gridScroll;
			}
			catch (Exception)
			{
			}
		}

		public void StartListener(int port = 8848)
		{
			try
			{
				httpobj = new HttpListener();
				httpobj.Prefixes.Add($"http://+:{port}/");
				httpobj.Start();
				httpobj.BeginGetContext(Result, null);
				while (true)
				{
					Thread.Sleep(100000);
				}
			}
			catch (Exception)
			{
			}
		}

		private void Result(IAsyncResult ar)
		{
			httpobj.BeginGetContext(Result, null);
			string arg = Guid.NewGuid().ToString();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"接到新的请求:{arg},时间：{DateTime.Now.ToString()}");
			HttpListenerContext httpListenerContext = httpobj.EndGetContext(ar);
			HttpListenerRequest request = httpListenerContext.Request;
			HttpListenerResponse response = httpListenerContext.Response;
			Encoding contentEncoding = request.ContentEncoding;
			httpListenerContext.Response.ContentType = $"text/html;charset={contentEncoding.BodyName}";
			httpListenerContext.Response.AddHeader("Content-type", "text/html");
			httpListenerContext.Response.ContentEncoding = contentEncoding;
			string s = "你这地址是啥呀？不漂损啊！";
			if (request.HttpMethod == "POST" && request.InputStream != null)
			{
				s = HandleRequest(request, response);
			}
			else if (request.HttpMethod == "GET" && request.QueryString != null)
			{
				string[] allKeys = request.QueryString.AllKeys;
				foreach (string text in allKeys)
				{
					string a = text.ToLower();
					if (a == "getfile")
					{
						if (request.QueryString != null && request.QueryString.AllKeys.Count() != 0 && !string.IsNullOrWhiteSpace(request.QueryString[text]) && !(request.QueryString[text] == "0"))
						{
							string path = HttpUtility.UrlDecode(request.QueryString[text], contentEncoding);
							FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
							byte[] array = new byte[(int)fileStream.Length];
							fileStream.Read(array, 0, array.Length);
							fileStream.Close();
							httpListenerContext.Response.ContentType = $"application/octet-stream;charset={contentEncoding.BodyName}";
							response.AddHeader("Content-Disposition", "attachment;FileName=" + HttpUtility.UrlEncode(Path.GetFileName(path)));
							using (Stream stream = response.OutputStream)
							{
								stream.Write(array, 0, array.Length);
							}
							return;
						}
						if (DownVideos == null)
						{
							DownVideos = new List<PageVideo>();
						}
						string text2 = "";
						int num = 0;
						foreach (PageVideo downVideo in DownVideos)
						{
							if (File.Exists(downVideo.SavePath))
							{
								text2 += $"<tr><td>{++num}</td><td><a href=\"/?GetFile={HttpUtility.UrlEncode(downVideo.SavePath, contentEncoding)}\">{downVideo.title}</a></td></tr>";
							}
						}
						s = $"<html lang=\"zh\"><head><meta http-equiv=\"content-type\" content=\"text/html;charset={contentEncoding.BodyName}\"></head><body><div><table>{text2}</table></div></html>";
					}
					else
					{
						s = "你这地址是啥呀？不漂损啊！";
					}
				}
			}
			byte[] bytes = contentEncoding.GetBytes(s);
			try
			{
				using (Stream stream2 = response.OutputStream)
				{
					stream2.Write(bytes, 0, bytes.Length);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private static string HandleRequest(HttpListenerRequest request, HttpListenerResponse response)
		{
			string text = null;
			try
			{
				List<byte> list = new List<byte>();
				byte[] array = new byte[2048];
				int num = 0;
				int num2 = 0;
				do
				{
					num = request.InputStream.Read(array, 0, array.Length);
					num2 += num;
					list.AddRange(array);
				}
				while (num != 0);
				text = Encoding.UTF8.GetString(list.ToArray(), 0, num2);
			}
			catch (Exception ex)
			{
				response.StatusDescription = "404";
				response.StatusCode = 404;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"在接收数据时发生错误:{ex.ToString()}");
				return $"在接收数据时发生错误:{ex.ToString()}";
			}
			response.StatusDescription = "200";
			response.StatusCode = 200;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"接收数据完成:{text.Trim()},时间：{DateTime.Now.ToString()}");
			return "接收数据完成";
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (XMLUtil.getConfig(XMLUtil.SESSION_DATA) != "")
			{
				HttpUtil.cookie = XMLUtil.getConfig(XMLUtil.SESSION_DATA);
				HttpHelper.cookie = XMLUtil.getConfig(XMLUtil.SESSION_DATA);
			}
			string currentDirectory = Environment.CurrentDirectory;
			if (new Regex("[\\u4e00-\\u9fa5]").IsMatch(currentDirectory) || currentDirectory.IndexOf(" ") != -1)
			{
				MessageBox.Show("本软件安装路径不可以存在中文或空格,否则容易出现格式转换失败,当前路径:" + currentDirectory);
				Application.Exit();
			}
			toolStripStatusVersion.Text = "版本号:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			try
			{
				BiliUserInfo accountInfo = BiliUtil.getAccountInfo();
				Console.WriteLine(" 请求用户信息 " + accountInfo.code + " ");
				if (accountInfo.code == 0)
				{
					logOnControll();
				}
				else
				{
					XMLUtil.saveConfig(XMLUtil.SESSION_DATA, "");
				}
			}
			catch
			{
			}
			SetMyBtnAnalysisText = setBtnAnalysisText;
			SetMyBtnAnalysisEnabled = setBtnAnalysisEnabled;
			SetMyLabErrorText = setLabErrorText;
			SetMyListboxItem = setListboxItem;
			SetMyDatagridBind = setDatagridBind;
			if (File.Exists(EntityConfig.hisPath))
			{
				try
				{
					string xml = File.ReadAllText(EntityConfig.hisPath, Encoding.UTF8);
					DownVideos = xml.ToXmlObject<List<PageVideo>>();
					if (DownVideos == null)
					{
						DownVideos = new List<PageVideo>();
					}
					gridDowntable.BeginInvoke(SetMyDatagridBind, DownVideos);
				}
				catch (Exception)
				{
				}
			}
			Thread thread = new Thread((ParameterizedThreadStart)delegate
			{
				while (true)
				{
					try
					{
						gridDowntable.BeginInvoke((Action)delegate
						{
							gridDowntable.Refresh();
						});
						Thread.Sleep(500);
					}
					catch (Exception ex6)
					{
						Console.WriteLine(ex6.Message);
					}
				}
			});
			thread.IsBackground = true;
			thread.Start();
			ManualResetEvent[] mres2 = default(ManualResetEvent[]);
			ManualResetEvent[] mres = default(ManualResetEvent[]);
			Thread thread2 = new Thread((ThreadStart)delegate
			{
				Form1 form = default(Form1);
				List<PageVideo> items = default(List<PageVideo>);
				ManualResetEvent[] downMres = default(ManualResetEvent[]);
				while (true)
				{
					form = this;
					int count = 5;
					items = DownVideos.FindAll((PageVideo x) => x.DownType == TypeDown.等待下载).Take(count).ToList();
					if (items == null || items.Count() == 0)
					{
						Thread.Sleep(500);
					}
					else
					{
						int num = items.Count();
						downMres = new ManualResetEvent[num];
						for (int i = 0; i < num; i++)
						{
							downMres[i] = new ManualResetEvent(initialState: false);
							ThreadPool.QueueUserWorkItem(delegate (object objindex)
							{
								int num2 = (int)objindex;
								PageVideo item = items[num2];
								item.DownType = TypeDown.下载中;
								try
								{
									int num3 = 80;
									int num4 = 16;
									string text = $"https://api.bilibili.com/x/player/playurl?avid={item.aid}&cid={item.cid}&qn={num3}&type=flv&fnver=0&fnval={num4}&otype=json";
									TypeVideo videoType = item.videoType;
									text = ((videoType != TypeVideo.BANGUMI) ? $"https://api.bilibili.com/x/player/playurl?avid={item.aid}&cid={item.cid}&qn={num3}&type=flv&fnver=0&fnval={num4}&otype=json" : $"https://api.bilibili.com/pgc/player/web/playurl?avid={item.aid}&cid={item.cid}&qn={num3}&type=flv&otype=json&fnver={num4}&fnval=80");
									string text2 = HttpUtil.HttpGet(text, null, null);
									Console.WriteLine("视频解析数据:" + text2);
									VideoInfo videoInfo = JsonConvert.DeserializeObject<VideoInfo>(text2);
									DownLoadVideoInfo di = new DownLoadVideoInfo();
									di.aid = item.aid;
									di.cid = item.cid;
									List<DownLoadVideoInfoDetail> list = new List<DownLoadVideoInfoDetail>();
									new List<string>();
									if (videoInfo.data != null && videoInfo.data.durl != null && videoInfo.data.durl.Count > 0)
									{
										di.videoUrls = videoInfo.data.durl.Select((DurlItem d) => new DownLoadVideoInfoDetail
										{
											order = d.order,
											url = d.url
										}).ToList();
										di.vtype = TypeVideo.VIDEOS;
									}
									else if (videoInfo.data != null && videoInfo.data.dash != null)
									{
										videoInfo.data.dash.video.Sort((VideoItem x, VideoItem y) => y.width.CompareTo(x.width));
										VideoItem videoItem = videoInfo.data.dash.video[0];
										string base_url = videoItem.base_url;
										_ = videoItem.bandwidth;
										int id = videoItem.id;
										list.Add(new DownLoadVideoInfoDetail
										{
											order = id,
											url = base_url
										});
										di.videoUrls = list;
										if (videoInfo.data.dash.audio != null)
										{
											di.audioUrls = videoInfo.data.dash.audio.Select((AudioItem a) => a.baseUrl).ToList();
										}
										di.vtype = TypeVideo.VIDEO_AUDIO;
									}
									else if (videoInfo.result != null)
									{
										di.videoUrls = videoInfo.result.durl.Select((DurlItem d) => new DownLoadVideoInfoDetail
										{
											order = d.order,
											url = d.url
										}).ToList();
										di.vtype = TypeVideo.BANGUMI;
									}
									string text3 = EntityConfig.downPath;
									if (!text3.EndsWith("\\") && !text3.EndsWith("/"))
									{
										text3 += "\\";
									}
									text3 = text3 + item.aid + "\\";
									if (!Directory.Exists(text3))
									{
										Directory.CreateDirectory(text3);
									}
									string tmpPath = text3 + $"tmp{item.cid}\\";
									if (!Directory.Exists(tmpPath))
									{
										Directory.CreateDirectory(tmpPath);
									}
									if (di.vtype.Equals(TypeVideo.VIDEOS) || di.vtype.Equals(TypeVideo.BANGUMI))
									{
										if (File.Exists(string.Concat(text3, item.title, ".mp4")))
										{
											File.Delete(string.Concat(text3, item.title, ".mp4"));
										}
										int count2 = di.videoUrls.Count;
										mres2 = new ManualResetEvent[count2];
										for (int j = 0; j < count2; j++)
										{
											mres2[j] = new ManualResetEvent(initialState: false);
											ThreadPool.QueueUserWorkItem(delegate (object downIndex)
											{
												int num9 = (int)downIndex;
												try
												{
													DownLoadVideoInfoDetail downLoadVideoInfoDetail = di.videoUrls[num9];
													string text11 = tmpPath + downLoadVideoInfoDetail.order + FileUtil.GetExtension(downLoadVideoInfoDetail.url);
													item.totalSize = 0L;
													item.downSize = 0L;
													HttpWebRequest obj4 = (HttpWebRequest)WebRequest.Create(downLoadVideoInfoDetail.url);
													obj4.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
													obj4.Timeout = 100000000;
													obj4.Referer = "https://www.bilibili.com/video/av" + item.aid;
													obj4.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
													HttpWebResponse httpWebResponse3 = (HttpWebResponse)obj4.GetResponse();
													long contentLength3 = httpWebResponse3.ContentLength;
													lock (form.objMoniter)
													{
														item.totalSize += contentLength3;
													}
													if (httpWebResponse3.ContentLength != 0L)
													{
														Stream responseStream3 = httpWebResponse3.GetResponseStream();
														Stream stream3 = new FileStream(text11, FileMode.Create);
														long num10 = 0L;
														byte[] array3 = new byte[1024];
														int num11 = responseStream3.Read(array3, 0, array3.Length);
														while (num11 > 0)
														{
															num10 = num11 + num10;
															stream3.Write(array3, 0, num11);
															num11 = responseStream3.Read(array3, 0, array3.Length);
															lock (form.objMoniter)
															{
																item.downSize += num11;
															}
														}
														stream3.Close();
														responseStream3.Close();
														FileUtil.executeFFMpegCommand("ffmpeg -i " + text11 + " -c copy  -bsf:v h264_mp4toannexb -f mpegts " + tmpPath + "input" + downLoadVideoInfoDetail.order + ".ts");
													}
												}
												catch (Exception)
												{
												}
												finally
												{
													mres2[num9].Set();
												}
											}, j);
										}
										WaitHandle.WaitAll(mres2);
										item.downSize = item.totalSize;
										item.DownType = TypeDown.正在合并;
										string text4 = text3 + di.cid + ".mp4";
										FileUtil.mergeNomalVideo(tmpPath, text4, count2);
										if (File.Exists(text4))
										{
											item.title = StringUtil.removeIllegalCharForFileName(item.title);
											string text5 = text4.Replace("\\" + di.cid + ".mp4", string.Concat("\\", item.title, ".mp4"));
											Console.WriteLine("移动" + text4 + " -> " + text5);
											File.Move(text4, text5);
											FileUtil.deleteTmpFord(text3 + $"tmp{di.cid}\\");
											item.SavePath = text5;
											item.DownType = TypeDown.下载完成;
										}
										else
										{
											item.DownType = TypeDown.下载失败;
										}
									}
									else if (di.vtype.Equals(TypeVideo.VIDEO_AUDIO))
									{
										if (File.Exists(text3 + item.aid + "/" + (string)item.title + ".mp4"))
										{
											File.Delete(text3 + item.aid + "/" + (string)item.title + ".mp4");
										}
										string url = di.videoUrls[0].url;
										if (string.IsNullOrWhiteSpace(url))
										{
											item.DownType = TypeDown.下载失败;
										}
										else
										{
											mres = new ManualResetEvent[2];
											mres[0] = new ManualResetEvent(initialState: false);
											mres[1] = new ManualResetEvent(initialState: false);
											string extension = FileUtil.GetExtension(url);
											string text6 = tmpPath + "video" + extension;
											ThreadPool.QueueUserWorkItem(delegate (object x)
											{
												try
												{
													string path2 = x.ToString();
													HttpWebRequest obj3 = (HttpWebRequest)WebRequest.Create(di.videoUrls[0].url);
													obj3.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
													obj3.Timeout = 100000000;
													obj3.Referer = "https://www.bilibili.com/video/av" + item.aid;
													obj3.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
													HttpWebResponse httpWebResponse2 = (HttpWebResponse)obj3.GetResponse();
													long contentLength2 = httpWebResponse2.ContentLength;
													lock (form.objMoniter)
													{
														item.totalSize += contentLength2;
													}
													if (httpWebResponse2.ContentLength != 0L)
													{
														Stream responseStream2 = httpWebResponse2.GetResponseStream();
														Stream stream2 = new FileStream(path2, FileMode.Create);
														long num7 = 0L;
														byte[] array2 = new byte[1024];
														int num8 = responseStream2.Read(array2, 0, array2.Length);
														while (num8 > 0)
														{
															num7 = num8 + num7;
															stream2.Write(array2, 0, num8);
															num8 = responseStream2.Read(array2, 0, array2.Length);
															lock (form.objMoniter)
															{
																item.downSize += num8;
															}
														}
													}
												}
												catch (Exception ex4)
												{
													Console.WriteLine(ex4.StackTrace);
												}
												finally
												{
													mres[0].Set();
												}
											}, text6);
											string text7 = "";
											if (di.audioUrls != null && di.audioUrls.Count > 0)
											{
												string extension2 = FileUtil.GetExtension(di.audioUrls[0]);
												text7 = tmpPath + "audio" + extension2;
												ThreadPool.QueueUserWorkItem(delegate (object x)
												{
													try
													{
														string path = x.ToString();
														HttpWebRequest obj2 = (HttpWebRequest)WebRequest.Create(di.audioUrls[0]);
														obj2.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
														obj2.Timeout = 100000000;
														obj2.Referer = "https://www.bilibili.com/video/av" + item.aid;
														obj2.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.100 Safari/537.36";
														HttpWebResponse httpWebResponse = (HttpWebResponse)obj2.GetResponse();
														long contentLength = httpWebResponse.ContentLength;
														lock (form.objMoniter)
														{
															item.totalSize += contentLength;
														}
														if (httpWebResponse.ContentLength != 0L)
														{
															Stream responseStream = httpWebResponse.GetResponseStream();
															Stream stream = new FileStream(path, FileMode.Create);
															long num5 = 0L;
															byte[] array = new byte[1024];
															int num6 = responseStream.Read(array, 0, array.Length);
															while (num6 > 0)
															{
																num5 = num6 + num5;
																stream.Write(array, 0, num6);
																num6 = responseStream.Read(array, 0, array.Length);
																lock (form.objMoniter)
																{
																	item.downSize += num6;
																}
															}
														}
													}
													catch (Exception ex3)
													{
														Console.WriteLine(ex3.StackTrace);
													}
													finally
													{
														mres[1].Set();
													}
												}, text7);
											}
											else
											{
												mres = new ManualResetEvent[1]
												{
													new ManualResetEvent(initialState: false)
												};
											}
											WaitHandle.WaitAll(mres);
											item.downSize = item.totalSize;
											item.DownType = TypeDown.正在合并;
											string text8 = text3 + "/";
											string text9 = text8 + item.cid + ".mp4";
											FileUtil.mergeVideoAndAudio(text6, text7, item.cid.ToString(), text9);
											if (File.Exists(text9))
											{
												item.title = StringUtil.removeIllegalCharForFileName(item.title);
												string text10 = text9.Replace("/" + item.cid + ".mp4", string.Concat("/", item.title, ".mp4"));
												if (File.Exists(text10))
												{
													File.Delete(text10);
												}
												File.Move(text9, text10);
												item.SavePath = text10;
												FileUtil.deleteTmpFord(text8 + $"tmp{item.cid}\\");
												item.DownType = TypeDown.下载完成;
											}
											else
											{
												item.DownType = TypeDown.下载失败;
											}
										}
									}
								}
								catch (Exception ex2)
								{
									item.DownType = TypeDown.下载失败;
									Console.WriteLine(ex2.StackTrace);
								}
								finally
								{
									downMres[num2].Set();
								}
							}, i);
						}
						WaitHandle.WaitAll(downMres);
					}
				}
			});
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread((ThreadStart)delegate
			{
				while (true)
				{
					StartListener(80);
				}
			});
			thread3.IsBackground = true;
			thread3.Start();
		}

		public bool check()
		{
			string text = FileUtil.checkOpenId();
			string str = "http://www.acgres.com/qrcode/ajax/query/";
			str = ((text == null || "".Equals(text)) ? (str + "?mac=" + ManagementSystemInfo.getMac().Trim()) : (str + "?openid=" + text.Trim()));
			Console.WriteLine("----" + str + "---");
			string text2 = "";
			try
			{
				text2 = HttpUtil.HttpGet(str, null, null);
			}
			catch (Exception)
			{
			}
			if (text2 == null || "".Equals(text2))
			{
				return false;
			}
			Console.WriteLine(text2);
			MessagePack messagePack = JsonConvert.DeserializeObject<MessagePack>(text2);
			switch (messagePack.status)
			{
				case "nodata":
					new Subscribe().ShowDialog();
					return false;
				case "fobidden":
					MessageBox.Show("没有守护契约,你已失去了使用该道具的资格");
					return false;
				case "custom":
					MessageBox.Show(messagePack.message);
					return false;
				default:
					FileUtil.writeOpenId(messagePack.openid);
					return true;
			}
		}

		private void btnAnalysis_Click(object sender, EventArgs e)
		{
			if ("".Equals(txtUrl.Text))
			{
				MessageBox.Show("请输入B站地址");
				return;
			}
			string text = txtUrl.Text;
			if (text.IndexOf(".bilibili.com") == -1)
			{
				MessageBox.Show("请输入B站地址(B站的哦!)");
				return;
			}
			string text2 = HttpUtil.HttpGet(text, null, null);
			string text3 = txtUrl.Text;
			Match match = new Regex("/BV([a-zA-Z0-9]+)").Match(text3);
			if (match.Groups.Count > 1)
			{
				string value = match.Groups[1].Value;
				if (value == null || value == "")
				{
					MessageBox.Show("解析BVID失败");
					return;
				}
				value = "BV" + value;
				BVMessagePack bVMessagePack = JsonConvert.DeserializeObject<BVMessagePack>(HttpUtil.HttpGet("https://api.bilibili.com/x/web-interface/view?bvid=" + value, null, null));
				if (bVMessagePack.code != 0)
				{
					MessageBox.Show("解析失败:" + bVMessagePack.message);
					return;
				}
				txtUrl.Text = "https://www.bilibili.com/video/av" + bVMessagePack.data.aid;
			}
			//if (text2.IndexOf("未经作者授权，禁止转载") != -1)
			//{
			//	MessageBox.Show("视频版权保护，不可以下载");
			//}
			//else 
			//if (check())
			{
				isChecked = true;
				lsbAnalysisResult.Items.Clear();
				ManualResetEvent mre = new ManualResetEvent(initialState: false);
				Thread thread = new Thread((ParameterizedThreadStart)delegate
				{
					btnAnalysis.BeginInvoke(SetMyBtnAnalysisEnabled, false);
					int num3 = 0;
					while (true)
					{
						string str = "".PadLeft(6 - num3 % 6);
						btnAnalysis.BeginInvoke(SetMyBtnAnalysisText, "音视频文件解析中" + str);
						if (mre.WaitOne(100))
						{
							break;
						}
						num3++;
					}
					btnAnalysis.BeginInvoke(SetMyBtnAnalysisEnabled, true);
					btnAnalysis.BeginInvoke(SetMyBtnAnalysisText, "解析地址");
				});
				thread.IsBackground = true;
				thread.Start();
				Thread thread2 = new Thread(delegate (object url)
				{
					labError.BeginInvoke(SetMyLabErrorText, "");
					try
					{
						string text4 = url.ToString();
						if (string.IsNullOrWhiteSpace(text4))
						{
							labError.BeginInvoke(SetMyLabErrorText, "地址不可为空");
						}
						else
						{
							new HttpHelper();
							string text5 = "";
							if (text4.Contains("av"))
							{
								Match match2 = new Regex("av(\\d+)").Match(text4);
								if (match2.Groups.Count > 1)
								{
									text5 = match2.Groups[1].Value;
								}
								Match match3 = new Regex("p=(\\d+)").Match(text4);
								if (match3.Groups.Count > 1)
								{
									_ = match3.Groups[1].Value;
								}
								if (string.IsNullOrWhiteSpace(text5))
								{
									labError.BeginInvoke(SetMyLabErrorText, "请输入正确B站视频地址");
								}
								else
								{
									BLResponse bLResponse = JsonConvert.DeserializeObject<BLResponse>(HttpUtil.HttpGet("https://api.bilibili.com/x/web-interface/view?aid=" + text5 + "&a=1", null, "https://www.bilibili.com/video/av" + text5));
									if (bLResponse == null || bLResponse.data == null || bLResponse.data.pages == null)
									{
										labError.BeginInvoke(SetMyLabErrorText, "数据异常，请联系管理员");
									}
									else if (bLResponse.code != 0)
									{
										labError.BeginInvoke(SetMyLabErrorText, bLResponse.message);
									}
									else
									{
										pageVideos = new List<PageVideo>();
										int num = 0;
										while (num < bLResponse.data.pages.Count)
										{
											Page page = bLResponse.data.pages[num];
											string fileName = string.IsNullOrEmpty(page.part) ? bLResponse.data.title : page.part;
											PageVideo pageVideo = new PageVideo
											{
												aid = bLResponse.data.aid,
												cid = page.cid,
												p = page.page,
												pageIndex = num,
												title = StringUtil.removeIllegalCharForFileName(fileName),
												videoType = TypeVideo.VIDEOS
											};
											pageVideos.Add(pageVideo);
											lsbAnalysisResult.BeginInvoke(SetMyListboxItem, $"{++num}.{pageVideo.title}");
										}
									}
								}
							}
							else if (text4.Contains("bangumi"))
							{
								string text6 = HttpUtil.HttpGet(txtUrl.Text, null, null);
								if (text6.IndexOf("大会员专享") != -1)
								{
									MessageBox.Show("本下载工具不支持大会员视频下载,请知晓 谢谢");
								}
								else
								{
									Regex regex = new Regex("ssId\":(\\d+)");
									Match match4 = regex.Match(text6);
									string text7 = null;
									if (match4.Groups.Count > 1)
									{
										text7 = match4.Groups[1].Value;
									}
									if (text7 == null)
									{
										new Regex("/play/ss(\\d+)");
										if (regex.Match(text6).Groups.Count > 1)
										{
											text7 = match4.Groups[1].Value;
										}
									}
									if (text7 == null)
									{
										MessageBox.Show("未能获取到番剧ID");
									}
									else
									{
										string text8 = HttpUtil.HttpGet("https://bangumi.bilibili.com/view/web_api/season?season_id=" + text7, null, null);
										SeasonResult seasonResult = JsonConvert.DeserializeObject<SeasonResult>(text8);
										if (seasonResult == null)
										{
											labError.BeginInvoke(SetMyLabErrorText, "报错了，不好意思|" + text8);
										}
										else if (seasonResult.result == null || seasonResult.result.episodes == null || seasonResult.result.episodes.Count == 0)
										{
											labError.BeginInvoke(SetMyLabErrorText, "姨，没有信息|");
										}
										else if (seasonResult.code != 0)
										{
											labError.BeginInvoke(SetMyLabErrorText, "报错了，不好意思|" + seasonResult.message);
										}
										else
										{
											pageVideos = new List<PageVideo>();
											int num2 = 0;
											while (num2 < seasonResult.result.episodes.Count)
											{
												EpisodesItem episodesItem = seasonResult.result.episodes[num2];
												string text9 = episodesItem.index_title.Trim();
												PageVideo pageVideo2 = new PageVideo
												{
													aid = episodesItem.aid,
													cid = episodesItem.cid,
													p = episodesItem.page,
													pageIndex = num2,
													title = text9,
													videoType = TypeVideo.BANGUMI
												};
												pageVideos.Add(pageVideo2);
												lsbAnalysisResult.BeginInvoke(SetMyListboxItem, $"{++num2}.{pageVideo2.title}");
											}
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						labError.BeginInvoke(SetMyLabErrorText, "报错了，不好意思:" + ex.Message);
					}
					finally
					{
						mre.Set();
					}
				});
				thread2.IsBackground = true;
				thread2.Start(txtUrl.Text);
			}
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (lsbAnalysisResult.SelectedIndex == -1)
			{
				labError.BeginInvoke(SetMyLabErrorText, "姨，下载数据木有选？");
				return;
			}
			foreach (object selectedItem in lsbAnalysisResult.SelectedItems)
			{
				int _i = lsbAnalysisResult.Items.IndexOf(selectedItem);
				PageVideo pageVideo = pageVideos.Find((PageVideo x) => x.pageIndex == _i);
				if (pageVideo == null)
				{
					labError.BeginInvoke(SetMyLabErrorText, "姨，下载数据没了！");
				}
				if (!DownVideos.Contains(pageVideo))
				{
					pageVideo.title = _i + 1 + "." + (string)pageVideo.title;
					DownVideos.Insert(0, pageVideo);
					pageVideo.DownType = TypeDown.等待下载;
				}
			}
			gridDowntable.BeginInvoke(SetMyDatagridBind, DownVideos);
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (DownVideos.Count > e.RowIndex && !string.IsNullOrWhiteSpace(DownVideos[e.RowIndex]?.SavePath))
			{
				string text = DownVideos[e.RowIndex].SavePath;
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (File.Exists(text))
					{
						Process.Start(Path.GetDirectoryName(text));
					}
					else
					{
						MessageBox.Show("文件被移除");
					}
				}
			}
			gridDowntable.ClearSelection();
			gridRowIndex = e.RowIndex;
			gridColIndex = e.ColumnIndex;
		}

		private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
		{
			gridScroll = e.NewValue;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			gridRowIndex = e.RowIndex;
			gridColIndex = e.ColumnIndex;
		}

		private void gridDowntable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			gridRowIndex = e.RowIndex;
			gridColIndex = e.ColumnIndex;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DownVideos.FindAll((PageVideo x) => x.DownType == TypeDown.下载完成).ToXml(EntityConfig.hisPath);
		}

		private void GlobalConfigToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new frmGlobalConfig().ShowDialog();
		}

		private void toolStripCert_Click(object sender, EventArgs e)
		{
			new frmCert().ShowDialog();
		}

		private void 登录B站视频账号ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new QrLogin().ShowDialog();
		}

		private void logOnControll()
		{
			if (btnDown.Text.IndexOf("登陆后") == -1)
			{
				btnDown.Text += "(登陆后最高清)";
				btnDown.ForeColor = Color.Red;
				btnAnalysis.Text += "(登陆后最高清)";
				btnAnalysis.ForeColor = Color.Red;
			}
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (!"".Equals(HttpUtil.cookie))
			{
				logOnControll();
			}
			linkSoftSavePath.Text = Environment.CurrentDirectory;
			linkVideoSavePath.Text = EntityConfig.downPath;
		}

		private void tomp3(string mp4Path)
		{
			if (!File.Exists(mp4Path))
			{
				MessageBox.Show("找不到对应的视频文件,请确认是否存在文件:" + mp4Path);
				return;
			}
			string text = mp4Path.Replace(".flv", ".mp3").Replace(".mp4", ".mp3");
			FileUtil.executeCmd(Environment.CurrentDirectory + "\\ffmpeg.exe -i " + mp4Path + " -b:a 192k -acodec mp3 -ar 44100 -ac 2 " + text);
			Process.Start(Path.GetDirectoryName(mp4Path));
		}

		private void toolStripStatusLabel2_Click_1(object sender, EventArgs e)
		{
			Process.Start("https://shang.qq.com/wpa/qunwpa?idkey=9605d2612964b2b1f2010cf170b34c181399658fa4e28c49918f2494764e4f86");
		}

		private void 登录B站账号ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new QrLogin().ShowDialog();
		}

		private void 常见问题ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.ibilibili.com/wenti.php");
		}

		private void btnClearUrl_Click(object sender, EventArgs e)
		{
			txtUrl.Text = "";
		}

		private void mnuClearAll_Click(object sender, EventArgs e)
		{
			DownVideos = new List<PageVideo>();
			gridDowntable.BeginInvoke(SetMyDatagridBind, DownVideos);
		}

		private void mnuRemoveOne_Click(object sender, EventArgs e)
		{
			if (DownVideos.Count > gridRowIndex)
			{
				DownVideos.RemoveAt(gridRowIndex);
			}
			gridDowntable.BeginInvoke(SetMyDatagridBind, DownVideos);
		}

		private void mnuRedown_Click(object sender, EventArgs e)
		{
			if (DownVideos.Count > gridRowIndex)
			{
				DownVideos[gridRowIndex].DownType = TypeDown.等待下载;
			}
			gridDowntable.BeginInvoke(SetMyDatagridBind, DownVideos);
		}

		private void 转mp3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string mp4Path = DownVideos[gridRowIndex].SavePath;
			tomp3(mp4Path);
		}

		private void linkSoftSavePath_Click(object sender, EventArgs e)
		{
			Process.Start(linkSoftSavePath.Text);
		}

		private void linkVideoSavePath_Click(object sender, EventArgs e)
		{
			Process.Start(linkVideoSavePath.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Console.WriteLine(BiliUtil.getAccountInfo().code);
		}

		private void btnShowImg_Click(object sender, EventArgs e)
		{
			if (txtUrl.Text.StartsWith("https://www.bilibili.com/video/av"))
			{
				Process.Start(txtUrl.Text.Replace(".bilibili.com", ".ibilibili.com"));
			}
			else
			{
				MessageBox.Show("只支持获取普通视频的图片信息");
			}
		}

		private void toolStripPhoneBarcode_Click(object sender, EventArgs e)
		{
			frmBarCode form = new frmBarCode();
			form.barcodeContent = "http://192.168.0.108/?getfile=0";
			form.ShowDialog();
		}

		private void 要你帅3000工具箱ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start("http://www.bili123.com");
		}
	}
}
