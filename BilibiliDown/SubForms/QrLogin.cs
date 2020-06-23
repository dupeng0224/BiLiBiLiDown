/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.SubForms
 *文件名：  QrLogin
 *版本号：  V1.0.0.0
 *唯一标识：e901618b-7e90-4e4e-bc2e-f5cf27823035
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:37:49
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:37:49
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using BilibiliDown.Common;
using BilibiliDown.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace BilibiliDown.SubForms
{
    public partial class QrLogin : Form
    {
		private string oauthKey = "";

		public object HttpUtility
		{
			get;
			private set;
		}

		public QrLogin()
		{
			InitializeComponent();
		}

		private void QrLogin_Load(object sender, EventArgs e)
		{
			JObject jObject = JObject.Parse(HttpUtil.HttpGet("https://passport.bilibili.com/qrcode/getLoginUrl", null, null));
			if (int.Parse(jObject["code"].ToString()) == 0)
			{
				string text = jObject["data"]["url"].ToString();
				oauthKey = jObject["data"]["oauthKey"].ToString();
				Console.WriteLine(text);
				BarcodeWriter obj = new BarcodeWriter
				{
					Format = BarcodeFormat.QR_CODE
				};
				QrCodeEncodingOptions qrCodeEncodingOptions = (QrCodeEncodingOptions)(obj.Options = new QrCodeEncodingOptions
				{
					DisableECI = true,
					CharacterSet = "UTF-8",
					Width = pictureBox1.Width,
					Height = pictureBox1.Height,
					Margin = 1
				});
				Bitmap image = obj.Write(text);
				pictureBox1.Image = image;
				timer1.Start();
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			string postDataStr = "oauthKey=" + oauthKey + "&gourl=https://www.bilibili.com/";
			JObject jObject = JObject.Parse(HttpUtil.HttpPost("https://passport.bilibili.com/qrcode/getLoginInfo", postDataStr));
			if (!bool.Parse(jObject["status"].ToString()))
			{
				return;
			}
			string text = jObject["data"]["url"].ToString();
			Console.WriteLine(text);
			string[] array = text.Split('&');
			foreach (string text2 in array)
			{
				Console.WriteLine(text2);
				string[] array2 = text2.Split('=');
				if ("SESSDATA".Equals(array2[0]))
				{
					Console.WriteLine("SESSDATA = " + array2[1]);
					HttpUtil.cookie = text2;
					HttpHelper.cookie = text2;
					XMLUtil.saveConfig(XMLUtil.SESSION_DATA, text2);
					MessageBox.Show("您已登陆成功，可以下载登陆后能看到的最高清");
					timer1.Stop();
					Close();
				}
			}
		}
	}
}
