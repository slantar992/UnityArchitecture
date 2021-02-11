
namespace Slantar.Architecture.UnityEditor
{
	public static class UnityBootstrapperImportResources
	{

		public static string UnityBootstrapperCode =>
			"using UnityEngine;\n" +
			"\n" +
			"namespace Slantar.Architecture\n" +
			"{\n" +
			"	internal static class UnityBootstrapper\n" +
			"	{\n" +
			"		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]\n" +
			"		public static void Bootstrapp()\n" +
			"		{\n" +
			"			Debug.Log(\"Bootstrap!\");\n" +
			"		}\n" +
			"	}\n" +
			"}\n";

		public static string Asmref =
		"{\n" +
		"	\"reference\": \"Slantar.Architecture\"\n" +
		"}\n";
	}
}


