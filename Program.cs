using System;
using System.Windows.Forms;
using MyNotebooks.subforms;
using System.Collections.Generic;
using MyNotebooks.objects;
using System.ComponentModel;
using MyNotebooks.DataAccess;

namespace MyNotebooks
{
	static class Program
    {
		/// <summary>
		///  The main entry point for the application.allNotebooks
		/// </summary>

		public static string PIN = string.Empty;
		public static List<ListViewItem> lstFonts = new List<ListViewItem>();
		public static int			ActiveNBParentId			= -1;
		public static List<Notebook> AllNotebooks			= new List<Notebook>();
		public static List<string>	AllNotebookNames		= new List<string>();
		public static string		AppRoot					= AppDomain.CurrentDomain.BaseDirectory;
		public static string		AppVersion				= string.Empty;
		public static string		AzureConnString			= "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;EndpointSuffix=core.windows.net";
		public static string		AzurePassword			= string.Empty;
		public static bool			AzureFileExists			= false;
		public static List<string>	AzureNotebookNames		= new List<string>();
		public static List<string>	AzureRenameCommands		= new List<string>();
		public static List<string>	AzurePinFileNames		= new List<string>();
		public static BackgroundWorker BgWorker				= new();
		public static string		GroupsFolder			= Program.AppRoot + "groups\\";

		public static List<MNLabel> LblsUnderEntry;
		public static List<MNLabel> LblsUnderNotebook;
		public static List<MNLabel> LblsUnderGroup;
		public static List<MNLabel> LblsUnderDepartment;
		public static List<MNLabel> LblsUnderAccount;
		public static List<MNLabel> LblsUnderCompany;

		public static List<ListBox> ManagementConsoleSelections = new();
		//public static string		InvalidFileName			= "Sorry, notebook names may not contain characters which are not allowed in file names, for example *, <, >, {, }, |, :, ?, /, \\ (and others).";
		public static int			SelectedCompanyId		= 0;
		public static int			SelectedAccountId		= 0;
		public static int			SelectedDepartmentId	= 0;
		public static int			SelectedGroupId			= 0;
		public static string		SelectedCompanyName		= string.Empty;
		public static string		SelectedAccountName		= string.Empty;
		public static string		SelectedDepartmentName	= string.Empty;
		public static string		SelectedGroupName		= string.Empty;
		public static string		SelectedNotebookName	= string.Empty;
		public static bool			SkipFileSizeComparison	= false;
		public static MNUser		User					= null;
		public static Dictionary<string, string> DictCheckedNotebooks = new Dictionary<string, string>();
		public static Dictionary<string, int>	 NotebooksNamesAndIds = new Dictionary<string, int>();

		//public static List<Journal> allJournals = new List<Journal>();

		[STAThread]
        static void Main()
        {
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
			AppVersion = fvi.FileVersion;
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmUserLogin());
		}

	}
}
