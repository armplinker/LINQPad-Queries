<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <Namespace>System.Reflection</Namespace>
</Query>

void DisplayMethodInfo(MethodInfo[] methodInfo)
{
	// Display information for all methods.
	for (int i = 0; i < methodInfo.Length; i++)
	{
		var myMethodInfo = (MethodInfo)methodInfo[i];
		Console.WriteLine("\nThe name of the method is {0}.", myMethodInfo.Name);
	}
}

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

var beginTime = DateTime.Now;
PortalDataDictCache.LoadPortalDataDictCache(cacheName, cStr, true, true, string.Empty);
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);
var res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"DD CACHE LOAD (ConnectionString) STARTED at {beginTime}");
Console.WriteLine($"DD CACHE LOAD (ConnectionString) ENDED at {endTime}");
Console.WriteLine($"Load using ConnectionString took {res}");

var oraConn = new OracleConnection(cStr);
oraConn.OraOpenIfClosed();

beginTime = DateTime.Now;
PortalDataDictCache.LoadPortalDataDictCache(cacheName, oraConn, true, true, string.Empty);
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"DD CACHE LOAD (OracleConnection) STARTED at {beginTime}");
Console.WriteLine($"DD CACHE LOAD (OracleConnection) ENDED at {endTime}");
Console.WriteLine($"Load using OracleConnection took {res}");


//PortalDataDictCache.GetPortalDataDict().Dump();
beginTime = DateTime.Now;
PortalDataDictCache.GetPortalDataDict("bridge", "district").Dump();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"Get district dd entry took {res}");

PortalDataDictCache.GetPortalDataDict("bridge", "County").Dump();

beginTime = DateTime.Now;
PortalDataDictCache.GetPortalDataDict("005C").Dump();
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"Get nbi_id direct dd entry took {res}");

beginTime = DateTime.Now;
PortalDataDictCache.GetPortalDataDict("005C").Dump();

var methodName = @"LoadPortalDataDictCache";
Type myType = (typeof(PortalDataDictCache));
// Get the public methods.
MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);
Console.WriteLine("\nThe number of public methods is {0}.", myArrayMethodInfo.Length);
// Display all the methods.
DisplayMethodInfo(myArrayMethodInfo);

// Get the nonpublic methods.
MethodInfo[] myArrayMethodInfo1 = myType.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
Console.WriteLine("\nThe number of protected methods is {0}.", myArrayMethodInfo1.Length);
// Display information for all methods.
DisplayMethodInfo(myArrayMethodInfo1);
	
	//https://docs.microsoft.com/en-us/dotnet/api/system.type.getmethods?view=netcore-3.1
	//https://docs.microsoft.com/en-us/dotnet/api/system.reflection.bindingflags?view=netcore-3.1
	
	var bindingFlags = BindingFlags.Static |
								BindingFlags.ExactBinding |
								BindingFlags.InvokeMethod |
								BindingFlags.Public;
	
	var qry = from method in typeof(PortalDataDictCache).GetMethods(bindingFlags | BindingFlags.DeclaredOnly)
			  where (string.Equals(method.Name, methodName, StringComparison.InvariantCulture)) // exact match!
			  select method?.ToString();
	
	// it is not OK if the desired method does not exist for the template object - probable name typo or method has been removed.
	var enumerable = qry as string[] ?? qry.ToArray();
	
	if (!enumerable.Any())
		throw new InvalidOperationException($@"Attempt to invoke invalid PortalDataDictCache method {methodName}.  Please report this error to support.");
	
	
	bindingFlags = BindingFlags.Instance |
							BindingFlags.ExactBinding |
							BindingFlags.InvokeMethod |
							BindingFlags.Public;
	methodName = "Save";
	qry = from method in typeof(IMControl).GetMethods(bindingFlags)
		  where (string.Equals(method.Name, methodName, StringComparison.InvariantCulture)) // exact match!
		  select method?.ToString();
	
	// it is not OK if the desired method does not exist for the template object - probable name typo or method has been removed.
	enumerable = qry as string[] ?? qry.ToArray();
	
	if (!enumerable.Any())
		throw new InvalidOperationException($@"Attempt to invoke invalid IMControl method {methodName}.  Please report this error to support.");
	
	Console.WriteLine($"Method name {methodName} was found on class { typeof(IMControl)}");

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = String.Format("{0}:{1}:{2}.{3}", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine($"Get type methods query took {res}");


//foreach (var col in PortalDataDictCache.GetPortalDataDict().Columns)
//	col.Dump();