// C# example.
using UnityEditor;
using System.Diagnostics;
using System.IO;

public class Build {
	[MenuItem("Build/Build")]
	public static void BuildGame ()
	{
		string[] levels = new string[] {"Assets/Scene/scene.unity"};
		FileUtil.DeleteFileOrDirectory("E:/Programmieren/Projekte/DGEUnity/AutoBuild/Android/");
		Directory.CreateDirectory("E:/Programmieren/Projekte/DGEUnity/AutoBuild/Android/");
		FileUtil.DeleteFileOrDirectory("E:/Programmieren/Projekte/DGEUnity/AutoBuild/Win64/");
		Directory.CreateDirectory("E:/Programmieren/Projekte/DGEUnity/AutoBuild/Win64/");
		BuildPipeline.BuildPlayer(levels, "E:/Programmieren/Projekte/DGEUnity/AutoBuild/Android/DGE_android.apk", BuildTarget.Android, BuildOptions.None);
		BuildPipeline.BuildPlayer(levels, "E:/Programmieren/Projekte/DGEUnity/AutoBuild/Win64/DGE_win64.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
	}
}