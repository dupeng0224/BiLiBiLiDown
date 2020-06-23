using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.RegularExpressions;

namespace BilibiliDown.Util
{
	internal class StringUtil
	{
		public static string ToJson(object obj)
		{
			IsoDateTimeConverter isoDateTimeConverter = new IsoDateTimeConverter();
			isoDateTimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
			return JsonConvert.SerializeObject(obj, isoDateTimeConverter);
		}

		public static string removeIllegalCharForFileName(string fileName)
		{
			return RemoveAllChineseAndSymbol(fileName);
		}

		public static string RemoveAllChineseAndSymbol(string str)
		{
			string[] array = "| ~ ! @ # $ % ^ “ ” < > & * ( ) + : ~ ！ @ # ￥ % … & * （ ） —— + ” { [ } ] 【 】 , ， - 。 / \\".Split(' ');
			foreach (string text in array)
			{
				Console.WriteLine(text);
				str = str.Replace(text, "");
			}
			str = str.Replace(" ", "_");
			str = str.Replace("\\s", "_");
			return str;
		}

		public static string RemoveAllChineseAndSymbol2(string str)
		{
			string result = Regex.Replace(Regex.Replace(str, "([\\p{P}*])", " "), "([\\u4e00-\\u9fa5])", "");
			str = str.Replace(" ", "");
			return result;
		}

		public string ToDBC(string input)
		{
			char[] array = input.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == '\u3000')
				{
					array[i] = ' ';
				}
				else if (array[i] > '\uff00' && array[i] < '｟')
				{
					array[i] = (char)(array[i] - 65248);
				}
			}
			return new string(array);
		}
	}
}
