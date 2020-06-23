/************************************************************************************
 * Copyright (c) 2020 北京大象科技有限公司 All Rights Reserved.
 * CLR版本：4.0.30319.42000
 *公司名称：北京大象科技有限公司
 *命名空间：BilibiliDown.Pojo
 *文件名：  MessagePack
 *版本号：  V1.0.0.0
 *唯一标识：786843c6-8d30-4a92-9f32-808c393b9778
 *创建人：  杜鹏
 *电子邮箱：dupeng@bjdaxiang.cn
 *QQ:       4909004
 *创建时间：2020/3/26 17:35:36
 *描述：    
 *
 *=====================================================================
 *修改标记
 *修改时间：2020/3/26 17:35:36
 *修改人：  杜鹏
 *版本号：  V1.0.0.0
 *描述：
/************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilibiliDown.Pojo
{
	internal class MessagePack
	{
		public int code
		{
			get;
			set;
		}

		public string message
		{
			get;
			set;
		}

		public string status
		{
			get;
			set;
		}

		public string openid
		{
			get;
			set;
		}

		public string unionid
		{
			get;
			set;
		}
	}
}
