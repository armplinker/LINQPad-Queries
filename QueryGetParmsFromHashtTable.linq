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

ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('materialmain', 'designmain', 'district' , 'county', 'placecode' ) ");

var dv = ParamtrsCache.Get_DataView("bridge", "district");
dv.Sort = "parmvalue DESC";

//dv.Dump();


var dvs = ParamtrsCache.Get_AllDataViews();
foreach (var item in dvs.Values)
{
	DataView theDv = item as DataView;
	if (theDv.RowFilter.Contains("district", StringComparison.OrdinalIgnoreCase))
	{
		theDv.Sort = "parmvalue ASC";
		//theDv.Dump();
	}
}


var ds = new DataSet();
var picklistTableName = $"{"bridge"}_{"district"}_picklist";
var dv2 = ParamtrsCache.Get_DataView("bridge", "district");
var orderByClause = $@"{"TABLE_NAME"}, {"FIELD_NAME"}, {"ORDER_NUM DESC"},{"PARMVALUE"}";

if (dv2 != null)
{
	orderByClause = Regex.Replace(orderByClause, @"""", "\'"); ;
	dv2.Sort = orderByClause;
	var dvt = dv2.ToTable(picklistTableName);
	ds.Tables.Add(dvt);
	//ds.Dump();
	ds.Tables[picklistTableName].Dump();
}

return;