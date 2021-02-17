<Query Kind="Program">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Progress\Telerik Reporting R1 2021\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <appSettings>
          <add key="allowable_support_doc_extensions" value=".pdf" />
          <add key="allowable_support_doc_extensions_mimetypes" value="application/pdf" />
          <!--<add key="allowable_image_extensions" value=".pdf" />
      <add key="allowable_image_mimetypes" value="application/pdf" />-->
          <add key="allowable_nbi_extensions" value=".nbi" />
          <add key="allowable_nbi_extensions_mimetypes" value=".nbi" />
          <!-- ARMarshall, ARM LLC - 20180501 - a metric version of this also exists -->
          <!-- renamed to be 11g compatible 20181004 -->
          <add key="nbi_export_excel_data_object" value="mv_nbi_export_excelsheet" />
          <!-- 20160421 changed name -->
          <add key="crystal_rpt_files_home" value="~/Crystal" />
          <!--Standard downloadable blank forms-->
          <!-- update the filename as desired and post that version to designated subfolder -->
          <!-- there is no need to delete the old versions -->
          <add key="fc-blank-form-pdf-url" value="~/SupportDocuments/FC/Forms/FractureCriticalBlankForm-V2020-rev1.0.pdf" />
          <add key="scour-report-blank-form-url" value="~/SupportDocuments/Scour/Forms/2018 Item 113 Scour Vulnerability Justification Fillable Form.pdf" />
          <add key="scour-report-POA-ORIGINAL-blank-form-url" value="~/SupportDocuments/Scour/Forms/2018 Scour Plan of Action (POA) Fillable Forms.pdf" />
          <add key="scour-report-POA-UPDATED-blank-form-url" value="~/SupportDocuments/Scour/Forms/POA Update Log Fillable Form.pdf" />
          <add key="scour-report-POA-RETIRED-blank-form-url" value="~/SupportDocuments/Scour/Forms/POA Retirement Fillable Form.pdf" />
          <add key="load-rating-blank-form-url" value="~/SupportDocuments/LoadRatings/LoadRatingBlankForm-V2020-rev1.0.xlsx" />
          <add key="p-and-h-blank-form-pdf-url" value="~/SupportDocuments/Specials/Pin_And_Hanger/Forms/P_and_H_BlankForm-V2020-rev1.0.pdf" />
          <!-- where upload files are staged by the upload engine-->
          <add key="nbi_temp_uploads_folder" value="~/_tmp/" />
          <!-- ARMarshall ARM LLC 20160420 - added trailing slash here to follow convention of other settings such as support_doc_home_uw -->
          <add key="support_doc_home" value="~/SupportDocuments/" />
          <add key="support_doc_home_nbi" value="~/SupportDocuments/NBI/" />
          <add key="support_doc_home_nbi_photos" value="~/SupportDocuments/NBI/Photos/" />
          <add key="support_doc_home_nbi_reports" value="~/SupportDocuments/NBI/Reports/" />
          <!--FC tree -->
          <add key="support_doc_home_fc" value="~/SupportDocuments/FC/" />
          <!-- downloadable FC forms -->
          <add key="support_doc_home_fc_forms" value="~/SupportDocuments/FC/Forms/" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_fc_photos" value="~/SupportDocuments/FC/Photos/" />
          <!-- report target as of 20200930 -->
          <add key="support_doc_home_fc_reports" value="~/SupportDocuments/FC/Reports/" />
          <add key="support_doc_home_fc_other" value="~/SupportDocuments/FC/Reports/" />
          <!--UW tree -->
          <add key="support_doc_home_uw" value="~/SupportDocuments/UW/" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_uw_forms" value="~/SupportDocuments/UW/Forms" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_uw_photos" value="~/SupportDocuments/UW/Photos/" />
          <add key="support_doc_home_uw_reports" value="~/SupportDocuments/UW/Reports/" />
          <add key="support_doc_home_uw_general" value="~/SupportDocuments/UW/General/" />
          <!-- was 'other'-->
          <!-- only target as of 20200930 -->
          <!--these OS optionsar eare kept to support the old locations-->
          <add key="support_doc_home_os" value="~/SupportDocuments/OS/" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_os_forms" value="~/SupportDocuments/OS/Forms" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_os_photos" value="~/SupportDocuments/OS/Photos/" />
          <add key="support_doc_home_os_reports" value="~/SupportDocuments/OS/Reports/" />
          <add key="support_doc_home_os_other" value="~/SupportDocuments/OS/General/" />
          <add key="support_doc_home_specials_other_special_general" value="~/SupportDocuments/Specials/Other_Special/General" />
          <add key="support_doc_home_specials_other_special_reports" value="~/SupportDocuments/Specials/Other_Special/Reports/" />
          <!-- form placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_specials_other_special_forms" value="~/SupportDocuments/Specials/Other_Special/Forms/" />
          <!--<add key="support_doc_home_specials_other_special" value="~/SupportDocuments/Specials/Other_Special/Other/" />-->
          <add key="support_doc_home_specials_other_special_photos" value="~/SupportDocuments/Specials/Other_Special/Photos/" />
          <add key="support_doc_home_specials_damage" value="~/SupportDocuments/Specials/Damage_Reports/" />
          <add key="support_doc_home_specials_damage_reports" value="~/SupportDocuments/Specials/Damage_Reports/Reports/" />
          <add key="support_doc_home_specials_damage_other" value="~/SupportDocuments/Specials/Damage_Reports/Other/" />
          <add key="support_doc_home_specials_damage_photos" value="~/SupportDocuments/Specials/Damage_Reports/Photos/" />
          <!-- placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_specials_damage_forms" value="~/SupportDocuments/Specials/Damage_Reports/Forms/" />
          <!--SCOUR-->
          <add key="support_doc_home_scour" value="~/SupportDocuments/Scour/" />
          <add key="support_doc_home_scour_general" value="~/SupportDocuments/Scour/General/" />
          <add key="support_doc_home_scour_stability" value="~/SupportDocuments/Scour/Stability/" />
          <add key="support_doc_home_scour_app_plans" value="~/SupportDocuments/Scour/AppPlans/" />
          <!-- Home directory for Original Plans of Action - changed key name appending poa 20160420 for readability -->
          <add key="support_doc_home_scour_original_poa" value="~/SupportDocuments/Scour/OrgPlans/" />
          <!-- Home directory for Amended/Updated and Retired Plans of Action -->
          <add key="support_doc_home_scour_updated_poa" value="~/SupportDocuments/Scour/AppPlans/" />
          <add key="support_doc_home_scour_retired_poa" value="~/SupportDocuments/Scour/AppPlans/" />
          <add key="support_doc_home_scour_forms" value="~/SupportDocuments/Scour/Forms/" />
          <add key="support_doc_home_scour_photos" value="~/SupportDocuments/Scour/Photos/" />
          <!--Allowable extensions for scour documents -->
          <add key="allowable_scour_summary_doc_extensions" value=".pdf,.xls,.xlsx,.docx,.doc" />
          <add key="allowable_scour_summary_doc_extensions_mimetypes" value="application/pdf, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword" />
          <!-- Home directory for Load Ratings -->
          <add key="support_doc_home_load_rating" value="~/SupportDocuments/LoadRatings/" />
          <add key="support_doc_home_load_rating_general" value="~/SupportDocuments/LoadRatings/General/" />
          <!--and other-->
          <add key="support_doc_home_load_rating_forms" value="~/SupportDocuments/LoadRatings/Forms/" />
          <add key="support_doc_home_load_rating_summary" value="~/SupportDocuments/LoadRatings/SummaryReports/" />
          <add key="support_doc_home_load_rating_bridgedata" value="~/SupportDocuments/LoadRatings/BridgeData/" />
          <add key="support_doc_home_load_rating_field_assessments" value="~/SupportDocuments/LoadRatings/FieldAssessments/" />
          <add key="support_doc_home_load_rating_plans_and_others" value="~/SupportDocuments/LoadRatings/Plans/" />
          <add key="support_doc_home_load_rating_bridge_models" value="~/SupportDocuments/LoadRatings/BridgeModels/" />
          <add key="support_doc_home_load_rating_photos" value="~/SupportDocuments/LoadRatings/Photos/" />
          <!-- UPDATED 20180918 to support additional load rating document types -->
          <add key="allowable_lr_blank_form_extensions" value=".pdf,.xlsx,.xls,.docx,.doc" />
          <add key="allowable_lr_blank_form_extensions_mimetypes" value="application/pdf, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword" />
          <add key="allowable_lr_summary_doc_extensions" value=".pdf,.xlsx,.xls,.docx,.doc" />
          <add key="allowable_lr_summary_doc_extensions_mimetypes" value="application/pdf, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword" />
          <add key="allowable_lr_field_assessment_doc_extensions" value=".pdf,.xls,.xlsx,.doc,.docx" />
          <add key="allowable_lr_field_assessment_doc_extensions_mimetypes" value="application/pdf, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword" />
          <add key="allowable_lr_plans_and_other_doc_extensions" value=".pdf,.xls,.xlsx,.doc,.docx" />
          <add key="allowable_lr_plans_and_other_doc_extensions_mimetypes" value="application/pdf, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword" />
          <add key="allowable_image_extensions" value=".gif,.jpg,.jpeg,.jpe,.png,.bmp,.tif,.tiff" />
          <add key="allowable_image_extensions_mimetypes" value="image/gif, image/jpg, image/png, image/bmp, image/tiff" />
          <add key="allowable_bridge_model_extensions" value=".xml,.xlsx,.xls,.csv" />
          <add key="allowable_bridge_model_extensions_mimetypes" value="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" />
          <!-- Critical findings -->
          <add key="support_doc_home_critical_findings" value="~/SupportDocuments/CritFinds/" />
          <add key="support_doc_home_critical_findings_general" value="~/SupportDocuments/CritFinds/General" />
          <!-- Bridge Plans -->
          <!--NOT NECESSARILY LR PROGRAM PLANS which may be located as noted above in key support_doc_home_load_plans_and_others-->
          <add key="support_doc_home_existing_plans" value="~/SupportDocuments/ExstPlans/" />
          <add key="support_doc_home_existing_plans_general" value="~/SupportDocuments/ExstPlans/General" />
          <!-- pin and hange inspection types as of 20200628 -->
          <add key="support_doc_home_specials_pin_and_hanger" value="~/SupportDocuments/Specials/Pin_And_Hanger/" />
          <add key="support_doc_home_specials_pin_and_hanger_other" value="~/SupportDocuments/Specials/Pin_And_Hanger/Other/" />
          <add key="support_doc_home_specials_pin_and_hanger_reports" value="~/SupportDocuments/Specials/Pin_And_Hanger/Reports/" />
          <!-- forms placeholder not supported for upload as of 20200930 -->
          <add key="support_doc_home_specials_pin_and_hanger_forms" value="~/SupportDocuments/Specials/Pin_And_Hanger/Forms/" />
          <add key="support_doc_home_specials_pin_and_hanger_photos" value="~/SupportDocuments/Specials/Pin_And_Hanger/Photos/" />
          <!-- Photos of a bridge-->
          <add key="support_doc_home_photos" value="~/SupportDocuments/Photos/" />
          <!-- Photos of a bridge-->
          <add key="support_doc_home_photos_general" value="~/SupportDocuments/Photos/General" />
          <!-- QAQC reports -->
          <add key="support_doc_home_QAQC" value="~/SupportDocuments/QAQC/" />
          <!-- QAQC reports -->
          <add key="support_doc_home_QAQC_General" value="~/SupportDocuments/QAQC/General" />
          <!-- Credentials documents-->
          <add key="credential_documents_home" value="~/SupportDocuments/CredentialDocuments/" />
        </appSettings>
      </configuration>
    </Content>
  </AppConfig>
