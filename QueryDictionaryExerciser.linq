<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

string makeToken(string inVar)
{
	return inVar.Replace(" ",string.Empty).Replace("\"",string.Empty).Replace("}","").Replace("{","");
}

var literal=@"{""a"", ""avalue""} / { ""b"", ""bvalue"" }/ { ""cb"", ""cvalue"" }/ { ""cbc"", ""cccvalue"" }";
literal.Dump();
var genDic = literal.Split('/');
genDic.Dump();
 
var x = new Dictionary<string,string>();

foreach(var tuple in genDic)
{	var pair=tuple.Split(',');
pair.Dump();
	x.Add(
	makeToken(pair[0]),makeToken( pair[1] ));	 	 
}
 
x.Dump();

x["a"].Dump();