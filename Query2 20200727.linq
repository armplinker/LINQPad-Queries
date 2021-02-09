<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

ReadOnlyCollection<string> hierarchicalSubDocTypes = new ReadOnlyCollection<string>(new string[] { "1101", "1102", "1199", "1301", "1302", "1399", "1401", "1402", "1403", "1499", "1601", "1602", "1603", "1604", "1605", "1699", "1801", "1802", "1899" });
// 
//var subDocTypes = new string[] { "1101", "1102", "1199", "1301", "1302", "1399", "1401", "1402", "1403", "1499", "1601", "1602", "1603", "1604", "1605", "1699", "1801", "1802", "1899" };
var qry = from t in hierarchicalSubDocTypes
		  where t.StartsWith("14") == true
		  orderby t
		  select t.ToString();

qry.Dump();

string ChangeOriginalFileName(string fileName)
{
	Console.WriteLine($"Original fileName: {fileName}");
	//Debug.WriteLine($"Original fileName: {fileName}");



	
	
	if (fileName.EndsWith(".tmp"))
		fileName = fileName.Replace(".tmp", "");
	fileName = fileName.Insert(0, "CHANGED_TO_");
	var ext = Path.GetExtension(fileName).TrimStart('.').Trim();
	var isImageFile = (new string[] { "gif", "bmp", "jpg", "jpeg", "tif", "tiff", "png" }).Any(ext.ToLower().Contains);
	ext.Dump();
	isImageFile.Dump();
	fileName =  $"{Path.GetFileNameWithoutExtension(fileName).Trim()}_{Guid.NewGuid().ToString()}" + $".{ext}";
	Console.WriteLine($"New SaveAs fileName: {fileName}");
	//Debug.WriteLine($"New SaveAs fileName: {fileName}");
	//throw new Exception($"New SaveAs fileName: {fileName}");
	return fileName;
}


var fileNameX = ChangeOriginalFileName("1595802498030Eaglesmere_Borough_Zoning_Map.pdf.tmp");

 

fileNameX.Dump();