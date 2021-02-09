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
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

var TableName = @"bridge";
var ColumnName = @"district";
var cacheName = @"LINQPAD_TEST";
var cStr = @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer";

Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));


//var whereClause = @" WHERE EXISTS
// (SELECT 1
//          FROM Kdotblp_Attribute_Descriptor Kad
//         WHERE (TRIM(Lower(Kad.Table_Name)) = TRIM(Lower(p.Table_Name)) AND
//               TRIM(Lower(Kad.Col_Name)) = TRIM(Lower(p.Field_Name)))
//            Or ( Kad.Sql_Query LIKE ('%' || p.Field_Name || '%') And Kad.Sql_Query LIKE ('%' || p.Table_Name || '%')))";
//
var whereClause = @" Where ( TRIM(LOWER( p.Field_Name)) <> 'bridgegroup'
	 AND TRIM(LOWER( p.Field_Name )) <> 'placecode'
     AND EXISTS
   (SELECT 1	
			FROM Kdotblp_Attribute_Descriptor Kad
		   WHERE (TRIM(Lower(Kad.Table_Name)) = TRIM(Lower(p.Table_Name)) AND
				 TRIM(Lower(Kad.Col_Name)) = TRIM(Lower(p.Field_Name)))
              OR(Kad.Sql_Query LIKE('%' || p.Field_Name || '%') AND
				 Kad.Sql_Query LIKE('%' || p.Table_Name || '%'))) )";

OracleConnection oraConn = new Oracle.ManagedDataAccess.Client.OracleConnection(@"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer");

//StaticParamtrsCache.LoadStaticParamtrsCache(cacheName, cStr, true, true, whereClause);// @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode', 'materialmain' ) ");


var beginTime = DateTime.Now;
ParamtrsCache.LoadParamtrsCache(cacheName, oraConn, true, true, whereClause);
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);

Console.WriteLine($"CACHE LOAD STARTED at {beginTime}");
Console.WriteLine($"CACHE LOAD ENDED at {endTime}");
Console.WriteLine($"Load took {res}");

ParamtrsDT dt = ParamtrsCache.GetParms();
Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

//Expression < Func<ParamtrDtRow, bool> > lambda =  p => p["FIELD_NAME"].ToString() == "county";

var filter = ParamtrDtRow.GetTableFieldParms(TableName, ColumnName);
//filter.Dump();

Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

//.Where (exp,arg) //("p[\"FIELD_NAME\"] = @0","county")
//.Where("TABLE_NAME = @0 and FIELD_NAME = @1", "bridge", "district")
//
var query = dt.AsEnumerable().AsQueryable()
.Where(p => p["TABLE_NAME"].ToString() == TableName && p["FIELD_NAME"].ToString() == ColumnName && int.Parse(p["ISACTIVE"].ToString()) == 1 && (!(p["MISVALFLG"].ToString().Contains("_"))))
.OrderBy("TABLE_NAME, FIELD_NAME, ORDER_NUM DESC, PARMVALUE")
.Select("new ( PARMVALUE as PARMVALUE, SHORTDESC as SHORTDESC)").ToDynamicArray();
Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

query.Dump();

//var parms = StaticParamtrsCache.GetParms();
var orderByClause = @"TABLE_NAME, FIELD_NAME, ORDER_NUM descending, PARMVALUE";
var selectList = "new ( PARMVALUE as PARMVALUE, SHORTDESC as SHORTDESC)";
Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

var qry = dt.AsEnumerable().AsQueryable()
	 .Where(p => (p["TABLE_NAME"].ToString().ToLower() == TableName) &&
				 (p["FIELD_NAME"].ToString().ToLower() == ColumnName) &&
				 (p["ISACTIVE"].ToString().Contains("1")) &&
				 (!(p["MISVALFLG"].ToString().Contains("_") || string.IsNullOrEmpty(p["MISVALFLG"].ToString()))))
	 .OrderBy(orderByClause) // e.g. "TABLE_NAME,FIELD_NAME, ORDER_NUM DESC, PARMVALUE");							 
	 .ToDynamicList<ParamtrDtRow>();//.Select(selectList);

Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

qry.Dump();
var filter2 = $"TABLE_NAME.ToString().ToLower()==@0 and FIELD_NAME.ToString().ToLower() == @1 and int.Parse(ISACTIVE.ToString() ) == 1 and (!( MISVALFLG == @2 OR MISVALFLG=@3))";
qry = dt.AsEnumerable().AsQueryable()
   .Where(filter2, TableName, ColumnName, "_", string.Empty)
   .OrderBy(orderByClause) // e.g. "TABLE_NAME,FIELD_NAME, ORDER_NUM DESC, PARMVALUE");							 
   .ToDynamicList<ParamtrDtRow>();//.Select(selectList);

Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

qry.Dump();

dt = ParamtrsCache.GetParms("bridge", "materialmain");
qry = dt.AsEnumerable().AsQueryable()
   .Where(filter2, TableName, ColumnName, "_", string.Empty)
   .OrderBy(orderByClause) // e.g. "TABLE_NAME,FIELD_NAME, ORDER_NUM DESC, PARMVALUE");							 
   .ToDynamicList<ParamtrDtRow>();//.Select(selectList);

Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

qry.Dump();
Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));


beginTime = DateTime.Now;
dt = ParamtrsCache.GetParms("bridge", "county");
qry = dt.AsEnumerable().AsQueryable()
   .Where(filter2, TableName, ColumnName, "_", string.Empty)
   .OrderBy(orderByClause) // e.g. "TABLE_NAME,FIELD_NAME, ORDER_NUM DESC, PARMVALUE");							 
   .ToDynamicList<ParamtrDtRow>();//.Select(selectList);

qry.Dump();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);

Console.WriteLine($"QUERY for COUNTY PARAMTR VALUES STARTED at {beginTime}");
Console.WriteLine($"QUERY ENDED at {endTime}");
Console.WriteLine($"Load took {res}");

dt = ParamtrsCache.GetParms("inspevnt", "oppostcl");
qry = dt.AsEnumerable().AsQueryable()
   .Where(filter2, TableName, ColumnName, "_", string.Empty)
   .OrderBy(orderByClause) // e.g. "TABLE_NAME,FIELD_NAME, ORDER_NUM DESC, PARMVALUE");							 
   .ToDynamicList<ParamtrDtRow>();//.Select(selectList);



qry.Dump();
Console.WriteLine(DateTime.Now.ToString("hhmmss.ffff"));

Console.WriteLine("END TEST");