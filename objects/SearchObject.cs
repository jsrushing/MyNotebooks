/* Create an object to pass to Search routines.
 * Can't remember. Added this 06/13/23. Possibly as early as 12/01/22.
 * JSR
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyNotebooks.objects
{
	public class SearchObject
	{
		public CheckBox			chkUseDate { get; set; }
		public CheckBox			chkUseDateRange { get; set;}
		public CheckBox			chkMatchCase_Title { get; set;}
		public CheckBox			chkMatchCase_Text { get; set;}
		public DateTimePicker	dtFindDate { get; set; }
		public DateTimePicker	dtFindDate_From { get; set; }
		public DateTimePicker	dtFindDate_To { get; set; }
		public RadioButton		radDate_And { get; set; }
		public RadioButton		radLabels_And { get; set; }
		public RadioButton		radText_And { get; set; }
		public RadioButton		radTitle_And { get; set; }
		public RadioButton		radCreatedOn { get; set; }


		public string			searchTitle { get; set; }
		public string			searchText { get; set; }
		public List<string>		labelsForSearch { get; set; }
		//public string[]	labelsArray { get; set; }


		public SearchObject(CheckBox _chkUseDate, CheckBox _chkUseDateRange, CheckBox _chkMatchCase_title, CheckBox _chkMatchCase_text, DateTimePicker _dtFindDate, 
			DateTimePicker _dtFindDate_From, DateTimePicker _dtFindDate_To
			, RadioButton _radDateAnd, RadioButton _radLabelsAnd, RadioButton _radTitleAnd, RadioButton _radTextAnd
			, string _searchTitle, string _searchText, List<string> _labels, RadioButton _radCreatedOn )
		{
			chkUseDate			= _chkUseDate;
			chkUseDateRange		= _chkUseDateRange;
			chkMatchCase_Title	= _chkMatchCase_title;
			chkMatchCase_Text	= _chkMatchCase_text;
			dtFindDate			= _dtFindDate;
			dtFindDate_From		= _dtFindDate_From;
			dtFindDate_To		= _dtFindDate_To;
			radDate_And			= _radDateAnd;
			radLabels_And		= _radLabelsAnd;
			radText_And			= _radTextAnd;
			radTitle_And		= _radTitleAnd;
			searchTitle			= _searchTitle;
			searchText			= _searchText;
			//labelsArray		= _labelsArray;
			labelsForSearch		=	_labels;
			radCreatedOn		= _radCreatedOn;
		}
	}
}
