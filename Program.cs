using System;
using System.Windows.Forms;
using myJournal.subforms;
using System.Collections.Generic;
using myJournal.objects;

namespace myJournal
{
	static class Program
    {
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		public static string PIN = string.Empty;
		public static List<ListViewItem> lstFonts = new List<ListViewItem>();
		public static string	AppRoot					= AppDomain.CurrentDomain.BaseDirectory;
		public static string	AppVersion				= string.Empty;
		public static string	AzurePassword			= string.Empty;
		public static bool		AzureFileExists			= false;
		public static string	AzureConnString			= "DefaultEndpointsProtocol=https;AccountName=container1a;AccountKey=4YNQFl9klH9bp8ieKKfhwiVgiKlZKWieBlyzvu8zlm2hyL0HaR/x3XpbpFYjJ5VF4YgtaAR9sN4F+ASttv59jA==;EndpointSuffix=core.windows.net";
		public static bool		SkipFileSizeComparison	= false;
		public static List<string> AzureJournalNames	= new List<string>();
		public static List<Journal> AllJournals			= new List<Journal>();

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
