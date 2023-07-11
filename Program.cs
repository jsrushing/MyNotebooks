using System;
using System.Windows.Forms;
using myNotebooks.subforms;
using System.Collections.Generic;
using myNotebooks.objects;

namespace myNotebooks
{
	static class Program
    {
		/// <summary>
		///  The main entry point for the application.allNotebooks
		/// </summary>
		public static string PIN = string.Empty;
		public static List<ListViewItem> lstFonts = new List<ListViewItem>();
		public static string			AppRoot					= AppDomain.CurrentDomain.BaseDirectory;
		public static string			AppVersion				= string.Empty;
		public static string			AzurePassword			= string.Empty;
		public static string			GroupsFolder			= Program.AppRoot + "groups\\";
		public static string			GroupPIN				= string.Empty;
		// add public static string s = configmgr[""] ... for all paths, etc. which are called out in app.config.
		public static string			GroupName_Encrypted		= string.Empty; // reference to folder name (encrypted) in groups\ folder. Used for creating new nbooks & labels
		public static bool				AzureFileExists			= false;
		public static string			AzureConnString			= "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;EndpointSuffix=core.windows.net";
		public static string			InvalidFileName			= "Sorry, notebook names may not contain characters which are not allowed in file names, for example *, <, >, {, }, |, :, ?, /, \\ (and others).";
		public static bool				SkipFileSizeComparison	= false;
		public static List<string>		AzureNotebookNames		= new List<string>();
		public static List<string>		AzureRenameCommands		= new List<string>();
		public static List<string>		AzurePinFileNames		= new List<string>();
		public static List<Notebook>	AllNotebooks			= new List<Notebook>();
		public static List<string> AllNotebookNames = new List<string>();
		public static Dictionary<string, string> DictCheckedNotebooks = new Dictionary<string, string>();

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
			Application.Run(new frmMain());
		}
    }
}
