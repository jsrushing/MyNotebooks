/* Simple data object for LocalNotebook Settings. Extensible.
 * 06/05/23
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace MyNotebooks.objects
{
	[Serializable]
	public class NotebookSettings
	{
		public bool AllowCloud { get; set; }
		public bool IfCloudOnly_Download { get; set; }
		public bool IfCloudOnly_Delete { get; set; }
		public bool IfLocalOnly_Upload { get; set; }
		public bool IfLocalOnly_Delete { get; set; }
		public bool IfLocalOnly_DisallowCloud { get; set; }

		public NotebookSettings() { }

		public NotebookSettings(DataRow dr) 
		{
			foreach (PropertyInfo sPropertyName in typeof(Company).GetProperties())
			{
				var value = dr.Field<bool>(sPropertyName.Name);
				this.GetType().GetProperty(sPropertyName.Name).SetValue(this, value);
			}
		}


	}
}
