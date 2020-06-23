/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.DataGridViewProgress
 *文件名：  DataGridViewProgressCell
 *版本号：  V1.0.0.0
 *唯一标识：cb7569b9-c6f5-4d64-9a32-5650905e8bb9
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:29:08
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:29:08
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilibiliDown.Controls
{
	internal class DataGridViewProgressCell : DataGridViewImageCell
	{
		private static Image emptyImage;

		static DataGridViewProgressCell()
		{
			emptyImage = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
		}

		public DataGridViewProgressCell()
		{
			ValueType = typeof(int);
		}

		protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
		{
			return emptyImage;
		}

		protected override void Paint(Graphics g, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			int num = (value != null) ? Convert.ToInt32(value) : 0;
			float num2 = (float)num / 100f;
			new SolidBrush(cellStyle.BackColor);
			Brush brush = new SolidBrush(cellStyle.ForeColor);
			base.Paint(g, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);
			if ((double)num2 > 0.0 || (double)num2 - 0.0 < 1.4012984643248171E-45)
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(163, 189, 242)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32(num2 * (float)cellBounds.Width - 4f), cellBounds.Height - 4);
				g.DrawString(num + "%", cellStyle.Font, brush, cellBounds.X + 6, cellBounds.Y + 2);
			}
			else if (base.DataGridView.CurrentRow.Index == rowIndex)
			{
				g.DrawString(num + "%", cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
			}
			else
			{
				g.DrawString(num + "%", cellStyle.Font, brush, cellBounds.X + 6, cellBounds.Y + 2);
			}
		}
	}
}
