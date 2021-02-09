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
  <Namespace>System.Linq.Dynamic</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <Namespace>System.Linq.Dynamic.Core.CustomTypeProviders</Namespace>
  <Namespace>System.Linq.Dynamic.Core.Exceptions</Namespace>
  <Namespace>System.Linq.Dynamic.Core.Parser</Namespace>
</Query>

var filterString = "";

string sqlFilters = @"
SELECT pau.Userkey
      ,pau.pon_app_users_GD
      ,paug.Groupkey
      ,paug.pon_app_groups_GD
      ,pagaf.Filterkey
      ,pagaf.pon_filters_GD
      ,pf.Where_Clause AS Sql_Filter
FROM Pon_App_Users pau
INNER JOIN Pon_App_Users_Groups paug
ON pau.pon_app_users_GD = paug.pon_app_users_GD
INNER JOIN Pon_App_Groups pag
ON (paug.pon_app_groups_GD = pag.pon_app_groups_GD)
INNER JOIN Pon_App_Group_Access_Filters pagaf
ON (pagaf.pon_app_groups_GD = pag.pon_app_groups_GD)
INNER JOIN Pon_Filters pf -- ARMarshall, ARM LLC _ 20180405 - changed the alias to pf
ON (pagaf.pon_filters_GD = pf.pon_filters_GD)
WHERE pau.pon_app_users_GD = :pon_app_users_gd
AND (pag.Status = 1 AND (TRIM(Nvl(pf.Where_Clause, q'[-1]')) <> q'[-1]')
      AND Upper(Substr(TRIM(pf.Where_Clause), 1, 5)) = q'[WHERE]') -- has to start with WHERE for LBIS
ORDER BY pag.Groupkey, pf.Filterkey";
var cmd = new OracleCommand()
{
	CommandText = sqlFilters,
	CommandType = CommandType.Text,
	Connection = new OracleConnection()
	{
		ConnectionString = "Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD; User ID=KDOT_BLP; Password=eis3nh0wer;"
	}

};


var parm = new Oracle.ManagedDataAccess.Client.OracleParameter()
{
	ParameterName = "pon_app_users_gd",
	OracleDbType = OracleDbType.Varchar2,
	Size = 32,
	Direction = ParameterDirection.Input,
	Value = "7E8FB8F3667E4B89A0864036B35FD989" // user with > 100 group memberships!
	//Value="5A7E1B3375C841F5B3E1EFFDB0EACA59" // user with 93 group memberships
	//Value = "59FE9F4080BF4FE6A25B273484F0E6A1"
};

cmd.Parameters.Add(parm);

cmd.Connection.Open();
var a = new OracleDataAdapter(cmd);
var dt = new DataTable();
var rows = a.Fill(dt);

dt.Dump();

// where (p => f.Field<string>("WhereClause").ToString().Contains("WHERE",StringComparison.OrdinalIgnoreCase))

var qry = from f in dt.AsEnumerable().AsQueryable()
		  select f.Field<string>("Sql_Filter");

qry.Dump();

var qry2 = from f in dt.AsEnumerable().AsQueryable()
		   select f.Field<string>("Sql_Filter").ToString();

qry2.Dump();

var filters = string.Join(" OR ", qry2).Replace("OR WHERE", "OR ");
filters.Dump();



//
//
//var dbFilter = "WHERE b1.BRIDGEGROUP = 'Larned PCG' OR b1.BRIDGEGROUP = 'Clay CYG'";
//

//var qry = from b in Bridges
//		  where b.Bridgegroup == "Allen CYG"
//		  select b;
//qry.Dump();
//var orderByClause = "BridgeID ascending";
//
//var qry2 = qry
//.Where("Brkey == @0", "000000000010010")
//.OrderBy(orderByClause)
//.Select("new(BridgeID as BRKEY, BridgeGd as BRIDGE_GD)");
//
//qry2.Dump();

//
//var qry2 = from p in StaticParamtrsCache.GetParms().AsEnumerable()
//		   where (p.Field<string>("TABLE_NAME") == tName && p.Field<string>("FIELD_NAME") == fName &&
//				 p.Field<int>("ISACTIVE") == 1)
//		   orderby p.Field<int>("ORDER_NUM") descending, p.Field<string>("PARMVALUE")
//		   select p;
//
//qry2.Dump();