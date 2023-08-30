using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using MyNotebooks;

// https://www.delftstack.com/howto/csharp/encrypt-and-decrypt-a-string-in-csharp/

namespace Encryption
{
    class EncryptDecrypt
    {
        public static string Encrypt(string TextToEncrypt, string pin = "")
        {

			if(pin != null && pin.Length > 0)
			{
				var curPin = Program.PIN;
				Program.PIN = pin;
				string encryptionKey = AESPin(pin) ;

				byte[] clearBytes = Encoding.Unicode.GetBytes(TextToEncrypt);

				using (Aes encryptor = Aes.Create())
				{
					Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
					encryptor.Key = pdb.GetBytes(32);
					encryptor.IV = pdb.GetBytes(16);
					using (MemoryStream ms = new MemoryStream())
					{
						using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
						{
							cs.Write(clearBytes, 0, clearBytes.Length);
							cs.Close();
						}

						TextToEncrypt = Convert.ToBase64String(ms.ToArray());
					}
				}

				Program.PIN = curPin;	
			}

			return TextToEncrypt;

			//return Program.PIN.Length == 0 ? TextToEncrypt : TextToEncrypt.Replace("/", "_").Replace("+", "-");

			//string s = AESThenHMAC.SimpleEncryptWithPassword(TextToEncrypt, AESPin(Program.PIN));
			//return s;

			//        try
			//        {
			//            string strReturn = "";
			//string PublicKey = ConfigurationManager.AppSettings["PublicKey"];

			//if(Program.PIN == null || Program.PIN.Length == 0)
			//{
			//	strReturn = TextToEncrypt;
			//	//Program.PIN = "12345678";
			//	//PublicKey = "87654321";
			//}
			//else
			//{
			//	byte[] secretkeyByte = { };
			//	secretkeyByte = System.Text.Encoding.UTF8.GetBytes(PublicKey);
			//	byte[] publickeybyte = { };
			//	publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(Program.PIN));
			//	MemoryStream ms = null;
			//	CryptoStream cs = null;
			//	byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(TextToEncrypt);

			//	using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			//	{
			//		ms = new MemoryStream();
			//		cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
			//		cs.Write(inputbyteArray, 0, inputbyteArray.Length);
			//		cs.FlushFinalBlock();
			//		strReturn = Convert.ToBase64String(ms.ToArray());
			//	}
			//}
			//            return strReturn;
			//        }
			//        catch (Exception ex)
			//        {
			//Console.Write(ex.Message);
			//return string.Empty;
			////throw new Exception(ex.Message, ex.InnerException);
			//        }
		}

        public static string Decrypt(string TextToDecrypt, string pin = "")
		{
			//if(TextToDecrypt.Contains("_") | TextToDecrypt.Contains("-")) { TextToDecrypt = TextToDecrypt.Replace("_", "/").Replace("-", "+"); }
			//string encryptionKey = AESPin(Program.PIN);
			//byte[] cipherBytes = Convert.FromBase64String(TextToDecrypt);
			//using (Aes encryptor = Aes.Create())

			//if(pin.Length > 0)
			//{
				try
				{
					if(TextToDecrypt.Contains("_") | TextToDecrypt.Contains("-")) { TextToDecrypt = TextToDecrypt.Replace("_", "/").Replace("-", "+"); }
					if (pin.Length == 0) { pin = Program.PIN; }

					//var v = TextToDecrypt.Length;

					string encryptionKey = AESPin(pin);
					byte[] cipherBytes = Convert.FromBase64String(TextToDecrypt);
					using (Aes encryptor = Aes.Create())
					{
						Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
						encryptor.Key = pdb.GetBytes(32);
						encryptor.IV = pdb.GetBytes(16);
						using (MemoryStream ms = new MemoryStream())
						{
							using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
							{
								cs.Write(cipherBytes, 0, cipherBytes.Length);
								cs.Close();
							}
							TextToDecrypt = Encoding.Unicode.GetString(ms.ToArray());
						}
					}

				}
				catch(Exception) { TextToDecrypt = string.Empty; }
			//}

			return TextToDecrypt;

			//string s = AESThenHMAC.SimpleDecryptWithPassword(TextToDecrypt, AESPin(Program.PIN));
			//return s;

			//if(TextToDecrypt == null) { return string.Empty; }

			//         try
			//         {
			//             string strReturn = "";
			//	string PublicKey = ConfigurationManager.AppSettings["PublicKey"];	// Program.PIN;

			//	if (Program.PIN == null || Program.PIN.Length == 0)
			//	{
			//		strReturn = TextToDecrypt;
			//		//Program.PIN = "12345678";
			//		//PublicKey = "87654321";
			//	}
			//	else
			//	{
			//		byte[] privatekeyByte = { };
			//		privatekeyByte = System.Text.Encoding.UTF8.GetBytes(PublicKey);
			//		byte[] publickeybyte = { };
			//		publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(Program.PIN)); 
			//		MemoryStream ms = null;
			//		CryptoStream cs = null;
			//		byte[] inputbyteArray = new byte[TextToDecrypt.Replace(" ", "+").Length];
			//		inputbyteArray = Convert.FromBase64String(TextToDecrypt.Replace(" ", "+"));
			//		using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
			//		{
			//			ms = new MemoryStream();
			//			cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
			//			cs.Write(inputbyteArray, 0, inputbyteArray.Length);
			//			cs.FlushFinalBlock();
			//			Encoding encoding = Encoding.UTF8;
			//			strReturn = encoding.GetString(ms.ToArray());
			//		}
			//	}
			//             return strReturn;
			//         }

			//catch (Exception ex)
			//         {
			//	Console.Write(ex.Message);
			//	return " <decrypt failed> ";	// string.Empty;
			//         }
		}

		private static string AESPin(string pin)
		{
			if(pin.Length > 0) { while(pin.Length < 12) { pin += pin; } }
			return pin;
		}

		public static string FullPin(string pin)
		{
			pin = pin == null ? "" : pin;
			return pin.Length < 8 && pin.Length > 0 ? pin + pin.Substring(0, 8 - pin.Length) : pin;
		}
    }
}
