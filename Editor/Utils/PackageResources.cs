

using UnityEngine;

namespace Slantar.Architecture.UnityEditor
{
	public static class PackageResources
	{
		public const string EDITOR_PATH = "Editor/Slantar/Architecture/";

		public static T EditorLoad<T>(string resourcePath) where T : Object => Resources.Load<T>(EDITOR_PATH + resourcePath);
	}
}