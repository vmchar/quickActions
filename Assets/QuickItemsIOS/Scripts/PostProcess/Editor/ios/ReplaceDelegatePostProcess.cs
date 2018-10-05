using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace QuickActionsiOS
{
	/// <summary>
	/// Replace default Unity3d generated xCode project AppDelegate.
	/// The main goal is to copy standart AooDelegate from Unity3d
	/// generated xCode project and modify it for your needs.
	/// This may be required if you can't use IMPL_APP_CONTROLLER_SUBCLASS(ClassName).
	/// Using this macro have a strong restriction - only 1 class can use it.
	/// If you have 2 implementations - the second one will be ignored
	/// ---
	/// Author: Vladislav Chartanovich. vmchar@oulook.com.
	/// Date: 6 august 2018
	/// </summary>
	public class ReplaceDelegatePostProcess : ScriptableObject
	{
		/// <summary>
		/// Put your custom delegate file here via inspector
		/// </summary>
		public DefaultAsset NewDelegateFile;

		private const string DefaultDelegateName = "UnityAppController.mm";

		[PostProcessBuild(999)]
		public static void OnPostProcess(BuildTarget buildTarget, string buildPath)
		{
			if(buildTarget != BuildTarget.iOS) return;

			//creating instance of scriptable object to get file path
			var instance = ScriptableObject.CreateInstance<ReplaceDelegatePostProcess>();
			var delegateFile = instance.NewDelegateFile;
			DestroyImmediate(instance);
			if(delegateFile == null) return;

			//get path to xCode project and project itself
			var projectPath = PBXProject.GetPBXProjectPath(buildPath);
			var xCodeProject = new PBXProject();
			xCodeProject.ReadFromFile(projectPath);
			
			//get paths to new and old delegate
			var newDelegatePath = AssetDatabase.GetAssetPath(delegateFile);
			var delegatePath = buildPath + "/Classes/";
			var oldDelegatePath = delegatePath + DefaultDelegateName;
			
			//remove old delegate, add new one with default unity name
			FileUtil.DeleteFileOrDirectory(oldDelegatePath);
			FileUtil.CopyFileOrDirectory(newDelegatePath, delegatePath + DefaultDelegateName);

			//save changes to xCode project
//			xCodeProject.AddFile("/Classes/" + DefaultDelegateName, DefaultDelegateName);
			xCodeProject.WriteToFile(projectPath);
		}
	}
}