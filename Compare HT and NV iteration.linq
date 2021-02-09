<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <Namespace>System.Collections.Specialized</Namespace>
</Query>

var sqlSample =
@"SELECT BRKEY, MAX(BRIDGE_GD) AS BRIDGE_GD FROM BRIDGE SAMPLE (75)
  GROUP BY BRKEY ORDER BY BRKEY";

var cmd = new OracleCommand()
{
	CommandText = sqlSample,
	CommandType = CommandType.Text,
	Connection = new OracleConnection()
	{
		ConnectionString = "Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD; User ID=KDOT_BLP; Password=eis3nh0wer;"
	}

};
var beginTime = DateTime.Now;


var dt = new DataTable();
var n = 0;
using (cmd)
{
	cmd.Connection.OraOpenIfClosed();
	n = cmd.FillDT(dt);
}

var nv = new NameValueCollection();

foreach (DataRow r in dt.Rows)
	nv.Add(r.Field<string>("brkey").ToString(), r.Field<string>("bridge_gd").ToString());

var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"NV LOAD STARTED at {beginTime}");
Console.WriteLine($"NV LOAD ENDED at {endTime}");
Console.WriteLine($"NV Load of {n} took {res}");

nv.Dump();
beginTime = DateTime.Now;
var i = 0;
double pct = 0.0;
foreach (string s in nv)
{
	i++;
	pct = i / nv.Count;
}
//Console.WriteLine("   {0,-10} {1}", s, nv[s]);

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"NV ITERATE STARTED at {beginTime}");
Console.WriteLine($"NV ITERATE ENDED at {endTime}");
Console.WriteLine($"NV ITERATE of {i} took {res}");
Console.WriteLine("");
Console.WriteLine("----------------------------");
Console.WriteLine("");
beginTime = DateTime.Now;
cmd = new OracleCommand()
{
	CommandText = sqlSample,
	CommandType = CommandType.Text,
	Connection = new OracleConnection()
	{
		ConnectionString = "Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD; User ID=KDOT_BLP; Password=eis3nh0wer;"
	}

};
dt.Clear();
using (cmd)
{
	cmd.Connection.OraOpenIfClosed();
	n = cmd.FillDT(dt);
}

var ht = new Hashtable();

foreach (DataRow r in dt.Rows)
	ht.Add(r.Field<string>("brkey").ToString(), r.Field<string>("bridge_gd").ToString());

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"HT LOAD STARTED at {beginTime}");
Console.WriteLine($"HT LOAD ENDED at {endTime}");
Console.WriteLine($"HT Load of {n} rows took {res}");

ht.Dump();
beginTime = DateTime.Now;
IDictionaryEnumerator ide = ht.GetEnumerator();
ide.Reset();
i = 0;
pct = 0.0;
while (ide.MoveNext())
{
	i++;
	pct = i / nv.Count;
	//Console.WriteLine("   {0,-10} {1}", ide.Key.ToString(), ide.Value.ToString());
}
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"HT ITERATE STARTED at {beginTime}");
Console.WriteLine($"HT ITERATE ENDED at {endTime}");
Console.WriteLine($"HT ITERATE of {i} rows took {res}");