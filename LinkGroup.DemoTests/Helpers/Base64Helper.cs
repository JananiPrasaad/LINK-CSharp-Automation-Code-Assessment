using System;
using System.Collections.Generic;
using System.Text;

namespace LinkGroup.DemoTests.Helpers
{
    public class Base64Helper
    {

        #region Private Members
        #endregion

        #region Properties
        #endregion

        #region Public Methods
        public static string Base64Encode(string plainText)
        {
            string base64EncodedData = string.Empty;
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                base64EncodedData = System.Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception exception)
            {
            }
            return base64EncodedData;
        }

        public static string Base64Decode(string base64EncodedData)
        {
            string plainText = string.Empty;
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                plainText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception exception)
            {
            }
            return plainText;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
