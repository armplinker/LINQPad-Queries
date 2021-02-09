<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>


var dt= DateTime.Now.ToString().Replace(":", "").Replace(".", "").Replace(" ","T").Replace("-","");
Console.WriteLine(dt);


dt = DateTime.Now.ToString("yyyyMMddTHHmmssfff",System.Globalization.CultureInfo.InvariantCulture);
Console.WriteLine(dt);