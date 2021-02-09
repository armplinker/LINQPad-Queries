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
ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode' ) ");

var tName = "bridge";
var fName = "placecode";
var orderByClause = $@"{"TABLE_NAME"}, {"FIELD_NAME"}, {"ORDER_NUM"},{"PARMVALUE"}";
var beginTime = DateTime.Now;
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res="";
var dvKey = tName + "_" + fName;
var dtName = (dvKey + "_picklist");



beginTime = DateTime.Now;
ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode' ) ");
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LOAD CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);

beginTime = DateTime.Now;
var dvs = ParamtrsCache.Get_AllDataViews();
var dv = dvs[dvKey];
dv.Sort=orderByClause;
var dt = dv.ToTable(dtName);
DataSet ds = new DataSet();
ds.Tables.Add(dt);

//ddl_Control.DataSource = ds.Tables[dtName].DefaultView;

// if the first column is named 'ENUMERATION',  then this is a list of integers to form a picklist
// otherwise it is of the form PARMVALUE/SHORTDESC or TABLE/FIELD/(PARMVALUE|CODE) / (SHORTDESC|LABEL) depending on the source SQL Query
// value column / text column
// 0,0 - ENUMERATION
// 0,1 - CODE / LABEL
// 2,3 - PARMVALUE / SHORTDESC


var srcColumnIdx = ((
	ds.Tables[dtName].Columns[0].ColumnName
	.StartsWith("ENUM", StringComparison.OrdinalIgnoreCase) ||
	ds.Tables[dtName].Columns[0].ColumnName.ToUpper()
	.StartsWith("CODE", StringComparison.OrdinalIgnoreCase) ||
	ds.Tables[dtName].Columns[0].ColumnName.ToUpper()
	.StartsWith("PARMVALUE", StringComparison.OrdinalIgnoreCase))
	? 0
	: 2);  // 2 when column names are tab / col /parmvalue / shortdesc

var txtColIdx = (srcColumnIdx == (ds.Tables[dtName].Columns.Count - 1)
	? 0
	: ((ds.Tables[dtName].Columns.Count < 4) ? 1 : 3)); // ignore column 3 if there are only 3 columns, as it holds 'pick_list_sortorder' which is not the text column

var dvTextField =
	ds.Tables[dtName].Columns[srcColumnIdx].ColumnName; //0 for ENUMERATION/CODE, or 2 for PARMVALUE

var dvValueField =
	ds.Tables[dtName].Columns[txtColIdx]
		.ColumnName; //will be 0 for ENUMERATION, 1 for CODE/LABEL, or 3 when PARMVALUE/SHORTDESC
var bindings = $"Table: {dt.TableName} - Text: {dvTextField} / Value: {dvValueField} - OrderBy: {dv.Sort} - Items: {dt.Rows.Count}";
bindings.Dump();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "GET DT FROM CACHE DVs", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);


ds.Clear();
dt.Clear();

beginTime = DateTime.Now;
dv = ParamtrsCache.Get_DataView(tName,fName);
dv.Sort = orderByClause;
dt = dv.ToTable(dtName);
ds = new DataSet();
ds.Tables.Add(dt);
srcColumnIdx = ((
	ds.Tables[dtName].Columns[0].ColumnName
	.StartsWith("ENUM", StringComparison.OrdinalIgnoreCase) ||
	ds.Tables[dtName].Columns[0].ColumnName.ToUpper()
	.StartsWith("CODE", StringComparison.OrdinalIgnoreCase) ||
	ds.Tables[dtName].Columns[0].ColumnName.ToUpper()
	.StartsWith("PARMVALUE", StringComparison.OrdinalIgnoreCase))
	? 0
	: 2);  // 2 when column names are tab / col /parmvalue / shortdesc

  txtColIdx = (srcColumnIdx == (ds.Tables[dtName].Columns.Count - 1)
	? 0
	: ((ds.Tables[dtName].Columns.Count < 4) ? 1 : 3)); // ignore column 3 if there are only 3 columns, as it holds 'pick_list_sortorder' which is not the text column

  dvTextField =
	ds.Tables[dtName].Columns[srcColumnIdx].ColumnName; //0 for ENUMERATION/CODE, or 2 for PARMVALUE

  dvValueField =
	ds.Tables[dtName].Columns[txtColIdx]
		.ColumnName; //will be 0 for ENUMERATION, 1 for CODE/LABEL, or 3 when PARMVALUE/SHORTDESC
  bindings = $"Table: {dt.TableName} - Text: {dvTextField} / Value: {dvValueField} - OrderBy: {dv.Sort} - Items: {dt.Rows.Count}";
bindings.Dump();



endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "GET DT FROM CACHE DVs", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);