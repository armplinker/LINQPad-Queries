<Query Kind="Program">
  <Reference>D:\git\LBIS9\src\bin\LBIS9.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Progress\Telerik Reporting R1 2021\Bin\Newtonsoft.Json.dll</Reference>
  <Reference>D:\git\LBIS9\src\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <NuGetReference>System.Linq.Dynamic.Core</NuGetReference>
  <Namespace>LBIS9</Namespace>
  <Namespace>Oracle.ManagedDataAccess</Namespace>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>System.Linq.Dynamic.Core</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
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

void Main()
{
	var dt = LoadFolderDefs(new DataTable());

	Dictionary<int, DocFolder> dict =
   dt.Rows.Cast<DataRow>()
			 .Select(r => new DocFolder
			 {
				 Id = r.Field<int>("ResourceId"),
				 parentId = r.Field<int>("ParentId"),
				 level = r.Field<int>("LEVEL"),
				 parentDocType = r.Field<string>("PARENTDOCTYPE"),
				 docType = r.Field<string>("DOCTYPE"),
				 docFolderName = r.Field<string>("FOLDERNAME"),
				 docParentFolderName = r.Field<string>("PARENTFOLDERNAME"),
				 docFolderPath = r.Field<string>("FOLDERPATH"),
				 docFolderDescription = r.Field<string>("FOLDERDESCRIPTION"),
				 pathLength = r.Field<string>("FOLDERPATH").Length,
				 metaDataGuid = r.Field<string>("METADATAGUID")
			 })
			.ToDictionary(m => m.Id);

	List<DocFolder> rootFolder = new List<DocFolder>();
	foreach (var kvp in dict)
	{
		List<DocFolder> folder = rootFolder;
		DocFolder item = kvp.Value;
		if (item.parentId >= 0)
		{
			folder = dict[item.parentId].docSubFolder;
		}
		folder.Add(item);
	}

	string json = JsonConvert.SerializeObject(rootFolder, Newtonsoft.Json.Formatting.Indented);

	json.Dump();
	
	object deJson = JsonConvert.DeserializeObject(json) ;
	
	deJson.Dump();
	
}


public class DocFolder
{
	public string metaDataGuid{get;set;}
	// ignore the relationship codes.  We only want the string document types.
	[JsonIgnore]
	public int Id { get; set; } //1100
	[JsonIgnore]
	public int parentId { get; set; } //11
	public int level { get; set; }  // 0, 1 , 2 ,3
	public string parentDocType { get; set; } // "11"
	public string docType { get; set; } // "1100"
	public string docFolderName { get; set; } // folder actual name e.g. genl
	public string docParentFolderName { get; set; }
	public string docFolderPath { get; set; }
	public string docFolderDescription { get; set; } // helptext
	public int pathLength{get;set;}
	public List<DocFolder> docSubFolder { get; set; }
	public DocFolder()
	{
		docSubFolder = new List<DocFolder>();
	}
}

public DataTable LoadFolderDefs(DataTable theDt)
{

	theDt.Namespace = "FolderDefinitions";
	theDt.Columns.Add("ResourceId", typeof(int));
	theDt.Columns.Add("ParentId", typeof(int));
	theDt.Columns.Add("LEVEL", typeof(int));

	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "PARENTDOCTYPE",
		Unique = false,
		AllowDBNull = true,
		DataType = typeof(string)

	});

	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "DOCTYPE",
		Unique = true,
		AllowDBNull = false,
		DataType = typeof(string)

	}
		);

	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "FOLDERNAME",
		Unique = false,
		AllowDBNull = false,
		DataType = typeof(string)

	});
	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "PARENTFOLDERNAME",
		Unique = false,
		AllowDBNull = false,
		DataType = typeof(string)

	});

	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "FOLDERPATH",
		Unique = false,
		AllowDBNull = false,
		DataType = typeof(string)
	});
	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "FOLDERDESCRIPTION",
		Unique = false,
		AllowDBNull = false,
		DataType = typeof(string)
	});
	theDt.Columns.Add(new DataColumn()
	{
		ColumnName = "METADATAGUID",
		Unique = true,
		AllowDBNull = false,
		DataType = typeof(string)
	});
	var docDrive = "X:\\";
	var tmpRoot = "C:\\tmp";
	var rootFolder = System.IO.Path.Combine(docDrive, "Docs");
	var adminFolderPath = System.IO.Path.Combine(rootFolder, "Dist", "Cty", "BrGrp");
	var utilityRootFolder = System.IO.Path.Combine(tmpRoot, "LBIS", "tmp");
	var brGd = Guid.NewGuid().BrMGuid();
	var brKey = "0000000000230230";
	 

 	theDt.Rows.Add(new object[10] { 0, -1, 0, "", "bridge", brKey, System.IO.Path.Combine(rootFolder, adminFolderPath), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey), brGd ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 10, 0, 1, 0, "10", "NBI", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "NBI"), "NBI Inspections Root",Guid.NewGuid().BrMGuid() });
	theDt.Rows.Add(new object[10] { 1000, 10, 2, "10", "1000", "Gnl", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "NBI"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "NBI", "Gnl"), "General" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 1088, 10, 2, "10", "1088", "Img", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "NBI"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "NBI", "Img"), "General" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 13, 0, 1, 0, "13", "SPI", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI"), "SPI Root",Guid.NewGuid().BrMGuid() });
	theDt.Rows.Add(new object[10] { 1300, 13, 2, "13", "1300", "Gnl", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI", "Gnl"), "General" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 1388, 13, 2, "13", "1388", "Img", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI", "Img"), "Image Files",Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 18, 0, 1, 0, "18", "SPI/PNH", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH"), "PNH Root",Guid.NewGuid().BrMGuid() });
	theDt.Rows.Add(new object[10] { 1800, 18, 2, "18", "1800", "Gnl", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH", "Gnl"), "General" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 1810, 18, 2, "18", "1810", "Rpt", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH", "Rpt"), "Reports" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 1888, 18, 2, "18", "1888", "Img", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH", "Img"), "Images",Guid.NewGuid().BrMGuid() });
	theDt.Rows.Add(new object[10] { 1899, 18, 2, "18", "1999", "Frm", System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH"), System.IO.Path.Combine(rootFolder, adminFolderPath, brKey, "SPI/PNH", "Frm"), "Form Files" ,Guid.NewGuid().BrMGuid()});
	
	theDt.Rows.Add(new object[10] { 90, -1, 0, "", "utility", "BATCH", tmpRoot, System.IO.Path.Combine(utilityRootFolder, "BATCH"), "LBIS UTIL Root" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 9000, 90, 1, "UTIL", "NBIBATCH", "NBI",System.IO.Path.Combine(utilityRootFolder, "BATCH"), System.IO.Path.Combine(utilityRootFolder, "BATCH", "NBI"), "NBI Batch Root" ,Guid.NewGuid().BrMGuid()});
	theDt.Rows.Add(new object[10] { 90000, 9000, 2, "9000", "90000", "Uplds", System.IO.Path.Combine(utilityRootFolder, "BATCH", "NBI"), System.IO.Path.Combine(utilityRootFolder, "BATCH", "NBI", "Uplds"), "Uploads",Guid.NewGuid().BrMGuid() });
	theDt.Rows.Add(new object[10] { 91000, 9000, 2, "9000", "91000", "Dlds", System.IO.Path.Combine(utilityRootFolder, "BATCH", "NBI"), System.IO.Path.Combine(utilityRootFolder, "BATCH", "NBI", "Dlds"), "Uploads",Guid.NewGuid().BrMGuid() });

	return theDt;
}




