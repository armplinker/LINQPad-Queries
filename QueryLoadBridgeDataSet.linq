<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\gudusoft.gsqlparser.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\log4net.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>gudusoft.gsqlparser</Namespace>
  <Namespace>gudusoft.gsqlparser.nodes</Namespace>
  <Namespace>gudusoft.gsqlparser.pp.para</Namespace>
  <Namespace>gudusoft.gsqlparser.pp.para.styleenums</Namespace>
  <Namespace>gudusoft.gsqlparser.pp.stmtformatter</Namespace>
  <Namespace>gudusoft.gsqlparser.stmt</Namespace>
  <Namespace>LBIS9</Namespace>
  <Namespace>log4net</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

OleDbConnection GetOleDbConnection(string oleConnectStr)
{
	return new OleDbConnection(oleConnectStr);

}

OracleConnection GetOracleConnection(string oraConnectStr)
{
	return new OracleConnection(oraConnectStr);

}

/// Loads primary and related data for a single bridge based on bridge_Gd
/// </summary>
/// <returns></returns>
bool LoadBridgeDataSet(string testBrkey, string testBridgeGd, string oleConnectStr, string oraConnectStr)
{
	var oleDbConn = GetOleDbConnection(oleConnectStr);
	oleDbConn.OleDbOpenIfClosed();

	var oraConn = GetOracleConnection(oraConnectStr);
	oraConn.OraOpenIfClosed();


	bool ok = true;

	var bridge_gd = string.Empty;

	var loadingTable = "";
	var beginTime = new DateTime();
	var endTime = new DateTime();
	var diff = endTime.Subtract(beginTime);
	var res = "";


	try
	{

		DataSet ds = new DataSet("BRIDGE_DATA");
		DataTable dt = new DataTable();

		var brkey = testBrkey;//Request.QueryString["brkey"];

		//TODO Verify this is the best way to implement ability to get bridges by BRIDGE_GD OR BRKEY
		//var bridge_gd = GetBridge_GdbyBrkey(brkey); // the relationship is 1:1
		bridge_gd = testBridgeGd;///Request.QueryString["bridge_gd"];

		//Log?.DebugFormat("LoadBridgeDataSet - BRKEY: {0} / BRIDGE_GD: {1}", brkey, bridge_gd);


		string sql = null;
		var seekBrkey = PontisOleDB.ToDBFormat(brkey.ToUpper().Trim());
		var seekBridgeGd = PontisOleDB.ToDBFormat(bridge_gd.ToUpper().Trim());

		//Log?.DebugFormat("LoadBridgeDataSet - DBFormat - BRKEY: {0} / BRIDGE_GD: {1}", seekBrkey, seekBridgeGd);
		//// reuse this over and over here
		//var conn = GetOleDbConnection();
		//using (conn)
		//{

		var runBeginTime = DateTime.Now;
		Console.WriteLine($"BridgeDataSet LOAD STARTED at {runBeginTime}");

		if (ok)
		{
			// ARMarshall, ARM LLC - changed this to use Global for names of non-standard tables e.g. KDOTBLP_INSPECTIONS (used to be USERINSP) or KDOTBLP_LOAD_RATINGS
			foreach (var tableName in $@"bridge;roadway;inspevnt;{Global.KDOTBLP_AGENCY_BRIDGE_TABLENAME};{Global.KDOTBLP_AGENCY_INSPECTION_TABLENAME};{Global.KDOTBLP_LOAD_RATING_TABLENAME.ToLower()};{Global.KDOTBLP_QAQC_INSPECTION_TABLENAME}".ToLower().Split(';')) // ARMarshall, ARM LLC 20160304 - added KDOTBLP_INSPECTIONS to this list to handle fields for characterizing special inspection types(FC, UW, OS)
			{
				beginTime = DateTime.Now;
				loadingTable = tableName;

				if (string.IsNullOrEmpty(tableName.Trim())) continue;


				//Log?.DebugFormat("Processing table: {0} - SQL: {1}", tableName, sql);

				sql = $@"SELECT b1.* FROM {tableName.Trim()} b1 WHERE b1.bridge_gd = ?; ";

				sql.CheckSyntax(true);
				sql.FormatSqlString().CleanSQLString();

				var getBridgeDataCmd = new OleDbCommand()
				{
					CommandText = sql.CleanSQLString(),
					CommandType = CommandType.Text,
					Connection = oleDbConn
				};

				var oraBridgeParm = new OleDbParameter()
				{
					ParameterName = "theBridgeGd",
					OleDbType = OleDbType.VarChar,
					Size = 32,
					Direction = ParameterDirection.Input,
					Value = bridge_gd
				};

				getBridgeDataCmd.Parameters.Add(oraBridgeParm);

				using (var a = new OleDbDataAdapter(getBridgeDataCmd))
				{
					a.Fill(ds, tableName.Trim());
				}

				ds.Tables[tableName.Trim()].Dump();
				endTime = DateTime.Now;
				diff = endTime.Subtract(beginTime);
				res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
				Console.WriteLine($"Loading {tableName} STARTED at {beginTime}");
				Console.WriteLine($"Loading {tableName} ENDED at {endTime}");
				Console.WriteLine($"Load using OleDbConnection took {res}");
			}
		}


		// DIG 10/25/2006
		// Auxiliary query for the HBRRP value.
		// Notice that it does not select from the V_SUFF_DIST_REPORT1 that have some problems
		// the virtual table is still called V_SUFF_DIST_REPORT1 so that parameters logic could work
		// for the drop down list.
		if (ok)
		{
			var begin = DateTime.Now;
			// TODO this is all obsolete and needs to show INSPEVNT.BRIDGE_CONDITION (Good / Fair / Poor)
			sql = $@"SELECT Brkey
                                  ,bridge_GD
                                  ,Inspkey
                                  ,inspevnt_GD
                                  ,Inspdate
                                  ,Suff_Prefx
                                  ,Suff_Rate
                                  ,Nbi_Rating
                                  ,CASE
                                       WHEN Nbi_Rating IN ('0', 'N')
                                            OR Suff_Rate >= 80.0 THEN
                                        1
                                       WHEN Nbi_Rating NOT IN ('0', 'N')
                                            AND Suff_Rate >= 50.0
                                            AND Suff_Rate < 80.0 THEN
                                        2
                                       WHEN Nbi_Rating NOT IN ('0', 'N')
                                            AND Suff_Rate >= 0.0
                                            AND Suff_Rate < 50.0 THEN
                                        3
                                       ELSE
                                        99
                                   END AS Suffcat
                            FROM INSPEVNT I1
                            WHERE bridge_gd = ?;";

			loadingTable = "HBRRP";

			sql.CheckSyntax(true);

			sql = sql.FormatSqlString().CleanSQLString();

			var hbrrCmd = new OleDbCommand(sql, oleDbConn);
			var hbrrParm = new OleDbParameter()
			{
				ParameterName = @"the_bridge_gd",
				Direction = ParameterDirection.Input,
				OleDbType = OleDbType.VarChar,
				Size = 32,
				Value = seekBridgeGd
			};

			hbrrCmd.Parameters.Add(hbrrParm);


			//                                  " FROM inspevnt i1 WHERE brkey='{0}' or bridge_gd= '{1}'", PontisOleDB.ToDBFormat(brkey), PontisOleDB.ToDBFormat(bridge_gd));

			using (var a = new OleDbDataAdapter(hbrrCmd))//sql.CleanSQLString()/*.CleanTrailingSemicolon()*/, GetOleDbConnection()))
			{

				a.Fill(ds, "v_suff_dist_report1");

			}

			ds.Tables["v_suff_dist_report1"].Dump();

			endTime = DateTime.Now;
			diff = endTime.Subtract(beginTime);
			res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
			Console.WriteLine($"Loading {"v_suff_dist_report1"} STARTED at {beginTime}");
			Console.WriteLine($"Loading {"v_suff_dist_report1"} ENDED at {endTime}");
			Console.WriteLine($"Loading {"v_suff_dist_report1"} took {res}");
		}


		beginTime = DateTime.Now;

		// Auxiliary table to populate the roadway dropdown

		//sql = $@"SELECT p.Shortdesc  AS Roadway_Name
		//                ,r.On_Under   AS On_Under
		//                ,r.roadway_GD AS r
		//                FROM Roadway r, Paramtrs p
		//                WHERE (r.bridge_GD = '{seekBridgeGd}')
		//                AND Lower(p.Table_Name) = 'roadway'
		//                AND Lower(p.Field_Name) = 'on_under'
		//                AND p.Parmvalue = r.On_Under
		//                ORDER BY r.On_Under";

		sql = $@"SELECT p.Shortdesc  AS Roadway_Name
      ,r.On_Under   AS On_Under
      ,r.Roadway_Gd AS r
  FROM Roadway r
  LEFT OUTER JOIN Paramtrs p
    ON (Lower(TRIM(p.Table_Name)) = 'roadway' AND
       Lower(TRIM(p.Field_Name)) = 'on_under' AND p.Parmvalue = r.On_Under)
 WHERE (r.Bridge_Gd = :theBridgeGd)
 ORDER By r.bridge_Gd,  r.On_Under;";

		loadingTable = "roadway_picklist";

		sql = sql.FormatSqlString().CleanSQLString();
		sql.CheckSyntax(true);

		var cmd = new OracleCommand()
		{
			CommandText = sql,
			CommandType = CommandType.Text,
			Connection = oraConn,
			BindByName = true
		};

		var parm = new OracleParameter()
		{
			ParameterName = @"theBridgeGd",
			OracleDbType = OracleDbType.Varchar2,
			Size = 32,
			Direction = ParameterDirection.Input,
			Value = bridge_gd

		};

		cmd.Parameters.Add(parm);
		using (var a = new OracleDataAdapter(cmd)) //*.CleanTrailingSemicolon()*/, GetOracleConnection()))
		{
			a.Fill(ds, "roadway_list");
		}

		ds.Tables["roadway_list"].Dump();
		endTime = DateTime.Now;
		diff = endTime.Subtract(beginTime);
		res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
		Console.WriteLine($"Loading {"roadway_list"} STARTED at {beginTime}");
		Console.WriteLine($"Loading {"roadway_list"} ENDED at {endTime}");
		Console.WriteLine($"Loading {"roadway_list"} took {res}");


		beginTime = DateTime.Now;

		sql = $@"SELECT i.Brkey
      ,To_Char(i.Inspdate, 'MM/DD/YYYY') || q'[ (]' ||
       To_Char(Nvl(i.Date_Entered, i.Inspdate), 'MM/DD/YYYY') || q'[)]' ||
       ' - ' || i.Inspkey || ' - ' || P1.Shortdesc || CASE
         WHEN Ki.Spinsptype = 3030 THEN
          '-LR'
         ELSE
          ''
       END || ' - ' || P2.Shortdesc AS rcb_text
      ,i.Inspkey
      ,i.Inspevnt_Gd As rcb_value
  FROM Inspevnt i
  LEFT OUTER JOIN Kdotblp_Inspections Ki
    ON i.Inspevnt_Gd = Ki.Inspevnt_Gd
  LEFT OUTER JOIN Paramtrs P1
    ON Lower(Trim(P1.Table_Name)) = 'inspevnt'
   AND Lower(Trim(P1.Field_Name)) = 'insptype'
   AND P1.Parmvalue = i.Insptype
  LEFT OUTER JOIN Paramtrs P2
    ON Lower(Trim(P2.Table_Name)) = 'inspevnt'
   AND Lower(Trim(P2.Field_Name)) = 'inspstat'
   AND P2.Parmvalue = i.Inspstat
 WHERE (i.Bridge_Gd = :theBridgeGd)
 ORDER BY i.Inspdate DESC, i.insptype, i.Inspkey ASC;";

		//q'[{seekBridgeGd}]'
		loadingTable = "inspevnt_picklist";

		sql.CheckSyntax(true);
		sql = sql.FormatSqlString().CleanSQLString();


		var picklistCmd = new OracleCommand()
		{
			CommandText = sql,
			CommandType = CommandType.Text,
			BindByName = true,
			Connection = oraConn
		};

		var oraBridgeGdParm = new OracleParameter()
		{
			ParameterName = @"theBridgeGd",
			Direction = ParameterDirection.Input,
			OracleDbType = OracleDbType.Varchar2,
			Size = 32,
			Value = bridge_gd
		};

		picklistCmd.Parameters.Add(oraBridgeGdParm);

		using (var a = new OracleDataAdapter(picklistCmd)) ///*.CleanTrailingSemicolon()*/, GetOracleConnection()))
		{
			//a.SuppressGetDecimalInvalidCastException = true;
			a.Fill(ds, "inspection_list");

		}
		ds.Tables["inspection_list"].Dump();
		endTime = DateTime.Now;
		diff = endTime.Subtract(beginTime);
		res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
		Console.WriteLine($"Loading {"inspection_list"} STARTED at {beginTime}");
		Console.WriteLine($"Loading {"inspection_list"} ENDED at {endTime}");
		Console.WriteLine($"Loading {"inspection_list"} took {res}");
		Console.WriteLine("");
		//		Session.Remove(KEY_BRIDGE_DATA_SET);
		//		Session[KEY_BRIDGE_DATA_SET] = ds;
		endTime = DateTime.Now;
		diff = endTime.Subtract(runBeginTime);
		res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
		Console.WriteLine($"Loading BridgeDataSet() STARTED at {runBeginTime}");
		Console.WriteLine($"Loading BridgeDataSet() ENDED at {endTime}");
		Console.WriteLine($"Loading BridgeDataSet()  took {res}");
		return (ok);
	}
	catch (System.Data.OleDb.OleDbException oleEx)
	{
		Console.WriteLine($@"OleDb Error loading the bridge DataSet table {loadingTable} for bridge_gd: {bridge_gd}" + Environment.NewLine + oleEx.GatherOleDbErrors());
		//FatalError($@"OleDb Error loading the bridge DataSet table {loadingTable} for bridge_gd: {bridge_gd}", oleEx);
		throw;
	}
	catch (OracleException oraEx)
	{
		Console.WriteLine($@"Oracle Error loading the bridge DataSet table {loadingTable} for bridge_gd: {bridge_gd}" + Environment.NewLine + oraEx.GatherOracleErrors());
		//FatalError($@"Oracle Error loading the bridge DataSet table {loadingTable} for bridge_gd: {bridge_gd}", oraEx);
		throw;
	}

	catch (Exception ex)
	{
		Console.WriteLine($@"Error loading the bridge DataSet table {loadingTable} for bridge_gd: {bridge_gd}" + Environment.NewLine + ex.GatherExceptionData());
		throw;
	}

}

var theBrKey = "000111115407081";
var theBridgeGd = "E0A35457AB424192AFF869F50A1CDD8A";
var oleCStr = @"Provider=OraOLEDB.Oracle; OLEDB.NET=True;Persist Security Info=False;User ID=KDOT_BLP;Password=eis3nh0wer;Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;Extended Properties='''';Connection Timeout=60;Connection Lifetime=3600;";
var oraCStr = @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer";




var loadedOk = LoadBridgeDataSet(theBrKey, theBridgeGd, oleCStr, oraCStr);
