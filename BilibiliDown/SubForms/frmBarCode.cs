/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.SubForms
 *文件名：  frmBarCode
 *版本号：  V1.0.0.0
 *唯一标识：cfc8a3c3-a8ae-4445-b34c-14d2cac3226e
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:47:43
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:47:43
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

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
    public partial class frmBarCode : Form
    {
        public string barcodeContent
        {
            get;
            set;
        }

        public frmBarCode()
        {
            InitializeComponent();
        }

        private void frmBarCode_Load(object sender, EventArgs e)
        {
            lblIp.Text = barcodeContent;
            if (!string.IsNullOrWhiteSpace(barcodeContent))
            {
                BarcodeWriter obj = new BarcodeWriter
                {
                    Format = BarcodeFormat.QR_CODE
                };
                QrCodeEncodingOptions qrCodeEncodingOptions = (QrCodeEncodingOptions)(obj.Options = new QrCodeEncodingOptions
                {
                    DisableECI = true,
                    CharacterSet = "UTF-8",
                    Width = picboxQrCode.Width,
                    Height = picboxQrCode.Height,
                    Margin = 1
                });
                Bitmap image = obj.Write(barcodeContent);
                picboxQrCode.Image = image;
            }
        }
    }
}
