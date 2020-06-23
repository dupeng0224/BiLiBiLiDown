/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.SubForms
 *文件名：  GetOpenId
 *版本号：  V1.0.0.0
 *唯一标识：4762394c-c0cd-40f6-93ee-c6a62880ddae
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:36:21
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:36:21
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using BilibiliDown.Common;
using BilibiliDown.Pojo;
using BilibiliDown.Util;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace BilibiliDown.SubForms
{
	public partial class GetOpenId : Form
    {
		private string mac = Guid.NewGuid().ToString("N");

		private static int count;

		public GetOpenId()
		{
			InitializeComponent();
			count = 0;
		}

		private void GetOpenId_Load(object sender, EventArgs e)
		{
			pictureBox1.Image = Image.FromStream(WebRequest.Create("http://www.acgres.com/weixin/login_qr_code_4winform/mac-" + mac).GetResponse().GetResponseStream());
			timerGetOpenId.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (count++ >= 60)
			{
				timerGetOpenId.Stop();
				MessageBox.Show("因为您60秒没有扫码,界面关闭");
				Close();
			}
			string text = HttpUtil.HttpGet("http://www.acgres.com/bilidown/ajax/get_openid/mac-" + mac, null, null);
			Console.WriteLine(text + " - http://www.acgres.com/bilidown/ajax/get_openid/mac-" + mac);
			if (text == null || "".Equals(text))
			{
				return;
			}
			timerGetOpenId.Stop();
			MessagePack messagePack = JsonConvert.DeserializeObject<MessagePack>(text);
			string status = messagePack.status;
			if (!(status == "nodata"))
			{
				if (status == "fobidden")
				{
					MessageBox.Show("没有守护契约,你已失去了使用该道具的资格");
					Hide();
					Environment.Exit(0);
					return;
				}
				string text2 = messagePack.unionid;
				if (text2 == null || text2 == "" || "".Equals(text2.Trim()))
				{
					text2 = messagePack.openid;
				}
				FileUtil.writeOpenId(text2);
				MessageBox.Show("证书cert.mwx已经在软件根目录下生成，可以关闭扫码窗进行解析了。");
				if (base.Parent != null)
				{
					((Subscribe)base.Parent).Close();
				}
				Close();
			}
			else
			{
				MessageBox.Show("您没有关注公众号");
				Close();
			}
		}
	}
}
