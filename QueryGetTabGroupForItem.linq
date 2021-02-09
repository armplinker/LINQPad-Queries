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
  <Reference>D:\git\LBIS9\src\bin\LBISCustomControls.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\LBISLsDataAccess.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

var filterString = "";

string sqlFilters = @"select kad.nbi_ID, kad.nbi_Level, kad.table_Name, kad.Col_Name, kad.Data_Edit_Flag, f_safe_decimal(kad.tab_group,0) as tab_group from kdotblp_attribute_descriptor kad where kad.Nbi_ID >=:the_nbi_id";

var cacheName = "LINQPAD_TEST";

var cStr = @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer";



//var whereClause = @" Where ( TRIM(LOWER( p.Field_Name)) <> 'bridgegroup'
//	 AND TRIM(LOWER( p.Field_Name )) <> 'placecode'
//     AND EXISTS
//   (SELECT 1	
//			FROM Kdotblp_Attribute_Descriptor Kad
//		   WHERE (TRIM(Lower(Kad.Table_Name)) = TRIM(Lower(p.Table_Name)) AND
//				 TRIM(Lower(Kad.Col_Name)) = TRIM(Lower(p.Field_Name)))
//              OR(Kad.Sql_Query LIKE('%' || p.Field_Name || '%') AND
//				 Kad.Sql_Query LIKE('%' || p.Table_Name || '%'))) )";

PortalDataDictCache.IsTestMode = true;

PortalDataDictCache.LoadPortalDataDictCache(cacheName, cStr, true, true, String.Empty);

var dd = PortalDataDictCache.PortalDataDict;

var dt = new DataTable("DataItems");

using (var cmd = new OracleCommand()
{
	CommandText = sqlFilters,
	CommandType = CommandType.Text,
	Connection = new OracleConnection()
	{
		ConnectionString = "Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD; User ID=KDOT_BLP; Password=eis3nh0wer;"
	}

})
{

	var parm = new Oracle.ManagedDataAccess.Client.OracleParameter()
	{
		ParameterName = "the_nbi_id",
		OracleDbType = OracleDbType.Varchar2,
		Size = 8,
		Direction = ParameterDirection.Input,
		Value = "090"
	};

	cmd.Parameters.Add(parm);

	cmd.Connection.Open();
	var a = new OracleDataAdapter(cmd);

	var rows = a.Fill(dt);
}

dt.Dump("DT");

var firstRow = from c in dt.AsEnumerable()
			   orderby int.Parse(c.Field<string>("tab_group")), c.Field<string>("nbi_id")
			   group c by c.Field<string>("nbi_id") into ids
			   select ids.FirstOrDefault();

firstRow.Dump("FirstRow");

GetFirstAssignedTabGroup("043B", true).Dump("QRY");


var qry = from f in dt.AsEnumerable().AsQueryable()
		  where f.Field<string>("nbi_id") == "090" && f.Field<string>("data_edit_flag").IsYes() == true
		  select f;

qry.Dump("QRY");

var qry2 = from f in qry
		   where int.Parse(f.Field<string>("tab_group")) == 4
		   select int.Parse(f.Field<string>("tab_group"));

qry2.Dump("QRY2");
var beginTime = DateTime.Now;
var dt2 = new DataTable("CACHE_DATAITEMS");

firstRow = from c in PortalDataDictCache.PortalDataDict.AsEnumerable()
		   orderby c.Field<int>("tab_group"), c.Field<string>("nbi_id")
		   group c by c.Field<string>("nbi_id") into ids
		   select ids.FirstOrDefault();

firstRow.Dump("FROMCACHE");
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"Get tab_group query took {res}");


beginTime = DateTime.Now;
int tab_group = PortalDataDictCache.GetFirstAssignedTabGroup("090");
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"Get tab_group query using object method took {res}");

int GetFirstAssignedTabGroup(string itemId, bool throwError = true)
{
	int tab_id = 0;

	var qry1 = from c in PortalDataDictCache.PortalDataDict.AsEnumerable()
			   orderby c.Field<int>("tab_group"), c.Field<string>("nbi_id")
			   where c.Field<string>("nbi_id") == itemId && c.Field<string>("data_edit_flag") == "1"
			   group c by c.Field<string>("nbi_id") into ids
			   select ids.FirstOrDefault()?.Field<int>("tab_group");

	/qry1.Dump("TABGROUP RESOLVED");
	//PortalDataDictCache.PortalDataDict.Dump();

	tab_id = (int)qry1.First();
    tab_id.Dump("TABGROUP RESOLVED");
	return tab_id;
}