</Query>

// apply a method to every item in IEnumerable<T> collectin
public static class PathExtensions
{
	public static IEnumerable<T> SetValue<T>(this IEnumerable<T> items, Action<T>
		 updateMethod)
	{
		foreach (T item in items)
		{
			updateMethod(item);
		}
		return items;
	}
}

// data items for a document folder type
public class DocFolder
{
	public string MetaDataGuid { get; set; }
	// ignore the relationship codes.  We only want the string document types.
	[JsonIgnore]
	public int Id { get; set; } //1100
	[JsonIgnore]
	public int ParentId { get; set; } //11

	public int Level { get; set; }  // 0, 1, 2, 3 ...
	public string DocType { get; set; } // "1100" - A FC General Document Folder .../11/1100...
	public string ParentDocType { get; set; } // "11"  - A  FC Documents Root Folder .../11/...
	public string DocFolderName { get; set; }
	public string DocFolderDescription { get; set; } // about text	
	public string DocFolderPath { get; set; }
	public string AppSettingsKeyName;
	public string AppSettingsValue;
	public string AppSettingsFolderPath { get; set; }
	public List<DocFolder> DocSubFolder { get; set; }

	public DocFolder()
	{
		DocSubFolder = new List<DocFolder>();
	}

}

public XmlNode GetAppString(string name1, string name2, string settingValue)
{
	name1 = name1.ToLower();
	name2 = name2.ToLower();



	if (!string.IsNullOrEmpty(name2))
	{
		name1 = name1.ToLower().Trim().Replace("general", "")
					.Replace("reports", "")
					.Replace("image", "")
					.Replace("form_files", "")
					.Replace("inspection", "")
					.Replace("underwater", "uw")
					.Replace("fracture_critical", "fc")
					.Replace("other_special", "spi_os")
					.Replace("pin_and_hanger", "spi_ph")
					.Replace("critical_findings", "cif")
					.Replace("specific_design_plans", "plans")
					.Replace("damage_and_accident_investigation", "spi_dmg")
					.Replace("load_rating_program", "lr")
					.Replace("plans_of_action", "")
					.Replace("113", "")
					.Replace("scour_program", "scour")
					.Replace("bridge", "br")
					.Replace("root", "")
					.Replace("image files", "img")
					.Replace("files", "")
					.Replace("documents", "docs").TrimEnd('_').TrimStart('_');

	}

	var stripCharsPattern = @"(?i)(?<chars>[\W.,;_@_\- -[\\/]])+|(?<slashes>[\\/])+";
	var stripCharsReplace = @"_";
	string key = Regex.Replace($"{name1}_{name2}".Trim(),stripCharsPattern ,stripCharsReplace,RegexOptions.IgnoreCase).TrimEnd('_').TrimStart('_').ToLower();
	string appStringFmt = $"<add key=\"fldr_{{0}}\" value=\"{{1}}\" />";

	XmlDocument doc = new XmlDocument();
	doc.LoadXml(string.Format(appStringFmt, key, settingValue));
	XmlNode newNode = doc.DocumentElement;
	return (newNode);

}

