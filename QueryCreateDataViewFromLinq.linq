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

ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode' ) ");


// (grp.Field<string>("TABLE_NAME") as TABLE_NAME), grp.Field<string>FIELD_NAME  AS FIELD_NAME}
//IEnumerable<ParamtrDtRow> dt = StaticParamtrsCache.GetParms().AsEnumerable().ToDynamicList<ParamtrDtRow>();

/*
List<Schedule> Schedules = new List<Schedule>();

            var bla = from s in Schedules
                      group s by new { s.empid, s.weekending} into g
                      select new { g.Key.empid, g.Key.weekending, g.Sum(s=>s.hours)};
					  */

/*
DataView custDV = new DataView(customerDS.Tables["Customers"],   
"Country = 'USA'",   
"ContactName",   
DataViewRowState.CurrentRows);  
DataView custDV = customerDS.Tables["Customers"].DefaultView;  

DataViewRowState Description
CurrentRows - The Current row version of all Unchanged, Added, and Modified rows. This is the default.
Added - The Current row version of all Added rows.
Deleted - The Original row version of all Deleted rows.
ModifiedCurrent - The Current row version of all Modified rows.
ModifiedOriginal - The Original row version of all Modified rows.
None - No rows.
OriginalRows - The Original row version of all Unchanged, Modified, and Deleted rows.
Unchanged - The Current row version of all Unchanged rows.

*/

var parms = 
from p in ParamtrsCache.GetParms().AsEnumerable().AsQueryable()
where p.Field<string>("FIELD_NAME") == "county"
group p by new Tuple<string, string>( p.Field<string>("TABLE_NAME") , p.Field<string>("FIELD_NAME")) into g
select new { TableName = g.Key.Item1  , FieldName=g.Key.Item2};

//parms.Dump();
/*
employees.All(p => {
    collection.AddRange(p.Departments);
    p.Departments.All(u => { u.SomeProperty = null; return true; } );
    return true;
*/
var dt = ParamtrsCache.GetParms();
//var ds= new DataSet();
//ds.Tables.Add(dt);
 
	
DataView dv = new DataView (dt, "TABLE_NAME = 'bridge' and FIELD_NAME = 'district'", "order_num DESC, parmvalue ASC", DataViewRowState.CurrentRows);
foreach (DataRowView r in dv)
{
	r["PARMVALUE"].Dump();
}

//.GroupBy(p => p.TABLE_NAME, p=> p.FIELD_NAME)//grp => new Tuple<string, string>(grp["TABLE_NAME"].ToString(), grp["FIELD_NAME"].ToString()))
//.Select(p => p.First())
//.Where(p => p[0].ToString() == "county")
 

 

// 
//List<ParamtrDtRow> parms = from prm in StaticParamtrsCache.GetParms().AsEnumerable()
//                            parms.Field<string>("TABLE_NAME"), parms.Field<string>("FIELD_NAME")
							
							
							
							
							
							
							
							
//
//
//List<ParamtrDtRow> result = parms                         
//						 .GroupBy(grp =>   new Tuple<string, string>(grp["TABLE_NAME"].ToString(), grp["FIELD_NAME"].ToString()))
//						 .Select(p => p.First())
//						 .ToList();
//
//
//var tName = "bridge";
//var fName = "district";
//
//var qry = from p in StaticParamtrsCache.GetParms()?.AsEnumerable()
//		  where (p.Field<string>("TABLE_NAME") == tName && p.Field<string>("FIELD_NAME") == fName &&
//				 p.Field<int>("ISACTIVE") == 1)
//		  orderby p.Field<int>("ORDER_NUM"), p.Field<string>("PARMVALUE")
//		  select p as ParamtrDtRow;
//qry.Dump();
//
//var picklistDt = new ParamtrsDT($"{tName}_{fName}_picklist");
//
//DataTable table = qry.CopyToDataTable<ParamtrDtRow>();
//
//picklistDt.Merge(table);
//
//picklistDt.Dump();