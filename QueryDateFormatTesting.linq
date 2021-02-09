<Query Kind="Statements">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
</Query>

//public static DateTime? SetOraDbDateValue(this string theDate, bool useExact = false, string dateFmt = "", CultureInfo culture = null, DateTimeFormatInfo dtFormatInfo = null, DateTimeStyles styles = DateTimeStyles.None)


DateTime nowDt = System.DateTime.Now;

var dateStr = "1905-01-01 23:59:59";

var ok = false;

dateStr.SetOraDbDateValue().Dump();
dateStr.SetOraDbDateValue( ).Dump();
dateStr.SetOraDbDateValue( ).Dump();
var cult = System.Globalization.CultureInfo.CurrentCulture;
var x = nowDt.ToString(cult.DateTimeFormat); //.SetOraDbDateValue(useExact: true, culture: cult) ;
x.Dump();
cult = System.Globalization.CultureInfo.GetCultureInfo("en-GB");

// cult.Dump();
// cult.DateTimeFormat.Dump();
var x1 = nowDt.ToString(cult.DateTimeFormat);
x1.Dump();
x1 = nowDt.AddMonths(4).AddHours(6).ToString(cult.DateTimeFormat.SortableDateTimePattern);
x1.Dump();
x = nowDt.AddMonths(4).AddHours(6).FmtOraDbDateValue();
x.Dump();
