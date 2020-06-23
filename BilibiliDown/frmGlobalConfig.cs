/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown
 *文件名：  frmGlobalConfig
 *版本号：  V1.0.0.0
 *唯一标识：2234b7c5-4e60-4763-9731-1a82dcaeb625
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:43:13
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:43:13
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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BilibiliDown
{
    public partial class frmGlobalConfig : Form
    {
		public delegate void deleLinlabSavePath(string path);

		private deleLinlabSavePath setMyLinlabSavePath;

		public frmGlobalConfig()
		{
			InitializeComponent();
		}

		public void setLinlabSavePath(string path)
		{
			linlabSavePath.Text = path;
		}

		private void GlobalConfig_Load(object sender, EventArgs e)
		{
			setMyLinlabSavePath = setLinlabSavePath;
			linlabSavePath.Text = EntityConfig.downPath;
		}

		private void linlabSavePath_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread((ParameterizedThreadStart)delegate
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
				{
					Description = "请选择文件路径"
				};
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					linlabSavePath.BeginInvoke(setMyLinlabSavePath, selectedPath);
				}
			});
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = true;
			thread.Start();
		}

		private void labPathDisplayname_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread((ParameterizedThreadStart)delegate
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
				{
					Description = "请选择文件路径"
				};
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					string selectedPath = folderBrowserDialog.SelectedPath;
					linlabSavePath.BeginInvoke(setMyLinlabSavePath, selectedPath);
				}
			});
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = true;
			thread.Start();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			EntityConfig.downPath = linlabSavePath.Text;
			XmlDocument xmlDocument = new XmlDocument();
			string downPath = EntityConfig.downPath;
			if (new Regex("[\\u4e00-\\u9fa5]").IsMatch(downPath) || downPath.IndexOf(" ") != -1)
			{
				MessageBox.Show("视频保存路径不可以存在中文或空格,否则容易出现格式转换失败,当前路径:" + downPath);
				EntityConfig.downPath = AppDomain.CurrentDomain.BaseDirectory + "\\Download\\";
				return;
			}
			if (File.Exists(EntityConfig.configPath))
			{
				xmlDocument.Load(EntityConfig.configPath);
				XmlNode firstChild = xmlDocument.FirstChild;
				XmlNode xmlNode = firstChild.SelectSingleNode("DOWNPATH");
				if (xmlNode == null)
				{
					XmlElement xmlElement = xmlDocument.CreateElement("DOWNPATH");
					xmlElement.InnerText = EntityConfig.downPath;
					firstChild.AppendChild(xmlElement);
				}
				else
				{
					xmlNode.InnerText = EntityConfig.downPath;
				}
				File.Delete(EntityConfig.configPath);
			}
			else
			{
				XmlElement xmlElement2 = xmlDocument.CreateElement("ROOT");
				xmlDocument.AppendChild(xmlElement2);
				XmlElement xmlElement3 = xmlDocument.CreateElement("DOWNPATH");
				xmlElement3.InnerText = EntityConfig.downPath;
				xmlElement2.AppendChild(xmlElement3);
			}
			xmlDocument.Save(EntityConfig.configPath);
			MessageBox.Show("保存成功");
			Close();
		}
	}
}
