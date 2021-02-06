
using System.IO;
using UnityEngine;
using UnityEditor;

namespace Slantar.Architecture.UnityEditor
{
    public static class MenuItems
    {
        [MenuItem("Tools/Slantar/Architecture/Import Bootstrapper Code")]
        public static void ImportBootstrapper()
        {
            var sourceDestinationPath = Application.dataPath + "/Scripts/Architecture/";
            var sourceName = "Bootstrapper.cs";
            var asmrefName = "Bootstrapper.asmref";

            CreateDirectoryIfExist(sourceDestinationPath);
            File.WriteAllText(sourceDestinationPath + sourceName, UnityBootstrapperImportResources.UnityBootstrapperCode);
            File.WriteAllText(sourceDestinationPath + asmrefName, UnityBootstrapperImportResources.Asmref);
            AssetDatabase.Refresh();
        }

		private static void CreateDirectoryIfExist(string path)
		{
			if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
		}
	}
}
