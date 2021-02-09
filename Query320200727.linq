<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

var xt=".pdf,  .doc,docx,     .xls";
Hashtable ht = new Hashtable();

string[] allowed =   xt.Split(',') ;

var qry = from t in allowed
		  where t.Trim().StartsWith(".") == false	
		  select t;
		   
qry.Dump();

DateTime ratingDt = new DateTime();
ratingDt.Dump();


var fixedExt = allowed.Select(x => (x.Trim().StartsWith(".") ? x.Trim() : string.Concat(".",x.Trim())));
fixedExt.Dump();

var xtF = xt.Trim().Split(',').Select(y => (y.Trim().StartsWith(".") ? y.Trim() : string.Concat(".",y.Trim())));
xtF.Dump();

var single = "  pdf  ".Trim().Split(',').Select(y => (y.Trim().StartsWith(".") ? y.Trim() : string.Concat(".",y.Trim())));
single.Dump();


xt = ".pdf,  .doc,docx,     .xls";
fixedExt = xt.Split(',').Select(x => (x.Trim().StartsWith(".") ? x.Trim() : string.Concat(".", x.Trim())));
fixedExt.Dump();
//Value
//.xls
//.pdf
//.docx
//.doc