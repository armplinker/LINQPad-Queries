<Query Kind="Program">
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

void Main()
{



	var x = System.DateTime.Now.ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
	x.Dump();
	var y = DateTime.Parse(x);
	y.Dump();
	var z = new DateTimeOffset(y).ToUnixTimeSeconds();
	z.Dump();
	var zz = new DateTimeOffset(y);
	zz.Dump();
	var blowback = DateTime.Parse(zz.ToString());
	blowback.Dump();
	var secs = zz.ToUnixTimeMilliseconds();
	secs.Dump();

	var ms = zz.ToUnixTimeSeconds();
	ms.Dump();

	x = System.DateTime.Now.ToUniversalTime().ToString("R");
	x.Dump();
	y = DateTime.Parse(x);
	y.Dump();
	z = new DateTimeOffset(y).ToUnixTimeSeconds();
	z.Dump();
	zz = new DateTimeOffset(y);
	zz.Dump();
	blowback = DateTime.Parse(zz.ToString());
	blowback.Dump();
	secs = zz.ToUnixTimeMilliseconds();
	secs.Dump();

	ms = zz.ToUnixTimeSeconds();
	ms.Dump();

	x = System.DateTime.Now.ToUniversalTime().ToString("s");
	x.Dump();
	y = DateTime.Parse(x);
	y.Dump();
	z = new DateTimeOffset(y).ToUnixTimeSeconds();
	z.Dump();
	zz = new DateTimeOffset(y);
	zz.Dump();
	blowback = DateTime.Parse(zz.ToString());
	blowback.Dump();
	secs = zz.ToUnixTimeSeconds();
	secs.Dump();

	ms = zz.ToUnixTimeMilliseconds();
	ms.Dump();


	x = System.DateTime.Now.ToString("s");
	x.Dump();
	y = DateTime.Parse(x);
	y.Dump();
	z = new DateTimeOffset(y).ToUnixTimeSeconds();
	z.Dump();

	zz = new DateTimeOffset(y);
	zz.Dump();
	blowback = DateTime.Parse(zz.ToString());
	blowback.Dump("blowback1");
	blowback.ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")).Dump("blowback2");

	secs = zz.ToUnixTimeSeconds();
	zz.Dump("raw");
	secs.Dump("secs");
	Console.WriteLine(DateTime.Parse((zz).ToString()).ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));

	ms = zz.ToUnixTimeMilliseconds();
	ms.Dump("msecs");
	Console.WriteLine(DateTime.Parse((zz).ToString()).ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
	Console.WriteLine($"msecs to dt: {UnixTimeStampToDateTime(ms).ToString("F", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))}");

	Console.WriteLine($"msecs to dt (HW):{ UnixTimeStampToDateTime((long)(1596286851767 + 20000))}");
	Console.WriteLine($"DateTimeOffset to DateTime: {DateTimeOffSetToDateTime(zz)}");
}
private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
{
	var UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

	UnixEpoch = UnixEpoch.AddMilliseconds(unixTimeStamp);
	return UnixEpoch;
}

public static DateTime DateTimeOffSetToDateTime(DateTimeOffset ts)
{
	return DateTime.Parse(ts.ToString());
}