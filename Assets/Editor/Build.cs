// C# example.
using UnityEditor;
using System.Diagnostics;
using System.IO;
using System;

public class Build {
	public static void BuildGame() {
		string[] args = Environment.GetCommandLineArgs();
		string path = "";
		for(int i = 0; i < args.Length; i++) {
			if(args[i].Equals("Build.BuildGame")) {
				path = args[i + 1];
				break;
			}
		}
		if(!path.EndsWith("/")) {
			path += "/";
		}
		UnityEngine.Debug.Log("PATH: "  + path);
		string[] levels = new string[] { "Assets/Scene/scene.unity" };
		FileUtil.DeleteFileOrDirectory(path + "Android/");
		Directory.CreateDirectory(path + "Android/");
		FileUtil.DeleteFileOrDirectory(path + "Win64/");
		Directory.CreateDirectory(path + "Win64/");
		BuildPipeline.BuildPlayer(levels, path + "Win64/DGE_win64.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
		BuildPipeline.BuildPlayer(levels, path + "Android/DGE_android.apk", BuildTarget.Android, BuildOptions.None);
	}
}