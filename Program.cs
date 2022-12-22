using System;
using System.Windows.Forms;
using myJournal.subforms;
using System.Collections.Generic;

namespace myJournal
{
	static class Program
    {
		public static string PIN = string.Empty;
		public static List<ListViewItem> lstFonts = new List<ListViewItem>();
		public static string AppRoot = AppDomain.CurrentDomain.BaseDirectory;
		public static string AppVersion = string.Empty;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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
