/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown
 *文件名：  frmCert
 *版本号：  V1.0.0.0
 *唯一标识：a953e3e1-a8c3-46f5-afe7-ad3d7eae555d
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:41:34
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:41:34
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using BilibiliDown.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BilibiliDown
{
    public partial class frmCert : Form
    {
		public frmCert()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			EntityConfig.certWorld = txtCertContent.Text.Trim();
			XmlDocument xmlDocument = new XmlDocument();
			if (File.Exists(EntityConfig.configPath))
			{
				xmlDocument.Load(EntityConfig.configPath);
				XmlNode firstChild = xmlDocument.FirstChild;
				XmlNode xmlNode = firstChild.SelectSingleNode("CERTWORLD");
				if (xmlNode == null)
				{
					XmlElement xmlElement = xmlDocument.CreateElement("CERTWORLD");
					xmlElement.InnerText = EntityConfig.certWorld;
					firstChild.AppendChild(xmlElement);
				}
				else
				{
					xmlNode.InnerText = EntityConfig.certWorld;
				}
				File.Delete(EntityConfig.configPath);
			}
			else
			{
				XmlElement xmlElement2 = xmlDocument.CreateElement("ROOT");
				xmlDocument.AppendChild(xmlElement2);
				XmlElement xmlElement3 = xmlDocument.CreateElement("CERTWORLD");
				xmlElement3.InnerText = EntityConfig.certWorld;
				xmlElement2.AppendChild(xmlElement3);
			}
			if (string.IsNullOrWhiteSpace(EntityConfig.certWorld))
			{
				if (File.Exists(EntityConfig.certPath))
				{
					File.Delete(EntityConfig.certPath);
				}
			}
			else
			{
				StreamWriter streamWriter = new FileInfo(EntityConfig.certPath).CreateText();
				streamWriter.WriteLine(EntityConfig.certWorld);
				streamWriter.Close();
			}
			xmlDocument.Save(EntityConfig.configPath);
			MessageBox.Show("保存成功");
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmCert_Load(object sender, EventArgs e)
		{
			txtCertContent.Text = EntityConfig.certWorld;
		}
	}
}
