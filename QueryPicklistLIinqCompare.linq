<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>



var cacheName = "LINQPAD_TEST";
var dump = false;

var tName = "bridge";
var fName = "county";
var orderByClause = $@"{"TABLE_NAME"}, {"FIELD_NAME"}, {"ORDER_NUM"},{"PARMVALUE"}";
var beginTime = DateTime.Now;
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);

var diffCopyToSum = diff;
var diffMergeNoTempSum = diff;
var diffForEachAddRowSum = diff;
var diffForEachImportRowSum = diff;

var res = "";
var ds = new DataSet();
var picklistDt = new ParamtrsDT($"{tName}_{fName}_picklist");
beginTime = DateTime.Now;
ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge'  and p.FIELD_NAME IN ('district' , 'county')");//, 'placecode' ) ");
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LOAD CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);

/*
 var resultDynamic = context.Customers
2:             .Where("c => c.City == \"Paris\" && c.Age > 50")
3:             .ToList();
*/

beginTime = DateTime.Now;
//var whereClause = $"c => c.table_name == \"{tName}\" && c.field_name == \"{fName}\"";
string whereClause = $"\"table_name == @0 &&  field_name ==  @1 ,{tName},{fName} \"";
Console.WriteLine($"Where Clause: {whereClause}");

var qry = ParamtrsCache.GetParms().AsEnumerable().AsQueryable()
			  .Where("table_name == @0 &&  field_name ==  @1", tName, fName)
			  .OrderBy(orderByClause)
			  .ToList();

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE (no table/field arguments) ToList ()", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	qry.Dump();

//orderByClause = Regex.Replace(orderByClause, @"""", "\'");  
beginTime = DateTime.Now;
qry = ParamtrsCache.GetParms(tName, fName).AsEnumerable().AsQueryable()
			  //.Where("c => c.TABLE_NAME == tableName && c.FIELD_NAME == fieldName")
			  .OrderBy(orderByClause)
			  .ToList();

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE (w table/field arguments) ToList ()", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	qry.Dump();

//orderByClause = Regex.Replace(orderByClause, @"""", "\'");  
beginTime = DateTime.Now;
var qry2 = ParamtrsCache.GetParms().AsEnumerable().AsQueryable()
			  .Where("table_name == @0 &&  field_name ==  @1", tName, fName)
			  .OrderBy(orderByClause)
			  .ToDynamicList<ParamtrDtRow>();

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE (no table/field arguments) ToDynamicList<ParamtrDtRow> ", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	qry2.Dump();


//orderByClause = Regex.Replace(orderByClause, @"""", "\'");  
beginTime = DateTime.Now;
qry2 = ParamtrsCache.GetParms(tName, fName).AsEnumerable().AsQueryable()
			  //.Where("c => c.TABLE_NAME == tableName && c.FIELD_NAME == fieldName")
			  .OrderBy(orderByClause)
			  .ToDynamicList<ParamtrDtRow>();

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE(w table/field arguments) ToDynamicList<ParamtrDtRow> ", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
Console.WriteLine($"Msec: {diff.Milliseconds}");
if (dump)
	qry2.Dump();

//dump=true;
Console.WriteLine();
//orderByClause = Regex.Replace(orderByClause, @"""", "\'");  
beginTime = DateTime.Now;
var dvs = ParamtrsCache.Get_AllDataViews();
var dv = dvs[string.Concat(tName, "-", fName).ToLowerInvariant()];
var dt = new DataTable();
dv.RowFilter = $"table_name = '{tName}' and field_name = '{fName}'";
orderByClause = Regex.Replace(orderByClause, @"""", "\'");
dv.Sort = (orderByClause);
dt = dv.ToTable();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "DATAVIEW AS DATATABLE FROM CACHE(filter all DataView objects in dictionary by table/field arguments)", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	dt.Dump();

beginTime = DateTime.Now;
dv = ParamtrsCache.Get_DataView(tName, fName);
Console.WriteLine();
//dv.RowFilter = $"table_name = {tName} and field_name = {fName}";
orderByClause = Regex.Replace(orderByClause, @"""", "\'");
dv.Sort = (orderByClause);
dt = dv.ToTable();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "DATAVIEW AS DATATABLE FROM CACHE(for 1 DataView.ToTable() using table/field arguments)", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	dt.Dump();