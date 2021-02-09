<Query Kind="Statements">
  <Connection>
    <ID>c6f9f33f-8b1a-40b9-b725-61c7435325fd</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAOAojCZXO3E+yhYomOP40igAAAAACAAAAAAAQZgAAAAEAACAAAAAilmyYLOGZAmRUtcdc6Ulj9E86+RpmsoBprpsklBJFEgAAAAAOgAAAAAIAACAAAACivsu0Lww8s8lm5jLma3VbuhC66dEjJuuPGRue1W420WAAAACwrAUyTDyATWrGS0XacNq8t2tFonI2Y1IoCt8NI2P+qZJge51RBuA8CH7JVVnwlcmVYHyIDdxNA7tjPKjjVJ2W1e7JQnp6aiONRfUgdkGV/ysl+2DqvXfJh5/2b3Xmu/dAAAAAkHEGPYGhxbAesurEQC6CZRxo0fpDPDjPzSx5HQBJNXZ7LpEiYj5SuG9yCDx6lIB6vLVmXai9i4HSMrYN5Xk4nA==</CustomCxString>
    <Server>dt00en60.ksdot.org:1521/ESOADEV.WORLD</Server>
    <UserName>KDOT_BLP</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAOAojCZXO3E+yhYomOP40igAAAAACAAAAAAAQZgAAAAEAACAAAABM5+CjkHsThRygk6PBuQCAhDtPFszQ0nzouKLrnNht/wAAAAAOgAAAAAIAACAAAACQ1+pNS/QYQtnUCH8YzdAVNKADwPX2jU+BtPBzgB1eaxAAAADnkYoNEnH+IZp35XA68iXZQAAAAJKAWKQU2w/JhGAiOh8aA60Y52lWbrQXmx1ijmRVPb99iOqV//Pa1rLf4457aDkOv3YnhlMVyqbtz3X4hsHA06s=</Password>
    <DisplayName>ESOADEV</DisplayName>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <ConnectAs>Default</ConnectAs>
      <UseOciMode>false</UseOciMode>
    </DriverData>
  </Connection>
  <Reference>D:\git\BrMLinqUtils\BrMLInqUtils\bin\Debug\BrMLinqUtils.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.ComponentModel.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>BrMLinqUtils</Namespace>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

//#define DATABASESOURCE
//IQueryable parms = new Paramtrs() as IQueryable;
//var predicate = PredicateBuilder.False<Paramtrs>();
//bool normalize = true;
//string[] criteriaStr = { "district" };
//foreach (var str in criteriaStr)
//{
//	var temp = normalize?str.ToLower().Trim() : str;
//	predicate = predicate.Or(f => (normalize?f.FieldName.ToLower().Trim() : f.FieldName) == temp);
//}	
//Expression<Func<Paramtrs, bool>> predicate = c => true;

#if DATABASESOURCE

Expression<Func<Paramtrs, bool>> result1 = r1 => r1.TableName.Contains("bridge");
Expression<Func<Paramtrs, bool>> result2 = r2 => r2.FieldName.Contains("placecode");
Expression<Func<Paramtrs, bool>> result3 = r3 => r3.Isactive == 1;
Expression<Func<Paramtrs, bool>> result4 = r4 => (r4.Misvalflg == "1" || r4.Misvalflg == "_");

//Expression<Func<Paramtrs, string>> result5 = r5 => (r5.OrderNum.Value <= 0 ) ? "999999":r5.OrderNum.ToString();

Expression<Func<Paramtrs,string>> orderby1 = ob1 => ob1.OrderNum.ToString();
//orderby1.Dump();
Expression<Func<Paramtrs,string>> orderby2 = ob2 => ob2.Parmvalue;
//orderby2.Dump();

Expression<Func<Paramtrs, decimal?>> orderby3 = ob3 => (ob3.OrderNum <= 0) ? 999999 : ob3.OrderNum;
//orderby3.Dump();

