/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.SubForms
 *文件名：  Subscribe
 *版本号：  V1.0.0.0
 *唯一标识：1360402e-ebdb-40a6-b0cf-30874a456805
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:39:49
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:39:49
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using BilibiliDown.Common;
using BilibiliDown.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliDown.SubForms
{
    public partial class Subscribe : Form
    {
        public Subscribe()
        {
            InitializeComponent();
        }

        private void Subscribe_Load(object sender, EventArgs e)
        {
            string mac = ManagementSystemInfo.getMac();
            mac = mac.Replace(":", "");
            string requestUriString = HttpUtil.HttpGet("http://www.acgres.com/qrcode/ajax/create/?mac=" + mac, null, null);
            Console.WriteLine("http://www.acgres.com/qrcode/ajax/create/?mac=" + mac);
            pictureBox1.Image = Image.FromStream(WebRequest.Create(requestUriString).GetResponse().GetResponseStream());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new GetOpenId().ShowDialog();
        }
    }
}
