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
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

var cacheName = "LINQPAD_TEST";
var dump = false;

var tName = "bridge";
var fName = "placecode";
var beginTime = DateTime.Now;
var endTime = DateTime.Now;
var diff = endTime.Subtract(beginTime);

var diffCopyToSum = diff;
var diffMergeNoTempSum = diff;
var diffForEachAddRowSum = diff;
var diffForEachImportRowSum = diff;

var res = "";

beginTime = DateTime.Now;
ParamtrsCache.LoadParamtrsCache(cacheName, @"Data Source=dt00en60.ksdot.org:1521/ESOADEV.WORLD;User ID=KDOT_BLP; Password=eis3nh0wer", true, true, @" WHERE p.TABLE_NAME = 'bridge' and p.FIELD_NAME IN ('district' , 'county', 'placecode' ) ");
endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LOAD CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);

beginTime = DateTime.Now;
var qry = from p in ParamtrsCache.GetParms()?.AsEnumerable()
		  where (p.Field<string>("TABLE_NAME") == tName && p.Field<string>("FIELD_NAME") == fName &&
				 p.Field<int>("ISACTIVE") == 1)
		  orderby p.Field<int>("ORDER_NUM"), p.Field<string>("PARMVALUE")
		  select p as ParamtrDtRow;

endTime = DateTime.Now;
diff = endTime.Subtract(beginTime);
res = string.Format("{0}: {1}:{2}.{3}.{4}", "LINQ QRY CACHE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
Console.WriteLine(res);
if (dump)
	qry.Dump();

Console.WriteLine(Environment.NewLine);

var i = 0;
for (i = 0; i < 5000; i++)
{

	if (dump)
	{
		Console.WriteLine(new string('-', 80));
		Console.WriteLine($"Iteration: {i + 1} ");
		Console.WriteLine(new string('-', 80));
		Console.WriteLine();
	}
	beginTime = DateTime.Now;
	var picklistDt = new ParamtrsDT($"{tName}_{fName}_picklist");
	DataTable table = qry.CopyToDataTable<ParamtrDtRow>();
	picklistDt.Merge(table);
	endTime = DateTime.Now;
	diff = endTime.Subtract(beginTime);
	diffCopyToSum += diff;
	if (dump)
	{
		res = string.Format("{0}: {1}:{2}.{3}.{4}", "COPYTO w/ MERGE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
		Console.WriteLine(res);
		picklistDt.Dump();
	}

	if (dump)
	{
		Console.WriteLine();
	}
	beginTime = DateTime.Now;
	picklistDt.Clear();
	picklistDt.Merge(qry.CopyToDataTable<ParamtrDtRow>());
	endTime = DateTime.Now;
	diff = endTime.Subtract(beginTime);
	diffMergeNoTempSum += diff;
	if (dump)
	{
		res = String.Format("{0}: {1}:{2}.{3}.{4}", "MERGE NO TEMP TABLE", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
		Console.WriteLine(res);
		picklistDt.Dump();
		Console.WriteLine();
	}

	beginTime = DateTime.Now;
	picklistDt.Clear();
	foreach (ParamtrDtRow r in qry.AsEnumerable())
		picklistDt.Rows.Add(r.ItemArray);
	endTime = DateTime.Now;
	diff = endTime.Subtract(beginTime);
	diffForEachAddRowSum += diff;
	res = String.Format("{0}: {1}:{2}.{3}.{4}", "FOREACH Rows.Add(r.ItemArray)", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
	if (dump)
	{
		Console.WriteLine(res);
		picklistDt.Dump();
		Console.WriteLine();
	}


	beginTime = DateTime.Now;
	picklistDt.Clear();
	foreach (ParamtrDtRow r in qry.AsEnumerable())
		picklistDt.ImportRow(r);
	endTime = DateTime.Now;
	diff = endTime.Subtract(beginTime);
	diffForEachImportRowSum += diff;

	if (dump)
	{
		res = String.Format("{0}: {1}:{2}.{3}.{4}", "FOREACH ImportRow(r)", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);

		Console.WriteLine(res);
		Console.WriteLine(new string('-', 80));
		Console.WriteLine();
		if (dump)
			picklistDt.Dump();
	}
}
if (dump)
{
	Console.WriteLine(new string('-', 80));
	Console.WriteLine();
}
Console.WriteLine($"Iterations: {i}");
Console.WriteLine($"COPYTO w/ MERGE AVG (ms): {diffCopyToSum.TotalMilliseconds / i}");
Console.WriteLine($"MERGE NO TEMP TABLE AVG (ms): {diffMergeNoTempSum.TotalMilliseconds / i}");
Console.WriteLine($"FOREACH ADD Rows.Add(r.ItemArray) AVG (ms): {diffForEachAddRowSum.TotalMilliseconds / i}");
Console.WriteLine($"FOREACH ImportRow(r) AVG (ms): {diffForEachImportRowSum.TotalMilliseconds / i}");

