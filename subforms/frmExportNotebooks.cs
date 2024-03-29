﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using MyNotebooks.objects;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using Azure;
using Azure.Storage.Files;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;

namespace MyNotebooks.subforms
{
	public partial class frmExportNotebooks : Form
	{
		public frmExportNotebooks(Form parent)
		{
			InitializeComponent();
			Utilities.SetStartPosition(this, parent);
			lstJournalsToSynch.DataSource = Utilities.PopulateAllNotebookNames();
		}

		private async void btnOk_Click(object sender, EventArgs e)
		{
			//AzureFileClient fileClient = new AzureFileClient();
			await AzureFileClient.UploadFile("C:\\inetpub\\testfile4.txt");
			this.Close();
			
			// email methods tried
			//var message = new MimeMessage();
			//string[] to = new string[2];

			//message.From.Add(new MailboxAddress("MyJournal", "myJournalApp2022@gmail.com"));

			//foreach (string toAddy in lstRecipients.Items)
			//{
			//	to = toAddy.Split(" : ");
			//	message.To.Add(new MailboxAddress(to[0], to[1]));
			//}
			//message.Subject = "These Journals are attached.";

			//var builder = new BodyBuilder();
			//builder.TextBody = "Please detach these journals then use Journal > Import to add them.";

			//foreach (string jrnl in lstJournalsToExport.SelectedItems)
			//{
			//	builder.Attachments.Add(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + jrnl);
			//}

			//message.Body = builder.ToMessageBody();

			////message.Body = new TextPart("plain") { Text = "Please detach these journals then use Journal > Import to add them."};

			//using (var client = new SmtpClient())
			//{
			//	client.CheckCertificateRevocation = false;
			//	client.Connect("smtp-relay.gmail.com", 25, false );
			//	client.Authenticate("myJournalApp2022", "okfzkpskarbdrmtq");
			//	client.Send(message);
			//	client.Disconnect(true);
			//}

			//MAPI mapi = new MAPI();

			//foreach(string sJournalName in lstJournalsToExport.SelectedItems)
			//{
			//	mapi.AddAttachment(Program.AppRoot + ConfigurationManager.AppSettings["FolderStructure_NotebooksFolder"] + sJournalName);
			//}

			////foreach(string sRecipient in txtRecipients.Text.Split(','))
			////{
			//	mapi.AddRecipientTo(txtRecipients.Text);
			////}

			//mapi.SendMailPopup("Exported Journals", "Here are the exported journals.");
		}

		private void btnAddRecipient_Click(object sender, EventArgs e)
		{
			pnlMain.Visible = false;
			pnlAddRecipient.Visible = true;
			txtName.Focus();
		}

		private void btn_Recipient_Click(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			if (b.Text.ToLower().Contains("ok"))
			{
				lstRecipients.Items.Add(txtName.Text + " : " + txtEmail.Text);
			}
			txtName.Text = String.Empty;
			txtEmail.Text = String.Empty;
			pnlAddRecipient.Visible = false;
			pnlMain.Visible = true;
		}

		private void frmExportJournals_Load(object sender, EventArgs e)
		{
			this.Size = new System.Drawing.Size(355, 307);
			pnlAddRecipient.Location = new System.Drawing.Point(33, 3);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}

	class MAPI  // from https://www.codeproject.com/Articles/17561/Programmatically-adding-attachments-to-emails-in-C
	{
		public bool AddRecipientTo(string email)
		{
			return AddRecipient(email, HowTo.MAPI_TO);
		}

		public bool AddRecipientCC(string email)
		{
			return AddRecipient(email, HowTo.MAPI_TO);
		}

		public bool AddRecipientBCC(string email)
		{
			return AddRecipient(email, HowTo.MAPI_TO);
		}

		public void AddAttachment(string strAttachmentFileName)
		{
			m_attachments.Add(strAttachmentFileName);
		}

		public int SendMailPopup(string strSubject, string strBody)
		{
			return SendMail(strSubject, strBody, MAPI_LOGON_UI | MAPI_DIALOG);
		}

		public int SendMailDirect(string strSubject, string strBody)
		{
			return SendMail(strSubject, strBody, MAPI_LOGON_UI);
		}


		[DllImport("MAPI32.DLL")]
		static extern int MAPISendMail(IntPtr sess, IntPtr hwnd,
			MapiMessage message, int flg, int rsv);

		int SendMail(string strSubject, string strBody, int how)
		{
			MapiMessage msg = new MapiMessage();
			msg.subject = strSubject;
			msg.noteText = strBody;

			msg.recips = GetRecipients(out msg.recipCount);
			msg.files = GetAttachments(out msg.fileCount);

			m_lastError = MAPISendMail(new IntPtr(0), new IntPtr(0), msg, how,
				0);
			if (m_lastError > 1)
				MessageBox.Show("MAPISendMail failed! " + GetLastError(),
					"MAPISendMail");

			Cleanup(ref msg);
			return m_lastError;
		}

