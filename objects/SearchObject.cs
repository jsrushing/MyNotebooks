using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace myJournal.objects
{
	public class SearchObject
	{
		public CheckBox chkUseDate { get; set; }
		public CheckBox chkUseDateRange { get; set;}
		public CheckBox chkMatchCase { get; set;}
		public DateTimePicker dtFindDate { get; set; }
		public DateTimePicker dtFindDate_From { get; set; }
		public DateTimePicker dtFindDate_To { get; set; }
		public RadioButton radBtnAnd { get; set; }
		public RadioButton radBtnLabelsAnd { get; set; }

		public string searchTitle { get; set; }
		public string searchText { get; set; }
		public string[] labelsArray { get; set; }


		public SearchObject(CheckBox _chkUseDate, CheckBox _chkUseDateRange, CheckBox _chkMatchCase, DateTimePicker _dtFindDate, 
			DateTimePicker _dtFindDate_From, DateTimePicker _dtFindDate_To, RadioButton _radBtnAnd, RadioButton _radLabelsAnd, string _searchTitle, string _searchText, string[] _labelsArray)
		{
			chkUseDate			= _chkUseDate;
			chkUseDateRange		= _chkUseDateRange;
			chkMatchCase		= _chkMatchCase;
			dtFindDate			= _dtFindDate;
			dtFindDate_From		= _dtFindDate_From;
			dtFindDate_To		= _dtFindDate_To;
			radBtnAnd			= _radBtnAnd;
			searchTitle			= _searchTitle;
			searchText			= _searchText;
			labelsArray			= _labelsArray;
		}
	}
}
