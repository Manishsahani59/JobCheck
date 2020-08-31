using System;
using System.Collections.Generic;
using System.Text;

namespace RepositeryLayer.Shared
{
   public class EncryptAndDecryptPassword
    { /// <summary>
      ///     Encode the Original string into a Encrypted form that ununderstatble for the other user
      /// </summary>
      /// <param name="password">Store the Password </param>
      /// <returns>Return the Password in the Encrypted Form</returns>
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
              
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        /// <summary>
        ///     Decrypt the Encrypted password into the original form
        /// </summary>
        /// <param name="encodedData">store the Encrtpted Password of the user</param>
        /// <returns>return the original form of the password</returns>
        public static string DecodeFrom64(string encodedData)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                string err = e.Message;
                throw new ApplicationException(err);
            }
        }

    }
}
