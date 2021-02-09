<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\gudusoft.gsqlparser.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\log4net.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

/// <summary>
/// Function to see if a given INSPKEY exists in the database.
/// </summary>
/// <param name="theInspkey"></param>
/// <returns>true if INSPKEY is found in INSPEVNT table for the given BRIDGE_GD</returns>

bool CheckIfInspkeyExists(string theInspkey, string theBridge_Gd = "")
{
	try
	{

		var sql = $@"SELECT 1 FROM INSPEVNT i WHERE i.INSPKEY=:the_inspkey and ROWNUM=1";

		if (!string.IsNullOrEmpty(theBridge_Gd))
			sql = sql.ModifyWhereClauseGSP(modString: "AND i.BRIDGE_GD =:the_bridge_gd", AndOrFlg: 1);

		sql.CheckSyntax(true);

		var cmd = new OracleCommand()
		{
			CommandText = sql.FormatSqlString(),
			BindByName = true,
			Connection = new OracleConnection(@"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer")
		};

		cmd.Parameters.Add(new OracleParameter()
		{
			ParameterName = "the_inspkey",
			OracleDbType = OracleDbType.Varchar2,
			Size = 4
		}).Value = theInspkey;

		if (!string.IsNullOrEmpty(theBridge_Gd))
			cmd.Parameters.Add(new OracleParameter()
			{
				ParameterName = "the_bridge_gd",
				OracleDbType = OracleDbType.Varchar2,
				Size = 32
			}).Value = theBridge_Gd;

		cmd.Connection.Open();
		var o = cmd.ExecuteScalar();
		cmd.Connection.Close();

		var ok = int.TryParse(o?.ToString(), out var theCount);

		if (ok) // sql succeeded.  True is record count > 0
			return (theCount > 0);

		return false; // failed
	}
	catch (Exception e)
	{
		Global.Log?.Error(e);
		throw;
	}
}

string GenInspkey(bool dbVerify = false, string bridgeGd = "")
{
	var testInspkey = "";



	const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	var random = new Random();
	testInspkey = new string(Enumerable.Repeat(@"ABCDEFGHIJKLMNOPQRSTUVWXYZ", 1)
	   .Select(s => s[random.Next(s.Length)]).ToArray());
	testInspkey += new string(Enumerable.Repeat(validChars, 3)
		.Select(s => s[random.Next(s.Length)]).ToArray());

	if (dbVerify)

		CheckIfInspkeyExists(testInspkey, bridgeGd);



	return testInspkey;
}



GenInspkey(dbVerify: true).Dump();

string  BrMGuidRegex =			   @"^[A-Z0-9]{32}$"; 

var result ="";
var oraConn =  new OracleConnection(@"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer");

LBIS9.OraDbHelpers.GuidForStringOra(theStringKey: "000000000090110", theSrcTable: "bridge", theSrcColName: "brkey",
					theTgtColName: "bridge_gd", reqLength: 32, regexPattern: BrMGuidRegex, allowNullResult: true,
					throwError: true, oraConn:oraConn).Dump();
