<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <Namespace>System.Globalization</Namespace>
</Query>


OracleConnection con = new OracleConnection();
con.ConnectionString = "Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;Persist Security Info=True;User ID=KDOT_BLP;Password=eis3nh0wer;Connection Timeout=10;Connection Lifetime=180;Pooling=true;Min Pool Size=10;Max Pool Size=20;Incr Pool Size=5; Decr Pool Size=2;Statement Cache Size=200;";
con.Open();
OracleGlobalization SessionGlob = con.GetSessionInfo();
Console.WriteLine(SessionGlob.DateFormat);

// SetSessionInfo updates the Session with the new value
SessionGlob.DateFormat = "YYYY/MM/DD";
con.SetSessionInfo(SessionGlob);
Console.WriteLine("Date Format successfully changed for the session");
Console.WriteLine(SessionGlob.DateFormat);
SessionGlob.DateFormat = "DD-MON-YYYY";
con.SetSessionInfo(SessionGlob);
Console.WriteLine("Date Format successfully changed for the session");
Console.WriteLine(SessionGlob.DateFormat);
SessionGlob.DateFormat = "YYYY-MM-DD HH24:MI:SS";
Console.WriteLine(SessionGlob.DateFormat);
OracleCommand cmd = new OracleCommand("SELECT TO_DATE('1901-01-01 00:00:00') from dual", con);
cmd.Connection.OraOpenIfClosed(setDateFormat: true);
cmd.Connection.SetDateFormat();
SessionGlob = cmd.Connection.GetSessionInfo();
SessionGlob.Dump();
Console.WriteLine(SessionGlob.DateFormat);
cmd.ExecuteScalar().Dump();

con.SetSessionInfo(SessionGlob);
Console.WriteLine("Date Format successfully changed for the session");
Console.WriteLine(SessionGlob.DateFormat);
Console.WriteLine(SessionGlob.TimeStampFormat);

SessionGlob.DebugProperties(out string report);
report.Dump();

cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");
cmd.BindByName = true;
cmd.Connection = con;
var ok = DateTime.TryParse("1902-02-02 00:00:00", out var theDt);

cmd.Parameters.Add("the_fcinspdate", OracleDbType.Date).Value = theDt;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("YYYY/MM/DD HH:MI:SS");
var nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");

cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");
cmd.BindByName = true;
cmd.Connection = con;
var dateStr = "1902-12-02 00:00:00";

cmd.Parameters.Add("the_fcinspdate", OracleDbType.Varchar2, dateStr.Length).Value = dateStr;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("yyyy-mm-dd hh24:mi:ss");
nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");


CultureInfo enUS = new CultureInfo("en-US");

cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");
cmd.BindByName = true;
cmd.Connection = con;
dateStr = "1903-12-02 00:00:00";

ok = DateTime.TryParseExact(dateStr, enUS.DateTimeFormat.FullDateTimePattern, enUS, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out theDt);
theDt.Dump();
cmd.Parameters.Add("the_fcinspdate", OracleDbType.Date).Value = theDt;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("YYYY/MM/DD HH:MI:SS");


nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");

cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");
cmd.BindByName = true;

cmd.Connection = con;
dateStr = DateTime.Now.ToString();
dateStr.Dump();
enUS.DateTimeFormat.FullDateTimePattern.Dump();

ok = DateTime.TryParse(dateStr, out theDt ); //"s",DateTimeStyles.AllowWhiteSpaces|DateTimeStyles.AssumeLocal);
theDt.Dump();
cmd.Parameters.Add("the_fcinspdate", OracleDbType.Date).Value = theDt;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("YYYY/MM/DD HH:MI:SS");


nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");

dateStr = DateTime.Now.AddMonths(6).AddDays(5).ToString();
cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd",con);
cmd.Parameters.Add("the_fcinspdate", OracleDbType.Varchar2, dateStr.Length).Value =dateStr;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("YYYY/MM/DD HH:MI:SS");

dateStr.Dump();
nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");

dateStr = DateTime.Now.AddMonths(6).AddDays(5).FmtOraDbDateValue(new CultureInfo("en-GB"));
cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd", con);
cmd.Parameters.Add("the_fcinspdate", OracleDbType.Varchar2, dateStr.Length).Value = dateStr;
cmd.Parameters.Add("the_inspevnt_gd", OracleDbType.Varchar2, 32).Value = "9A34533B66C04A98A9D4EC6FA3C45B79";
cmd.Parameters.Dump();
cmd.Connection.OraOpenIfClosed();
cmd.Connection.SetDateFormat("YYYY/MM/DD HH:MI:SS");

dateStr.Dump();
nRows = cmd.ExecuteNonQuery();
Console.WriteLine($"Rows affected: {nRows}"); cmd = new OracleCommand($"UPDATE INSPEVNT SET FCLASTINSP=:the_fcinspdate where inspevnt_gd = :the_inspevnt_gd");

con.Close();
