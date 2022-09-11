using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using myJournal;

// https://www.delftstack.com/howto/csharp/encrypt-and-decrypt-a-string-in-csharp/

namespace encrypt_decrypt_string
{
    class EncryptDecrypt
    {
        public static string Encrypt(string TextToEncrypt)
        {
            try
            {
                string strReturn = "";
				string PublicKey = ConfigurationManager.AppSettings["PublicKey"];

				if(Program.PIN == null || Program.PIN.Length == 0)
				{
					Program.PIN = "12345678";
					PublicKey = "87654321";
				}

				byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(PublicKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(Program.PIN));
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(TextToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    strReturn = Convert.ToBase64String(ms.ToArray());
                }
                return strReturn;
            }
            catch (Exception ex)
            {
				Console.Write(ex.Message);
				return string.Empty;
				//throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string Decrypt(string TextToDecrypt)
        {
            try
            {
                string strReturn = "";
				string PublicKey = ConfigurationManager.AppSettings["PublicKey"];	// Program.PIN;

				if (Program.PIN == null || Program.PIN.Length == 0)
				{
					Program.PIN = "12345678";
					PublicKey = "87654321";
				}

				byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(PublicKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(Program.PIN)); 
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[TextToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(TextToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    strReturn = encoding.GetString(ms.ToArray());
                }
                return strReturn;
            }
            
			catch (Exception ex)
            {
				Console.Write(ex.Message);
				return string.Empty;
            }
        }

		public static string FullPin(string pin)
		{
			pin = pin == null ? "" : pin;
			return pin.Length < 8 && pin.Length > 0 ? pin + pin.Substring(0, 8 - pin.Length) : pin;
		}
    }
}
