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
var fName = "placecode";
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
ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode' ) ");
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LOAD CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);

beginTime = DateTime.Now;
var qry = from p in ParamtrsCache.GetParms()?.AsEnumerable()
		  where (p.Field<string>("TABLE_NAME") == tName && p.Field<string>("FIELD_NAME") == fName &&
				 p.Field<int>("ISACTIVE") == 1)
		  orderby p.Field<int>("ORDER_NUM"), p.Field<string>("PARMVALUE")
		  select p as ParamtrDtRow;
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	qry.Dump();

beginTime = DateTime.Now;
picklistDt.Clear();
foreach (ParamtrDtRow r in qry)
	picklistDt.Rows.Add(r.ItemArray);
ds.Tables.Add(picklistDt);
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "FOREACH Rows.Add(r.ItemArray)", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	ds.Tables[picklistDt.TableName].Dump();


beginTime = DateTime.Now;
var dv = ParamtrsCache.Get_DataView(tName, fName);
Console.WriteLine($"DV Rows: {dv.Count}");

var dvt = dv.ToTable(picklistDt.TableName);
if (dv != null)
{
	dv.Sort = Regex.Replace(orderByClause, @"""", "\'"); ;

	dvt.TableName = $"{tName}_{fName}_picklist_Variant2";
	ds.Tables.Add(dvt);
	if (dump)
		ds.Dump(); // all done, don't bother with the rest of this
}

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "dv.TOTABLE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	ds.Tables[dvt.TableName].Dump();


Console.WriteLine(Environment.NewLine);