		bool AddRecipient(string email, HowTo howTo)
		{
			MapiRecipDesc recipient = new MapiRecipDesc();

			recipient.recipClass = (int)howTo;
			recipient.name = email;
			m_recipients.Add(recipient);

			return true;
		}

		IntPtr GetRecipients(out int recipCount)
		{
			recipCount = 0;
			if (m_recipients.Count == 0)
				return IntPtr.Zero;

			int size = Marshal.SizeOf(typeof(MapiRecipDesc));
			IntPtr intPtr = Marshal.AllocHGlobal(m_recipients.Count * size);

			long ptr = (long)intPtr;
			foreach (MapiRecipDesc mapiDesc in m_recipients)
			{
				Marshal.StructureToPtr(mapiDesc, (IntPtr)ptr, false);
				ptr += size;
			}

			recipCount = m_recipients.Count;
			return intPtr;
		}

		IntPtr GetAttachments(out int fileCount)
		{
			fileCount = 0;
			if (m_attachments == null)
				return IntPtr.Zero;

			if ((m_attachments.Count <= 0) || (m_attachments.Count >
				maxAttachments))
				return IntPtr.Zero;

			int size = Marshal.SizeOf(typeof(MapiFileDesc));
			IntPtr intPtr = Marshal.AllocHGlobal(m_attachments.Count * size);

			MapiFileDesc mapiFileDesc = new MapiFileDesc();
			mapiFileDesc.position = -1;
			long ptr = (long)intPtr;

			foreach (string strAttachment in m_attachments)
			{
				mapiFileDesc.name = Path.GetFileName(strAttachment);
				mapiFileDesc.path = strAttachment;
				Marshal.StructureToPtr(mapiFileDesc, (IntPtr)ptr, false);
				ptr += size;
			}

			fileCount = m_attachments.Count;
			return intPtr;
		}

		void Cleanup(ref MapiMessage msg)
		{
			int size = Marshal.SizeOf(typeof(MapiRecipDesc));
			long ptr = 0;

			if (msg.recips != IntPtr.Zero)
			{
				ptr = (long)msg.recips;
				for (int i = 0; i < msg.recipCount; i++)
				{
					Marshal.DestroyStructure((IntPtr)ptr,
						typeof(MapiRecipDesc));
					ptr += size;
				}
				Marshal.FreeHGlobal(msg.recips);
			}

			if (msg.files != IntPtr.Zero)
			{
				size = Marshal.SizeOf(typeof(MapiFileDesc));

				ptr = (long)msg.files;
				for (int i = 0; i < msg.fileCount; i++)
				{
					Marshal.DestroyStructure((IntPtr)ptr,
						typeof(MapiFileDesc));
					ptr += size;
				}
				Marshal.FreeHGlobal(msg.files);
			}

			m_recipients.Clear();
			m_attachments.Clear();
			m_lastError = 0;
		}

		public string GetLastError()
		{
			if (m_lastError <= 26)
				return errors[m_lastError];
			return "MAPI error [" + m_lastError.ToString() + "]";
		}

		readonly string[] errors = new string[] {
		"OK [0]", "MNUser abort [1]", "General MAPI failure [2]",
				"MAPI login failure [3]", "Disk full [4]",
				"Insufficient memory [5]", "Access denied [6]",
				"-unknown- [7]", "Too many sessions [8]",
				"Too many files were specified [9]",
				"Too many recipients were specified [10]",
				"A specified attachment was not found [11]",
		"Attachment open failure [12]",
				"Attachment write failure [13]", "Unknown recipient [14]",
				"Bad recipient type [15]", "No messages [16]",
				"Invalid message [17]", "Text too large [18]",
				"Invalid session [19]", "Type not supported [20]",
				"A recipient was specified ambiguously [21]",
				"Message in use [22]", "Network failure [23]",
		"Invalid edit fields [24]", "Invalid recipients [25]",
				"Not supported [26]"
		};


		List<MapiRecipDesc> m_recipients = new
			List<MapiRecipDesc>();
		List<string> m_attachments = new List<string>();
		int m_lastError = 0;

		const int MAPI_LOGON_UI = 0x00000001;
		const int MAPI_DIALOG = 0x00000008;
		const int maxAttachments = 20;

		enum HowTo { MAPI_ORIG = 0, MAPI_TO, MAPI_CC, MAPI_BCC };
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class MapiMessage
	{
		public int reserved;
		public string subject;
		public string noteText;
		public string messageType;
		public string dateReceived;
		public string conversationID;
		public int flags;
		public IntPtr originator;
		public int recipCount;
		public IntPtr recips;
		public int fileCount;
		public IntPtr files;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class MapiFileDesc
	{
		public int reserved;
		public int flags;
		public int position;
		public string path;
		public string name;
		public IntPtr type;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class MapiRecipDesc
	{
		public int reserved;
		public int recipClass;
		public string name;
		public string address;
		public int eIDSize;
		public IntPtr entryID;
	}
}