var predicates = new List<Expression<Func<Paramtrs, bool>>>();
predicates.Add(result1);
predicates.Add(result2);
predicates.Add(result3);

//Expression<Func<Paramtrs, bool>> predicate;
Expression<Func<Paramtrs, bool>> predicate = BrMPredicateBuilder.True<Paramtrs>();

foreach (Expression<Func<Paramtrs, bool>> pred in predicates)
{
	var temp = pred;
	predicate = BrMPredicateBuilder.And(predicate, temp);
}

predicate = BrMPredicateBuilder.And(predicate, BrMPredicateBuilder.Not(result4));
//predicate.Dump();

IQueryable<Paramtrs> parms  =  Paramtrs
 .Where (predicate)
 .OrderBy (orderby3)
 .ThenBy(orderby1);


parms.Select(x => new { x.OrderNum, x.Parmvalue, x.Shortdesc }).Dump();

#else

var cacheName = "LINQPAD_TEST";

var cStr = @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer";

var whereClause = @" Where ( TRIM(LOWER( p.Field_Name)) <> 'bridgegroup'
	 AND TRIM(LOWER( p.Field_Name )) <> 'placecode'
     AND EXISTS
   (SELECT 1	
			FROM Kdotblp_Attribute_Descriptor Kad
		   WHERE (TRIM(Lower(Kad.Table_Name)) = TRIM(Lower(p.Table_Name)) AND
				 TRIM(Lower(Kad.Col_Name)) = TRIM(Lower(p.Field_Name)))
              OR(Kad.Sql_Query LIKE('%' || p.Field_Name || '%') AND
				 Kad.Sql_Query LIKE('%' || p.Table_Name || '%'))) )";

var beginTime = DateTime.Now;
StaticParamtrsCache.LoadStaticParamtrsCache(cacheName, cStr, true, true, whereClause);
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"CACHE LOAD (ConnectionString) STARTED at {beginTime}");
Console.WriteLine($"CACHE LOAD (ConnectionString) ENDED at {endTime}");
Console.WriteLine($"Load using ConnectionString took {res}");




beginTime = DateTime.Now;
StaticParamtrsCache.PurgeParms();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"PURGE CACHE STARTED at {beginTime}");
Console.WriteLine($"PURGE CACHE  ENDED at {endTime}");
Console.WriteLine($"PURGE CACHE took {res}");



var oraConn = new OracleConnection(cStr);
oraConn.OraOpenIfClosed();

beginTime = DateTime.Now;
StaticParamtrsCache.LoadStaticParamtrsCache(cacheName, oraConn, true, true, whereClause);
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"CACHE LOAD (OracleConnection) STARTED at {beginTime}");
Console.WriteLine($"CACHE LOAD (OracleConnection) ENDED at {endTime}");
Console.WriteLine($"Load using OracleConnection took {res}");



//DataTable dt = new DataTable(@"paramtrs");	
//var xt = StaticParamtrsCache.GetParms();
//xt.Dump();
//OrderedEnumerableRowCollection<ParamtrDtRow> qry = from p in 	
//						   where (p.Field<int>("ISACTIVE") == 1 && ( p.Field<string>("FIELD_NAME")== "district"  || p.Field<string>("FIELD_NAME")== "county" || p.Field<string>("FIELD_NAME")== "placecode" ))
//						   orderby p.Field<string>("TABLE_NAME"),p.Field<string>("FIELD_NAME"),p.Field<int>("ORDER_NUM"), p.Field<string>("PARMVALUE")
//						   select p as ParamtrDtRow;
//qry.Dump();

//dt = qry.CopyToDataTable() as ParamtrsDT;
//dt = StaticParamtrsCache.GetParms();
//dt.Columns.Dump();

