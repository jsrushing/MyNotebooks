using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

// https://www.delftstack.com/howto/csharp/encrypt-and-decrypt-a-string-in-csharp/

namespace encrypt_decrypt_string
{
    class EncryptDecrypt
    {
        public static string Encrypt(string TextToEncrypt, string PublicKey, string PrivateKey)
        {
            try
            {
                string ToReturn = "";
				if(PublicKey == null)
				{
					PublicKey = "12345678";
					PrivateKey = "87654321";
				}
				byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(PrivateKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(PublicKey));
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(TextToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static string Decrypt(string TextToDecrypt, string PublicKey, string PrivateKey)
        {
            try
            {
                string ToReturn = "";
				if (PublicKey == null)
				{
					PublicKey = "12345678";
					PrivateKey = "87654321";
				}
				byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(PrivateKey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(FullPin(PublicKey)); 
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
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            
			catch (Exception ex)
            {
				return string.Empty;
            }
        }

		public static string FullPin(string pin)
		{
			pin = pin == null ? "" : pin;
			return pin.Length < 8 ? pin + pin.Substring(0, 8 - pin.Length) : pin;
		}
    }
}