// return a JSON string of folder definitions and program bits
public string GetFolderSubFolderAppSettings()
{
	string json = string.Empty;
	string jsonRoot = "folders";
	var dt = GenerateFolderTable();

	DataTable dtFolders = GenerateFolderTable();

	Dictionary<int, DocFolder> dict =
	dtFolders.Rows.Cast<DataRow>()
			 .Select(r => new DocFolder
			 {
				 Level = r.Field<int>("LEVEL"),
				 Id = r.Field<int>("RESOURCE_ID"),
				 ParentId = r.Field<int>("PARENT_ID"),
				 DocType = r.Field<int>("RESOURCE_ID").ToString(),
				 ParentDocType = r.Field<int>("PARENT_ID").ToString(),
				 DocFolderName = ((r.Field<int>("LEVEL") == 0) ? string.Empty :
				 string.Concat(((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderName.ToString())),
				 DocFolderDescription = ((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderDescription.ToString(),
				 DocFolderPath = string.Empty,
				 MetaDataGuid = Guid.NewGuid().BrMGuid(),
				 AppSettingsKeyName = ((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderDescription.ToString().Replace(" ", "_").Replace("___", "_").Replace("__", "_").Replace("-", "_"),
				 AppSettingsValue = ((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderName.ToString(),
				 AppSettingsFolderPath = string.Empty
			 })
			.ToDictionary(m => m.Id);


	List<DocFolder> DocFolders = new List<DocFolder>();

	foreach (var kvp in dict)
	{
		List<DocFolder> folder = DocFolders;
		DocFolder item = kvp.Value;
		if (item.ParentId >= 0)
		{
			folder = dict[item.ParentId].DocSubFolder;
		}
		var serialize = "";
		
		var regexWinBackSlashPattern = @"[\\]+";
		var replacePattern = @"/";
		var stripCharsPattern =  @"(?i)(?<chars>[\W.,;_@_\- -[\\/]])+|(?<slashes>[\\/])+";
		var stripCharsReplace = @"_";
		
		switch (item.Level)
		{
			case 0:
				item.DocFolderPath = "/";
				item.AppSettingsFolderPath = string.Empty;
				break;

			case 1:
				{
					item.DocFolderPath = Regex.Replace(string.Concat("/", item.DocFolderName, "/"),regexWinBackSlashPattern, replacePattern,RegexOptions.IgnoreCase);
					serialize = Newtonsoft.Json.JsonConvert.SerializeXmlNode(GetAppString(item.AppSettingsKeyName, string.Empty,  item.DocFolderPath ), Newtonsoft.Json.Formatting.None, true);
					item.AppSettingsFolderPath = serialize;
					break;
				}
			case 2:
				{
					item.DocFolderPath =  Regex.Replace(string.Concat("/", dict[item.ParentId].DocFolderName, "/", item.DocFolderName)
					, regexWinBackSlashPattern
					, replacePattern,RegexOptions.IgnoreCase);
					serialize = Newtonsoft.Json.JsonConvert.SerializeXmlNode( 
					GetAppString(string.Concat( 
					 Regex.Replace(
					 dict[item.ParentId].DocFolderDescription.Trim(), stripCharsPattern					
					 , stripCharsReplace
					 , RegexOptions.IgnoreCase)
					 .ToLower()
					 .TrimEnd('_')
					 .TrimStart('_'), stripCharsReplace , item.AppSettingsKeyName).ToLower(), Regex.Replace(item.DocFolderName.ToLower().Trim(),stripCharsPattern,stripCharsReplace).ToLower(), string.Concat(item.DocFolderPath, "/")), Newtonsoft.Json.Formatting.None, true);
					item.AppSettingsFolderPath = serialize;
					break;

				}
		}
		serialize.Dump();


		folder.Add(item);

	}

	json = $"{{  \"{jsonRoot}\": {JsonConvert.SerializeObject(DocFolders, Newtonsoft.Json.Formatting.Indented)} {Environment.NewLine} }} ";
	return json;
}
//
//public DataTable CreateBridgeFolderDefs(string dataTableName = "", string docRootFolder = "", string adminFolderPath = "", string brKey = "", string brGd = "")
//{
//	DataTable theDt = new DataTable(dataTableName ?? "FolderDefinitions");
//
//	//theDt.TableName = "FolderDefinitions";
//
//	// not JSON fields
//	theDt.Columns.Add("RESOURCE_ID", typeof(int));
//	theDt.Columns.Add("PARENT_ID", typeof(int));
//	theDt.PrimaryKey = new DataColumn[] { theDt.Columns["RESOURCE_ID"], theDt.Columns["PARENT_ID"] };
//
//	// JSON fields
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "LEVEL",
//		Unique = false,
//		AllowDBNull = false,
//		DataType = typeof(int)
//	});
//
//
//
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "DOCTYPE",
//		Unique = true,
//		AllowDBNull = false,
//		DataType = typeof(string)
//
//	}
//		);
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "PARENTDOCTYPE",
//		Unique = false,
//		AllowDBNull = true,
//		DataType = typeof(string)
//
//	});
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "FOLDERNAME",
//		Unique = false,
//		AllowDBNull = false,
//		DataType = typeof(string)
//
//	});
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "PARENTFOLDERNAME",
//		Unique = false,
//		AllowDBNull = false,
//		DataType = typeof(string)
//
//	});
//
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "FOLDERPATH",
//		Unique = false,
//		AllowDBNull = false,
//		DataType = typeof(string)
//	});
//
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "FOLDERDESCRIPTION",
//		Unique = false,
//		AllowDBNull = false,
//		DataType = typeof(string)
//	});
//
//	theDt.Columns.Add(new DataColumn()
//	{
//		ColumnName = "METADATAGUID",
//		Unique = true,
//		AllowDBNull = false,
//		DataType = typeof(string)
//	});
//
//	return theDt;
//}

private DataTable GenerateFolderTable(string dataTableName = "", string defFileName = "")
{
	try
	{
		//if (!System.IO.File.Exists(defFileName)
		//{
		//	throw new ArgumentException($@"File {defFileName} not found.");
		//}

		var theDt = new DataTable(dataTableName ?? "FolderTree");

		theDt.Columns.Add(new DataColumn()
		{
			ColumnName = "LEVEL",
			Unique = false,
			AllowDBNull = false,
			DataType = typeof(int)
		});

		theDt.Columns.Add("RESOURCE_ID", typeof(int));

		theDt.Columns.Add("PARENT_ID", typeof(int));

		theDt.Columns.Add(new DataColumn()
		{
			ColumnName = "FOLDER_DEFINITION",
			Unique = false,
			AllowDBNull = false,
			DataType = typeof(string)
		});

		theDt.Columns.Add(new DataColumn()
		{
			ColumnName = "BRIDGE_FOLDER", // true or false if this is a folder containing bridge-specific (inspection-specific) documents
			Unique = false,
			AllowDBNull = false,
			DefaultValue = true,
			DataType = typeof(bool),
			Caption="BRIDGE_FOLDER"
		});
		
		// General Types
		string BridgeFoldersRootDef = JsonConvert.SerializeObject(new { folderName = "bridge", parentFolderName = "BridgeIdentifier", folderDescription = "Bridge Folders Root" });
		string FormFoldersRootDef = JsonConvert.SerializeObject(new { folderName = "formtype", parentFolderName = "forms", folderDescription = "Form Folders Root" });
		string NBIRootDef = JsonConvert.SerializeObject(new { folderName = "NBI", parentFolderName = "", folderDescription = "NBI Inspection Root" });
		string FCInspsRootDef = JsonConvert.SerializeObject(new { folderName = "SPI/FC", parentFolderName = "", folderDescription = "Fracture Critical Inspection Root" });
		string UWInspsRootDef = JsonConvert.SerializeObject(new { folderName = "SPI/UW", parentFolderName = "", folderDescription = "Underwater Inspection Root" });
		string SPI_OS_RootDef = JsonConvert.SerializeObject(new { folderName = "SPI/OS", parentFolderName = "", folderDescription = "Other Special Inspection Root" });
		string SPI_DMG_RootDef = JsonConvert.SerializeObject(new { folderName = "SPI/DMG", parentFolderName = "", folderDescription = "Damage and Accident Investigation Root" });
		string SPI_PH_RootDef = JsonConvert.SerializeObject(new { folderName = "SPI/PH", parentFolderName = "", folderDescription = "Pin and Hanger Inspection Root" });
		string BridgeDesignPlans_RootDef = JsonConvert.SerializeObject(new { folderName = "DSGN", parentFolderName = "", folderDescription = "Bridge-Specific Design Plans Root" });
		string ScourRootDef = JsonConvert.SerializeObject(new { folderName = "SCOUR", parentFolderName = "", folderDescription = "Scour Program Documents Root" });
		string LoadRatingsRootDef = JsonConvert.SerializeObject(new { folderName = "LR", parentFolderName = "", folderDescription = "Load Rating Program Documents Root" });
		string CriticalFindingsRootDef = JsonConvert.SerializeObject(new { folderName = "CIF", parentFolderName = "", folderDescription = "Critical Findings Inspection Documents Root" });
		string FormsTemplatesRootDef = JsonConvert.SerializeObject(new { folderName = "FORMS", parentFolderName = "", folderDescription = "Forms And Templates Root" });
		// Subtypes
		string GeneralSubfolderDef = JsonConvert.SerializeObject(new { folderName = "GEN", folderDescription = "General" });
		string ReportsSubfolderDef = JsonConvert.SerializeObject(new { folderName = "RPT", folderDescription = "Reports" });
		string ImagesSubfolderDef = JsonConvert.SerializeObject(new { folderName = "PIX", folderDescription = "Image Files" });
		string FormsSubfolderDef = JsonConvert.SerializeObject(new { folderName = "FRM", folderDescription = "Form Files" });
		string Scour113ReportsSubfolderDef = JsonConvert.SerializeObject(new { folderName = "113", folderDescription = "113 Reports" });
		// all scour POA files go to the same folder
		string ScourOriginalPOASubfolderDef = JsonConvert.SerializeObject(new { folderName = "POA", folderDescription = "Plans of Action - Original" });
		string ScourAmendedPOASubfolderDef = JsonConvert.SerializeObject(new { folderName = "POA", folderDescription = "Plans of Action - Amended" });
		string ScourRetiredPOASubfolderDef = JsonConvert.SerializeObject(new { folderName = "POA", folderDescription = "Plans of Action - Retired" });

		// plan subtypes
		string CADDSubfolderDef = JsonConvert.SerializeObject(new { folderName = "DRWG", folderDescription = "CADD Drawings - electronic" });
		string PlansSubfolderDef = JsonConvert.SerializeObject(new { folderName = "PLANS", folderDescription = "Scanned plans - static" });
		string LRFieldInvestigationsTypeDef = JsonConvert.SerializeObject(new { folderName = "FLDINV", folderDescription = "Field Investigation Reports" });
		string LRBridgeStructuralModels = JsonConvert.SerializeObject(new { folderName = "MODEL", folderDescription = "Bridge Structural Models" });

		string PhotosFolderDef = JsonConvert.SerializeObject(new { folderName = "PHOTOS", folderDescription = "PHOTOS not categorized" });
		string QAQCFolderDef = JsonConvert.SerializeObject(new { folderName = "QAQC", folderDescription = "QAQC documents root" });




		theDt.Rows.Add(new object[4] { 0, 0, -1, /* "10","",*/   BridgeFoldersRootDef });
		// the codes here are the same as DOC_TYPE_KEY and DOC_SUBTYPE_KEY, so we can calculate those from the integers.
		theDt.Rows.Add(new object[4] { 1, 10, 0,  /* "10","",*/   NBIRootDef });
		theDt.Rows.Add(new object[4] { 2, 1000, 10,  /* "1000","10",*/    GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1010, 10, /* "1010", "10",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1088, 10,  /*  "1088","10",*/ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1099, 10,  /*  "1099","10",*/  FormsSubfolderDef , false});

		theDt.Rows.Add(new object[4] { 1, 11, 0,  /*  "11","", */ FCInspsRootDef });
		theDt.Rows.Add(new object[4] { 2, 1100, 11,  /*  "1100","11", */  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1110, 11,  /*  "1110","11",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1188, 11,  /*   "11","1188",*/  ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1199, 11,   /*  "1199","11", */ FormsSubfolderDef, false });

		theDt.Rows.Add(new object[4] { 1, 12, 0,    /*  "12","",*/ UWInspsRootDef });
		theDt.Rows.Add(new object[4] { 2, 1200, 12,  /* "1200","12", */  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1210, 12, /*  "1210", "12", */  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1288, 12,  /*  "1288","12",*/  ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1299, 12, /* "1299", "12", */ FormsSubfolderDef , false});

		theDt.Rows.Add(new object[4] { 1, 30, 0,    /* "30","",*/ SPI_OS_RootDef });
		theDt.Rows.Add(new object[4] { 2, 3000, 30, /* "3000", "30",*/  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 3010, 30,  /*  "3010", "30",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 3088, 30, /*   "3088","30",*/  ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 3099, 30,  /*  "3099", "30",*/  FormsSubfolderDef, false});

		theDt.Rows.Add(new object[4] { 1, 14, 0,   /* "14","", */ ScourRootDef });
		theDt.Rows.Add(new object[4] { 2, 1400, 14,  /* "1410", "14",*/  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1410, 14,  /* "1410", "14",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1420, 14, /*   "1420", "14",*/  Scour113ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1430, 14,  /*  "1430","14", */ ScourOriginalPOASubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1435, 14, /*   "1435","14", */ ScourAmendedPOASubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1440, 14,  /*  "1440","14",*/  ScourRetiredPOASubfolderDef });

		theDt.Rows.Add(new object[4] { 2, 1488, 14,  /*  "1488","14",*/  ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1496, 14, /* "1496", "14",*/ FormsSubfolderDef, false });
		theDt.Rows.Add(new object[5] { 2, 1497, 14, /* "1497", "14",*/ FormsSubfolderDef, false });
		theDt.Rows.Add(new object[5] { 2, 1498, 14, /* "1498", "14",*/ FormsSubfolderDef, false });
		theDt.Rows.Add(new object[5] { 2, 1499, 14, /* "1499", "14",*/ FormsSubfolderDef, false });
	
		theDt.Rows.Add(new object[4] { 1, 15, 0,  /*"15", "",*/ CriticalFindingsRootDef });
		theDt.Rows.Add(new object[4] { 2, 1500, 15, /*  "1500", "15",*/  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1510, 15,  /*"1510", "15", */  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1588, 15, /*  "1588", "15", */ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1599, 15,  /* "1599", "15",*/ FormsSubfolderDef , false});

		theDt.Rows.Add(new object[4] { 1, 16, 0, /* "16", "", */ LoadRatingsRootDef });
		theDt.Rows.Add(new object[4] { 2, 1600, 16,   /*"16", "1600",*/  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1610, 16,  /* "16", "1610",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1620, 16, /*  "16", "1620", */ LRFieldInvestigationsTypeDef });
		theDt.Rows.Add(new object[4] { 2, 1630, 16,   /*"16", "1630", */ LRBridgeStructuralModels });
		theDt.Rows.Add(new object[4] { 2, 1688, 16, /*  "16", "1688",*/  ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1699, 16, /* "16", "1699",*/ FormsSubfolderDef, false });

		theDt.Rows.Add(new object[4] { 1, 17, 0, /* "17", "",*/ BridgeDesignPlans_RootDef });
		theDt.Rows.Add(new object[4] { 2, 1700, 17, /*   "1700","17", */  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1710, 17, /*  "1710","17",  */  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1720, 17,  /*  "1720","17",*/  CADDSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 1788, 17, /*   "1788","17", */  PlansSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 1799, 17,  /*  "1799","17",*/  FormsSubfolderDef, false });

		theDt.Rows.Add(new object[4] { 1, 40, 0, /* "40","", */ SPI_PH_RootDef });
		theDt.Rows.Add(new object[4] { 2, 4000, 40,  /* "4000",  "40",*/  GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 4010, 40,  /* "4010", "40",*/  ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 4088, 40,   /* "4088","40", */ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 4099, 40,  /*  "4099","40",*/ FormsSubfolderDef, false });

		theDt.Rows.Add(new object[4] { 1, 50, 0,   /*  "50", "", */ SPI_DMG_RootDef });
		theDt.Rows.Add(new object[4] { 2, 5000, 50,  /*  "5000", "50",*/ GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 5010, 50,  /*  "5010", "50", */ ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 5088, 50, /*   "5088", "50", */ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 5099, 50,   /* "5099", "50",*/ FormsSubfolderDef, false });

		theDt.Rows.Add(new object[4] { 1, 80, 0,   /*  "80", "", */ PhotosFolderDef });
		theDt.Rows.Add(new object[4] { 2, 8000, 80,   /*  "8010", "80", */ GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 8088, 80,  /*  "8088", "80",*/ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 8099, 80,  /*  "8099", "80",*/ FormsSubfolderDef, false });
		
		theDt.Rows.Add(new object[4] { 1, 90, 0,   /*  "90", "", */ QAQCFolderDef });
		theDt.Rows.Add(new object[4] { 2, 9000, 90,  /*  "9000", "90",*/ GeneralSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 9010, 90,  /*  "9010", "90", */ ReportsSubfolderDef });
		theDt.Rows.Add(new object[4] { 2, 9088, 90,  /*  "9088", "90",*/ ImagesSubfolderDef });
		theDt.Rows.Add(new object[5] { 2, 9099, 90,   /* "9099", "90",*/ FormsSubfolderDef, false });

		DataView dv = theDt.DefaultView;

		dv.Sort = "PARENT_ID asc, RESOURCE_ID asc";
		DataTable sortedDT = dv.ToTable();
		return sortedDT;
	}
	catch
	{
		throw;
	}

}

private string GenerateFormFolderDefs(string jsonRoot, string formsRoot)
{
    string jsonString = string.Empty;
	string prefix = formsRoot;

	DataTable dtFolders = GenerateFolderTable();

    var dict  = (from row in dtFolders.AsEnumerable()
			where row.Field<bool>("BRIDGE_FOLDER") == false
			|| (row.Field<int>("RESOURCE_ID").ToString() != "0" && row.Field<int>("PARENT_ID").ToString() == "0") // 0,0
		    || (row.Field<int>("RESOURCE_ID").ToString() == "0" && row.Field<int>("PARENT_ID").ToString() == "-1")
			select new DocFolder
			 {
				 Level = row.Field<int>("LEVEL"),
				 Id = row.Field<int>("RESOURCE_ID"),
				 ParentId = row.Field<int>("PARENT_ID"),
				 DocType =row.Field<int>("RESOURCE_ID").ToString(),
				 ParentDocType = row.Field<int>("PARENT_ID").ToString(),
				 DocFolderName = ((row.Field<int>("LEVEL") == 0) ? $@"/" :
				 string.Concat(((dynamic)(JsonConvert.DeserializeObject(row.Field<string>("FOLDER_DEFINITION")))).folderName.ToString())),
				 DocFolderDescription = "",
				 DocFolderPath = (row.Field<int>("LEVEL") == 0) ? "/" : string.Empty,
				 MetaDataGuid = Guid.NewGuid().BrMGuid()
			 }).ToDictionary(t=> t.Id);

			 
 

	 
	/*Dictionary<int, DocFolder> dict =
	dtFolders.Rows.Cast<DataRow>()
					 .Where (r2 => !( r2.Field<bool>("BRIDGE_FOLDER")  && r2.Field<int>("PARENT_ID").ToString() ==  r2.Field<int>("RESOURCE_ID").ToString().Substring(0,2 ) )   //1099,10					
		 ||  (r2.Field<int>("RESOURCE_ID").ToString() != "0" &&  r2.Field<int>("PARENT_ID").ToString() == "0" ) // 0,0
			  ||  (r2.Field<int>("RESOURCE_ID").ToString()=="0" && r2.Field<int>("PARENT_ID").ToString()=="-1")) // 10, 0
			 .Select(r => new DocFolder
			 {
				 level = r.Field<int>("LEVEL"),
				 Id = r.Field<int>("RESOURCE_ID"),
				 ParentId = r.Field<int>("PARENT_ID"),
				 DocType = r.Field<int>("RESOURCE_ID").ToString(),
				 ParentDocType = r.Field<int>("PARENT_ID").ToString(),
				 DocFolderName = ((r.Field<int>("LEVEL") == 0) ? $@"/" :
				 string.Concat(((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderName.ToString())),
				 DocFolderDescription = "",
				 DocFolderPath = (r.Field<int>("LEVEL") == 0) ? "/" : string.Empty,
				 MetaDataGuid = Guid.NewGuid().BrMGuid()
			 })
			.ToDictionary(m => m.Id);
			*/
	List<DocFolder> DocFolders = new List<DocFolder>();

	foreach (var kvp in dict)
	{
		List<DocFolder> folder = DocFolders;
		DocFolder item = kvp.Value;
		item.Id.Dump();
		item.ParentId.Dump();
		kvp.Value.Dump();
		
		if (item.ParentId == 0)
		{			
			item.DocFolderPath =  Regex.Replace( string.Concat(prefix, System.IO.Path.Combine(dict[0].DocFolderName, dict[item.ParentId].DocFolderName, item.DocFolderName)), @"(?i)[\\]+", @"/", RegexOptions.IgnoreCase);
			item.DocFolderDescription=( string.Concat( item.DocFolderName) + " Forms - Main");
			
		}
		
		

		if (item.Level > 1) // a real subfolder e.g. UW or SPI/OS
		{
			//Console.WriteLine(item.ParentId);
			// Console.WriteLine($@"{dict[0].DocFolderName}/{dict[item.ParentId].DocFolderName}/{item.DocFolderName}"  );
			item.DocFolderPath = Regex.Replace(string.Concat(prefix, System.IO.Path.Combine(dict[0].DocFolderName, dict[item.ParentId].DocFolderName, item.DocFolderName)), @"(?i)[\\]+", @"/", RegexOptions.IgnoreCase);
			item.DocFolderDescription= string.Concat( dict[item.ParentId].DocFolderName," Forms And Templates");
		}
		
		if (item.ParentId >=0)
		{
			folder = dict[item.ParentId].DocSubFolder;
		}
		
		folder.Add(item);
	}

	jsonString = $"{{ \"{jsonRoot}\": {JsonConvert.SerializeObject(DocFolders, Newtonsoft.Json.Formatting.Indented)} {Environment.NewLine} }}";
	return jsonString;
}

private string GenerateBridgeFolderDefs(string jsonRoot, string bridgeIdentifier, string district, string county, string bridgegroup, string docRoot )
{
	string jsonString = string.Empty;

	string prefix = Regex.Replace(System.IO.Path.Combine(docRoot, district, county, bridgegroup),@"(?i)[\\]+", @"/",RegexOptions.IgnoreCase);

	DataTable dtFolders = GenerateFolderTable();
	var dict = (from row in dtFolders.AsEnumerable()
				where row.Field<bool>("BRIDGE_FOLDER") 
				|| (row.Field<int>("RESOURCE_ID").ToString() != "0" && row.Field<int>("PARENT_ID").ToString() == "0") // 0,0
				|| (row.Field<int>("RESOURCE_ID").ToString() == "0" && row.Field<int>("PARENT_ID").ToString() == "-1")
				select new DocFolder
				{
					Level = row.Field<int>("LEVEL"),
					Id = row.Field<int>("RESOURCE_ID"),
					ParentId = row.Field<int>("PARENT_ID"),
					DocType = row.Field<int>("RESOURCE_ID").ToString(),
					ParentDocType = row.Field<int>("PARENT_ID").ToString(),
					DocFolderName = ((row.Field<int>("LEVEL") == 0) ? $@"/" :
					 string.Concat(((dynamic)(JsonConvert.DeserializeObject(row.Field<string>("FOLDER_DEFINITION")))).folderName.ToString())),
					DocFolderDescription = "",
					DocFolderPath = (row.Field<int>("LEVEL") == 0) ? "/" : string.Empty,
					MetaDataGuid = Guid.NewGuid().BrMGuid()
				}).ToDictionary(t => t.Id);
	//Dictionary<int, DocFolder> dict =
	//dtFolders.Rows.Cast<DataRow>()
	//		.Where(r2 => !(r2.Field<int>("RESOURCE_ID").ToString().EndsWith("99") && r2.Field<int>("PARENT_ID").ToString() == r2.Field<int>("RESOURCE_ID").ToString().Substring(0, 2)) //1010,10
	//		 || (r2.Field<int>("RESOURCE_ID").ToString() != "0" && r2.Field<int>("PARENT_ID").ToString() == "0") // 0,0
	//		 || (r2.Field<int>("RESOURCE_ID").ToString() == "0" && r2.Field<int>("PARENT_ID").ToString() == "-1")) // 10, 0
	//		 .Select(r => new DocFolder
	//		 {
	//			 Level = r.Field<int>("LEVEL"),
	//			 Id = r.Field<int>("RESOURCE_ID"),
	//			 ParentId = r.Field<int>("PARENT_ID"),
	//			 DocType = r.Field<int>("RESOURCE_ID").ToString(),
	//			 ParentDocType = r.Field<int>("PARENT_ID").ToString(),
	//			 DocFolderName = ((r.Field<int>("LEVEL") == 0) ? $@"/{bridgeIdentifier}" :
	//			 string.Concat(((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderName.ToString())),
	//			 DocFolderDescription = ((dynamic)(JsonConvert.DeserializeObject(r.Field<string>("FOLDER_DEFINITION")))).folderDescription.ToString(),
	//			 DocFolderPath = string.Empty,
	//			 MetaDataGuid = Guid.NewGuid().BrMGuid()
	//		 })
	//		.ToDictionary(m => m.Id);
	//dict.Dump();

	List<DocFolder> DocFolders = new List<DocFolder>();

	foreach (var kvp in dict)
	{
		List<DocFolder> folder = DocFolders;
		DocFolder item = kvp.Value;
		
		if (item.ParentId >= 0)
		{
			folder = dict[item.ParentId].DocSubFolder;
		}


		if (item.Level > 1) // a real subfolder e.g. UW or SPI/OS
		{
			//Console.WriteLine(item.ParentId);
			// Console.WriteLine($@"{dict[0].DocFolderName}/{dict[item.ParentId].DocFolderName}/{item.DocFolderName}"  );
			item.DocFolderPath = Regex.Replace( string.Concat(prefix, System.IO.Path.Combine(dict[0].DocFolderName, dict[item.ParentId].DocFolderName, item.DocFolderName)) ,@"(?i)[\\]+", @"/",RegexOptions.IgnoreCase);
		}


		folder.Add(item);

	}

	jsonString = $"{{ \"{jsonRoot}\": {JsonConvert.SerializeObject(DocFolders, Newtonsoft.Json.Formatting.Indented)} {Environment.NewLine} }}";
	return jsonString;
}

private IEnumerable<JToken> GetBridgeFoldersByTypeKey(string json, string DocTypeKey)
{
	return GetBridgeFoldersByTypeKey(JObject.Parse(json), DocTypeKey);
}

private IEnumerable<JToken> GetBridgeFoldersByTypeKey(JObject json, string DocTypeKey)
{

	//JObject hive = JObject.Parse(json);
	IEnumerable<JToken> paths = json.SelectTokens($"$..DocSubFolder[?(@.ParentDocType == '{DocTypeKey}' )].DocFolderPath");

	return paths;

}

private string GetBridgeFolderBySubTypeKey(string json, string docSubTypeKey)
{
	return GetBridgeFolderBySubTypeKey(JObject.Parse(json), docSubTypeKey);
}

private string GetBridgeFolderBySubTypeKey(JObject json, string docSubTypeKey)
{
	var result = string.Empty;

	JToken path = json.SelectToken($"$..DocSubFolder[?(@.DocType == '{docSubTypeKey}' )].DocFolderPath");

	result = string.Concat(path.Value<string>().Trim(), path.Value<string>().Trim().EndsWith("/") ? "" : "/");
	return result;
}

private IEnumerable<JToken> GetAllDocumentFolders(string json)
{
	return GetAllDocumentFolders(JObject.Parse(json));
}

private IEnumerable<JToken> GetAllDocumentFolders(JObject json)
{
	IEnumerable<JToken> paths = json.SelectTokens($"$..DocSubFolder[?(@.ParentDocType <> '0' )].DocFolderPath");

	return paths;
}

private List<string> GetDocFolderAppSettings()
{
	var jsonSettings = GetFolderSubFolderAppSettings();



	var tokens = (JObject.Parse(jsonSettings)).SelectTokens($"$..DocSubFolder[?(@.Level >= 1 )].AppSettingsFolderPath").ToList();

	List<string> settings = new List<string>();


	foreach (var token in tokens)
	{
		var setting = Newtonsoft.Json.JsonConvert.DeserializeXmlNode(token.ToString(), "add");
		settings.Add(setting.InnerXml.ToString());
		// {"@key":"doc_fldr_load_rating_program_documents_bridge_structural_models_model","@value":"/LR/MODEL/"}
		// becomes
		// <add key="doc_fldr_load_rating_program_documents_bridge_structural_models_model" value="/LR/MODEL/" />	 
	}
	return settings;
}

void Main()
{
	// for random BRKEY generator
	Random random = new Random();

	const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
	const string docDrive = "X:\\";


	//const string tmpRoot = "C:\\tmp";	 
	string docRootFolder = System.IO.Path.Combine(docDrive, "Docs");
	string formsRootFolder=System.IO.Path.Combine(docDrive, "Docs","Forms");
	string adminFolderPath = System.IO.Path.Combine(docRootFolder, "Dist", "Cty", "BrGrp");
	//string utilityRootFolder = System.IO.Path.Combine(tmpRoot, "LBIS", "tmp");



	string testBrGd = Guid.NewGuid().BrMGuid();
	string testBrKey = "413700012101002";

	int brKeyLength = 15;
	DateTime beginTime = DateTime.Now;

	var cmd = new OracleCommand()
	{
		CommandText = @"SELECT DISTINCT Br.Brkey
				              -- ,Br.Bridge_Gd
				               ,P2.Shortdesc AS District
				               ,P1.Shortdesc AS County
				               ,Nvl(Br.Bridgegroup, 'UNASSIGNED') AS Bridgegroup
				               ,P1.Parmvalue AS Kdot_County
				               ,Br.County AS Nbi_County
				  FROM Kdotblp_Documents Kd
				 INNER JOIN Bridge Br
				    ON Kd.Bridge_Gd = Br.Bridge_Gd
				 INNER JOIN Paramtrs P1
				    ON P1.Longdesc = Br.County
				   AND P1.Table_Name = 'bridge'
				   AND P1.Field_Name = 'county'
				 INNER JOIN Paramtrs P2
				    ON P2.Parmvalue = Br.District
				   AND P2.Table_Name = 'bridge'
				   AND P2.Field_Name = 'district'
				 WHERE Kd.Doc_Status = '1' AND ROWNUM <=3
				 GROUP BY Br.Brkey
				         ,Br.Bridge_Gd
				         ,P2.Shortdesc
				         ,P1.Shortdesc
				         ,Nvl(Br.Bridgegroup, 'UNASSIGNED')
				         ,P1.Parmvalue
				         ,Br.County
				",
		CommandType = CommandType.Text,
		Connection = new OracleConnection()
		{
			ConnectionString = "Data Source=10.181.74.44:1521/ESOADEV.WORLD; User ID=KDOT_BLP; Password=eis3nh0wer;"
		}
	};

	cmd.Connection.Open();
	var a = new OracleDataAdapter(cmd);
	var dt = new DataTable();
	var rows = a.Fill(dt);
	cmd.Connection.Close();
	cmd.Dispose();

	for (int i = 0; i < rows; i++)
	{

		string bridgeIdentifier = dt.Rows[i].Field<string>("BRKEY");
	//	string bridgeGd = dt.Rows[i].Field<string>("BRIDGE_GD");
		string district = dt.Rows[i].Field<string>("DISTRICT");
		string county = dt.Rows[i].Field<string>("COUNTY");
		string bridgegroup = dt.Rows[i].Field<string>("BRIDGEGROUP");

		// a JSON string
		string jsonRootId = @"folders"; // all json will be created inside this object identifier { "docfolderstree": [] }
		string json = GenerateBridgeFolderDefs(jsonRootId, bridgeIdentifier, district, county, bridgegroup, docRootFolder );
		string formsJson = GenerateFormFolderDefs(jsonRootId,formsRootFolder);
		
		formsJson.Dump();

		JObject jsonObject = JObject.Parse(json);


		if (i % 50 == 0)
		{
			//	Console.WriteLine($@"sample {i}");
			json.Dump();
			jsonObject.Dump();
		}

		var settings = GetDocFolderAppSettings().ToArray();

		settings.Dump();


		//GetBridgeFoldersByTypeKey(json, "10").Dump();

		var paths = GetBridgeFoldersByTypeKey(json, "10");
		paths.Dump("NBI folders for the bridge");

	    paths = GetBridgeFoldersByTypeKey(json, "14");
		paths.Dump("Scour folders for the bridge");

		var folder = GetBridgeFolderBySubTypeKey(json, "1400");
		folder.Dump("Path by subtype");

		//GetBridgeFolderBySubTypeKey(jsonObject, "1000").Dump();
		GetAllDocumentFolders(json).Dump("All folders for the bridge");
		//GetAllBridgeDocumentFolders(jsonObject).Dump();
		
		GetAllDocumentFolders(formsJson).Dump("All form folders");
		
		
	}

	DateTime endTime = DateTime.Now;
	TimeSpan diff = endTime.Subtract(beginTime);
	string res = string.Format("{0}: {1}:{2}.{3}.{4}", "GENERATE FOLDERS", diff.Hours, diff.Minutes, diff.Seconds, diff.Milliseconds);
	Console.WriteLine(res);

}