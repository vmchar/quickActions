using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace QuickActionsiOS
{
	/// <summary>
	/// Copy list of images from Unity project to xCode project
	/// but aviod coding them into unity's binary format and
	/// copy them as is.
	/// ---
	/// Author: Vladislav Chartanovich. vmchar@outlook.com
	/// Date: 2 october 2018
	/// </summary>
	public class QuickActionsIconsPostProcess : ScriptableObject
	{
		/// <summary>
		/// List of images you want to copy from Unity project
		/// to xCode project.
		/// </summary>
		[SerializeField]
		public DefaultAsset ImageFolder;

		[PostProcessBuild(998)]
		public static void OnPostProcess(BuildTarget buildTarget, string buildPath)
		{
			if(buildTarget != BuildTarget.iOS) return;
			
			//creating instance of scriptable object to get file path
			var instance = CreateInstance<QuickActionsIconsPostProcess>();
			var iconSet = instance.ImageFolder;
			DestroyImmediate(instance);
			if (iconSet == null) return;
			//get all files in given directory
			var filesInDirectory = Directory.GetFiles(  AssetDatabase.GetAssetPath(iconSet),
														"*.png", 
														SearchOption.TopDirectoryOnly);
		
			//get all needed paths
			var projectPath = PBXProject.GetPBXProjectPath(buildPath);
			var xCodeProject = new PBXProject();
			xCodeProject.ReadFromFile(projectPath);
			var targetName = PBXProject.GetUnityTargetName();
			var targetGUID = xCodeProject.TargetGuidByName(targetName);
			var destinationPath = buildPath + "/";

			//copy each file in directory to xCode project
			foreach (var file in filesInDirectory)
			{
				var nameAndExtension = file.Split('/').LastOrDefault();
				var assetLocation = AssetDatabase.GetAssetPath(iconSet) + "/" + nameAndExtension;
				var assetDestination = destinationPath + nameAndExtension;
				FileUtil.CopyFileOrDirectory(assetLocation, assetDestination);

				var grGUID = xCodeProject.AddFolderReference(destinationPath + nameAndExtension, "");
				xCodeProject.AddFileToBuild(targetGUID, grGUID);
			}
			xCodeProject.WriteToFile(projectPath);
		}
	}
}