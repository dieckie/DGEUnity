// C# example.
using UnityEditor;
using System.Diagnostics;
using System.IO;
using System;

public class Build {
	public static void BuildGame() {
		string[] args = Environment.GetCommandLineArgs();
		string path = "";
		bool own = false;
		bool android = false;
		bool windows64 = false;
		bool windows32 = false;
		bool linux = false;
		bool mac = false;
		bool web = false;
		for(int i = 0; i < args.Length; i++) {
			if(args[i].Equals("Build.BuildGame")) {
				path = args[i + 1];
				own = true;
			}
			if(own && args[i].StartsWith("-")) {
				own = false;
				break;
			}
			if(own) {
				switch(args[i].ToLower()) {
				case "android":
					android = true;
					break;
				case "win64":
					windows64 = true;
					break;
				case "win32":
					windows32 = true;
					break;
				case "linux":
					linux = true;
					break;
				case "mac":
					mac = true;
					break;
				case "web":
					web = true;
					break;
				}
			}
		}
		if(!path.EndsWith("/")) {
			path += "/";
		}
		UnityEngine.Debug.Log("PATH: " + path);
		string[] levels = new string[] { "Assets/Scene/scene.unity" };
		if(windows64) {
			FileUtil.DeleteFileOrDirectory(path + "Win64/");
			Directory.CreateDirectory(path + "Win64/");
			BuildPipeline.BuildPlayer(levels, path + "Win64/DGE_win64.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
			//executeCommand("cd /d " + path + "Win64/ & ../7za a DGE_win64.zip DGE* & del *.exe & rd /S /Q DGE_win64_Data");
		}
		if(windows32) {
			FileUtil.DeleteFileOrDirectory(path + "Win32/");
			Directory.CreateDirectory(path + "Win32/");
			BuildPipeline.BuildPlayer(levels, path + "Win32/DGE_win32.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

		}
		if(android) {
			FileUtil.DeleteFileOrDirectory(path + "Android/");
			Directory.CreateDirectory(path + "Android/");
			BuildPipeline.BuildPlayer(levels, path + "Android/DGE_android.apk", BuildTarget.Android, BuildOptions.None);
		}
		if(linux) {
			FileUtil.DeleteFileOrDirectory(path + "Linux/");
			Directory.CreateDirectory(path + "Linux/");
			BuildPipeline.BuildPlayer(levels, path + "Linux/DGE_linux.x86", BuildTarget.StandaloneLinuxUniversal, BuildOptions.None);
		}
		if(mac) {
			FileUtil.DeleteFileOrDirectory(path + "Mac/");
			Directory.CreateDirectory(path + "Mac/");
			BuildPipeline.BuildPlayer(levels, path + "Mac/DGE_mac.app", BuildTarget.StandaloneOSXUniversal, BuildOptions.None);
		}
		if(web) {
			FileUtil.DeleteFileOrDirectory(path + "Web/");
			Directory.CreateDirectory(path + "Web/");
			BuildPipeline.BuildPlayer(levels, path + "Web/", BuildTarget.WebGL, BuildOptions.None);
		}
	}

	public static void executeCommand(String command) {
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
		startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		startInfo.FileName = "cmd.exe";
		startInfo.Arguments = "/C " + command;
		process.StartInfo = startInfo;
		process.Start();
	}
}