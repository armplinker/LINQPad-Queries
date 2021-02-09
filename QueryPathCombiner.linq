<Query Kind="Program">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

void Main()
{

	//string testPath = "D:\\git\\BIS9\\src\\SupportDocuments\\ExstPlans\\";
	string testPath = "\\\\MACHINENAME\\FOO\\git\\BIS9\\src\\SupportDocuments\\ExstPlans\\";
	testPath.Dump();
	

	Path.Combine(testPath).Dump();
	Path.Combine(testPath.Replace("\\", "/")).Dump();

	var testPath2 = testPath.Replace("\\", "/");
	testPath2.Dump($"TestPath2: {testPath2}");
	string comboPath = Path.Combine(testPath2, "/subdir/other/depth", "Example showing css working properly_[60022].pdf");

	comboPath.Dump($"1: path1 has ROOT: {comboPath} - ignores path1");

	comboPath = PathCombiner.Combine(testPath2, "/subdir/other/depth", "Example showing css working properly_[60022].pdf");
	comboPath.Dump($"2: combiner: {comboPath}");

	comboPath = PathCombiner.Combine(testPath, "/subdir/other/depth", "Example showing css working properly_[60022].pdf");
	comboPath.Dump($"3: combiner result: {comboPath}");

	//string testPath = "D:\\git\\BIS9\\src\\SupportDocuments\\ExstPlans\\";
	 testPath = "D/git/BIS9/src/SupportDocuments/ExstPlans/";
	testPath.Dump();
	comboPath =	PathCombiner.Combine(testPath, "/subdir/other/depth", "Example showing css working properly_[60022].pdf");
	comboPath.Dump($"4 combiner result: {comboPath}");


	testPath = "/D/git/BIS9/src/SupportDocuments/ExstPlans/";
	Console.WriteLine($"Directory: {testPath}");
	Console.WriteLine($"GetPathRoot: {Path.GetPathRoot(testPath)}");
	
	testPath.Dump();
	comboPath = PathCombiner.Combine(testPath, "/subdir/other/depth", "Example showing css working properly_[60022].pdf");
	comboPath.Dump($"5 combiner result (absolute path): {comboPath}");
}

private static class PathCombiner
{
	public static string Combine(string path1, string path2, params string[] pathn)
	{
		Console.WriteLine($"PATH1 with root: {path1}");
		string root = Path.GetPathRoot(path1); // what does it start with?
		Console.WriteLine($"ROOT from GetPathRoot: {root ?? "No root"}");

		if (!string.IsNullOrEmpty(root))
		{
			path1 = path1.Replace(root, "");
			Console.WriteLine($"path1 cleaned up: {path1 ?? "No root"}");
		}
		if (path1 == null)
			return path2; // which is what built-in Combine normally does too.
		if (path2 == null)
			return path1; // which is what built-in Combine normally does too.

		 

		path1 = StripSeparators(path1);
		path2 = StripSeparators(path2);

		string path = Path.Combine(path1, path2);

		for (int i = 0; i < pathn.Length; i++)
			path = Path.Combine(path, pathn[i].TrimStart(System.IO.Path.DirectorySeparatorChar));

		return (!string.IsNullOrEmpty(root)) ? root + (root.Contains("\\") ? System.IO.Path.DirectorySeparatorChar : System.IO.Path.AltDirectorySeparatorChar ) + path : path;
	}

	public static string StripSeparators(string path)
	{
		while (path.StartsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ||
			   path.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) ||
			   path.StartsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()) ||
			   path.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()))
		{
			path = path.TrimStart(System.IO.Path.DirectorySeparatorChar).TrimEnd(System.IO.Path.AltDirectorySeparatorChar).TrimStart(System.IO.Path.AltDirectorySeparatorChar).TrimEnd(System.IO.Path.DirectorySeparatorChar);
			if (path == String.Empty)
			{
				
				break;
			}			
		}
		return path;
	}
}