//
////where product.Field<int>("Id") == 2
//Expression<Func<DataTable, bool>> result1 = r1 =>  r1.Columns["table_name"].ToString().Contains("bridge");
//
//Expression<Func<DataTable, bool>> result2 = r2 =>  r2.Columns["field_name"].ToString().Contains("placecode");
//Expression<Func<DataTable, bool>> result3 = r3 =>  r3.Columns["isactive"].ToString()  == "1";
//Expression<Func<DataTable, bool>> result4 = r4 =>  r4.Columns["misvalflg"].ToString() == "1" || r4.Columns["misvalflg"].ToString() == "_";
//
//	
//var predicates = new List<Expression<Func<DataTable, bool>>>();
//predicates.Add(result1);
//predicates.Add(result2);
//predicates.Add(result3);
//
////Expression<Func<Paramtrs, bool>> predicate;
//Expression<Func<DataTable, bool>> predicate = BrMPredicateBuilder.True<DataTable>();
//
//foreach (Expression<Func<DataTable, bool>> pred in predicates)
//{
//	var temp = pred;
//	predicate = BrMPredicateBuilder.And<DataTable>(predicate, temp);
//}	
//
//predicate = BrMPredicateBuilder.And<DataTable>(predicate, BrMPredicateBuilder.Not(result4));
//
//
//
////Expression<Func<Paramtrs, string>> result5 = r5 => (r5.OrderNum.Value <= 0 ) ? "999999":r5.OrderNum.ToString();
//
//Expression<Func<DataTable, string>> orderby1 = sort1 => sort1.Columns["order_num"].ToString();
////orderby1.Dump();
//Expression<Func<DataTable, string>> orderby2 = sort2 => sort2.Columns["parmvalue"].ToString()
////orderby2.Dump();
///
////Expression<Func<DataTable, DataColumn>> orderby3 = sort3 => (sort3.Columns["order_num"].ToString().Contains("0")) ? sort3.Columns["parmvalue"].ToString() : sort3.Columns["order_num"].ToString();
////orderby3.Dump();

//var whereClause = $"\"{"table_name"}\"  == \"{"bridge"}\" and \"{"field_name"}\" == \"{"district"}\"  and \"{"isactive"}\" == \"{1}\" and ( \"{"misvalflg"}\" != \"{"_"}\"  and \"{"misvalflag"}\" != \"{" "}\") ";
//whereClause.Dump();

//var orderByClause = ("@0,  @1, @2", "table_name", "field_name", "order_num DESC");
//orderByClause.Dump();

//dt.Dump();
//dt.Rows[0].Dump();
//dt.Rows[0].Field<string>("table_name").Dump();
//dt.Rows[0].GetPropValue("table_name").DumpTrace();
//dt.Rows[0].DebugProperties();

//dt.Rows[0].ItemArray.Dump();


Expression<Func<ParamtrDtRow, bool>> result1 = p => p["TABLE_NAME"].ToString().Contains("bridge");
//Expression<Func<ParamtrDtRow, bool>> result2 = p => p["FIELD_NAME"].ToString().Contains("county") || p["FIELD_NAME"].ToString().Contains("district");
Expression<Func<ParamtrDtRow, bool>> result2 = p => p["FIELD_NAME"].ToString().Contains("district");
Expression<Func<ParamtrDtRow, bool>> result3 = p => int.Parse(p["ISACTIVE"].ToString()) == 1;

// BUT NOT
Expression<Func<ParamtrDtRow, bool>> result4 = p => p["MISVALFLG"].ToString() == "1" || p["MISVALFLG"].ToString() == "_";




var predicates = new List<Expression<Func<ParamtrDtRow, bool>>>();

predicates.Add(result1);
predicates.Add(result2);
predicates.Add(result3);

var predicate = BrMPredicateBuilder.True<ParamtrDtRow>(); // AND predicate

foreach (Expression<Func<ParamtrDtRow, bool>> pred in predicates)
{
	var temp = predicate;
	predicate = BrMPredicateBuilder.And<ParamtrDtRow>(pred, temp);
}

