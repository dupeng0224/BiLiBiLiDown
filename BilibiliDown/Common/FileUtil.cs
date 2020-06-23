using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BilibiliDown.Common
{
	public class FileUtil
	{
		private static object lockobj = new object();

		private static string openIdFile = Environment.CurrentDirectory + "\\cert.mwx";

		public static void deleteTmpFord(string tmp)
		{
			tmp = tmp.Replace("/", "\\");
			executeCmd("rd /s /q " + tmp);
		}

		public static void mergeNomalVideo(string tempPath, string videoPath, long totalThreadCount)
		{
			string text = "ffmpeg -i \"concat:";
			for (int i = 1; i <= totalThreadCount; i++)
			{
				text = text + tempPath + "input" + i + ".ts|";
			}
			if (text.EndsWith("|"))
			{
				text = text.Substring(0, text.Length - 1);
			}
			text = text + " \" -c copy -bsf:a aac_adtstoasc -movflags +faststart  " + videoPath;
			Console.WriteLine("lastCmd:" + text);
			executeFFMpegCommand(text);
		}

		public static string GetExtension(string v)
		{
			string text = Path.GetExtension(v);
			if (text.IndexOf("?") != -1)
			{
				text = text.Substring(0, text.IndexOf("?"));
			}
			return text;
		}

		public static void executeCmd(string Command)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			Console.WriteLine("cmd shell:" + Command);
			process.StandardInput.WriteLine(Command + "&exit");
			process.StandardInput.AutoFlush = true;
			process.StandardInput.Close();
			Console.WriteLine(process.StandardOutput.ReadToEnd());
			process.WaitForExit();
			process.Close();
		}

		public static void writeOpenId(string openid)
		{
			StreamWriter streamWriter = new FileInfo(openIdFile).CreateText();
			streamWriter.WriteLine(openid);
			streamWriter.Close();
		}

		public static string checkOpenId()
		{
			if (!File.Exists(openIdFile))
			{
				return "";
			}
			return File.ReadAllText(openIdFile, Encoding.UTF8);
		}

		public static void openFord(string fordPath)
		{
			if (Directory.Exists(fordPath))
			{
				fordPath = fordPath.Replace("/", "\\");
				executeCmd("explorer " + fordPath);
			}
		}

		public static string mergeVideoAndAudio(string videoPath, string audioPath, string cid, string outPath)
		{
			string text = "";
			string text2 = "";
			if (audioPath != null && !"".Equals(audioPath))
			{
				text = " -i " + audioPath;
				text2 = "   -c:a copy ";
			}
			executeCmd(Environment.CurrentDirectory + "\\ffmpeg.exe -i " + videoPath + text + " -c:v copy  " + text2 + outPath);
			return "转换成功,文件保存路径:" + outPath;
		}

		public static void executeFFMpegCommand(string cmd)
		{
			string str = Environment.CurrentDirectory + "\\ffmpeg.exe";
			cmd = cmd.Replace("ffmpeg ", str + " ");
			cmd = cmd.Replace("\t", "");
			Console.WriteLine("cmd:" + cmd);
			executeCmd(cmd);
		}
	}
}