predicate = BrMPredicateBuilder.And<ParamtrDtRow>(predicate, BrMPredicateBuilder.Not<ParamtrDtRow>(result4)); // NOT
																											  //predicate.Dump();
																											  //Console.WriteLine(predicate.ToString());

//ParamtrsDT dt = new ParamtrsDT();

//dt = StaticParamtrsCache.GetParms();

var query = from p in StaticParamtrsCache.GetParms().AsEnumerable()
				// orderby p["TABLE_NAME"], p["FIELD_NAME"] descending, p["ORDER_NUM"] descending, p["PARMVALUE"]
				//orderby p.Field<string>("TABLE_NAME"), p.Field<string>("FIELD_NAME") descending, p.Field<int>("ORDER_NUM") descending, p.Field<string>("PARMVALUE")
			select p as ParamtrDtRow;

var parmsFilter = LBIS9.ParamtrDtRow.GetTableFieldParms("bridge", "district");
//parmsFilter.Dump();
Console.WriteLine(parmsFilter.ToString());

var result = query
			 .AsQueryable()
			 .Where(parmsFilter)
			 // .Where(q => q["FIELD_NAME"].ToString().Contains("placecode"))
			 .ToArray<ParamtrDtRow>();
result.Dump();
//int i = 0;
//var x = StaticParamtrsCache.GetParms();
//
//foreach (ParamtrDtRow row in x.AsEnumerable())
//{
//	foreach (DataColumn column in x.Columns)
//	{
//		foreach (System.ComponentModel.PropertyDescriptor descriptor in System.ComponentModel.TypeDescriptor.GetProperties(column))
//		{
//			descriptor.Dump();
//			
//		}
//		row[column].Dump();
//		i++;
//		if (i > 3) break;
//	}
//}
//
//	i = 0;
//foreach (ParamtrDtRow parmRow in result)
//{
//	foreach (var fldName in new string[] { "TABLE_NAME", "FIELD_NAME", "PARMVALUE" })
//	{
//		//Console.WriteLine($"FIELD_NAME: {parmRow.Field<string>(fldName)} VALUE: {parmRow.Field<string>(fldName).ToString()} ");
//		parmRow.Field<string>(fldName).Dump();
//	}
//
//	i++;
//	if (i > 3) break;
//}


var orderby = @"ORDER_NUM DESCENDING,PARMVALUE";
var filterClause = $"TABLE_NAME.ToString().ToLower()==@0 and FIELD_NAME.ToString().ToLower() == @1 and int.Parse(ISACTIVE.ToString() ) == 1 and (!( MISVALFLG == @2 OR MISVALFLG=@3))";
var qry = StaticParamtrsCache.GetParms().AsEnumerable().AsQueryable()
			 .Where(filterClause, "bridge", "district", "_", string.Empty)
			 .OrderBy(orderby)
			 .ToDynamicArray();
//"ORDER_NUM DESCENDING,PARMVALUE");
// .Where(q => q["FIELD_NAME"].ToString().Contains("placecode"))
// .ToArray<ParamtrDtRow>();
qry?.Dump();

filterClause = "it.FIELD_NAME.ToString() == @0";
var finalResult =
 StaticParamtrsCache.GetParms().AsEnumerable().AsQueryable()
			 .Where(filterClause, "district")
			 .OrderBy(orderby);

finalResult?.Dump();


var tName = "bridge";
var fName = "district";

var qry2 = from p in StaticParamtrsCache.GetParms().AsEnumerable()
		   where (p.Field<string>("TABLE_NAME") == tName && p.Field<string>("FIELD_NAME") == fName &&
				 p.Field<int>("ISACTIVE") == 1)

		   select p;

qry2.Dump();

#endif




//var result = parms.Select(x => new {x.Parmvalue,x.Shortdesc});
//result.Dump();