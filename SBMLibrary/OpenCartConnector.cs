using RussLibrary.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SBMLibrary
{
    public class OpenCartConnector
    {
        const string LoginURLFormat = "{0}index.php?route=common/login";
        const string QuantityUploadURLFormat = "{0}index.php?route=report/stock&{1}";

        const string QuantityUpdateSuccessString = "Upload was succesful";

        const string QuantityUpdateFormName = "uploadPos";
        const string CSVType = "application/vnd.ms-excel";

        private OpenCartConnector()
        {
            LastProcessSuccess = true;
            if (!Configuration.Current.OpenCartAdminURL.EndsWith("/"))
            {
                Configuration.Current.OpenCartAdminURL = Configuration.Current.OpenCartAdminURL + "/";
            }
            try
            {
                using (var client = new CookieWebClient())
                {

                    var values = new NameValueCollection
                    {
                        { "username", Configuration.Current.OpenCartUsername },
                        { "password", Configuration.Current.OpenCartPassword },
                    };
                    byte[] b = client.UploadValues(string.Format(LoginURLFormat, Configuration.Current.OpenCartAdminURL), values);


                    cookies = client.CookieContainer;

                    string x = System.Text.ASCIIEncoding.UTF8.GetString(b);
                    //token=686fc274c18ff279662a39bc57490c2f'

                    int posstart = x.IndexOf("token=");
                    int posend = x.IndexOf("'", posstart);
                    Token = x.Substring(posstart, posend - posstart);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                LastProcessSuccess = false;
            }
        }

        public string ErrorMessage { get; set; }

        private string Token { get; set; }
        CookieContainer cookies = null;
        public static OpenCartConnector UploadQuantityChanges()
        {

            KeyValuePair<string, string> result = Cache.Current.ReadyForOpenCartUpdate.ExportActivityToCSV();

            OpenCartConnector retVal = null;
            if (!string.IsNullOrEmpty(result.Value))
            {
                retVal = new OpenCartConnector();
                if (retVal.LastProcessSuccess)
                {
                    retVal.UploadFilesToRemoteUrl(string.Format(QuantityUploadURLFormat, Configuration.Current.OpenCartAdminURL, retVal.Token), result.Value,
                            QuantityUpdateFormName, CSVType, new NameValueCollection(), QuantityUpdateSuccessString,
                            string.Format("POSQuantityUpdateUpload_{0}.csv", DateTime.Now.ToString("yyyyMMddHHmmss")));
                }
            }
            if (!string.IsNullOrEmpty(result.Key))
            {
                if (string.IsNullOrEmpty(retVal.ErrorMessage))
                {
                    retVal.ErrorMessage = result.Key;
                }

                else
                {
                    retVal.ErrorMessage += "\r\n\r\n" + result.Key;
                }
            }
            return retVal;
        }

        public bool LastProcessSuccess { get; set; }

        private void UploadFilesToRemoteUrl(string url, string fileData, string FormFileNameField, string contentType,
           NameValueCollection nvc, string successConfirm, string filename)
        {

            try
            {
                string boundary = "----WebKitFormBoundary" + DateTime.Now.Ticks.ToString("x");

                //----WebKitFormBoundary8eTSdfWMmZzOBme6
                //----------------------------8d1222ee216c781
                HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest2.ContentType = "multipart/form-data; boundary=" + boundary;
                httpWebRequest2.Method = "POST";
                httpWebRequest2.KeepAlive = true;
                httpWebRequest2.CookieContainer = cookies;

                httpWebRequest2.UserAgent = "Russ Judge Special";
                //httpWebRequest2.Connection = "keep-alive";
                httpWebRequest2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";



                using (Stream memStream = new System.IO.MemoryStream())
                {
                    byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


                    string formdataTemplate = "\r\n--" + boundary +
                    "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

                    foreach (string key in nvc.Keys)
                    {
                        string formitem = string.Format(formdataTemplate, key, nvc[key]);
                        byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                        memStream.Write(formitembytes, 0, formitembytes.Length);
                    }


                    memStream.Write(boundarybytes, 0, boundarybytes.Length);

                    string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";



                    //string header = string.Format(headerTemplate, "file" + i, files[i]);
                    string header = string.Format(headerTemplate, FormFileNameField, filename, contentType);

                    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                    memStream.Write(headerbytes, 0, headerbytes.Length);


                    byte[] buffer = System.Text.ASCIIEncoding.UTF8.GetBytes(fileData);

                    memStream.Write(buffer, 0, buffer.Length);
                    memStream.Write(boundarybytes, 0, boundarybytes.Length);




                    httpWebRequest2.ContentLength = memStream.Length;

                    using (Stream requestStream = httpWebRequest2.GetRequestStream())
                    {
                        memStream.Position = 0;
                        byte[] tempBuffer = new byte[memStream.Length];
                        memStream.Read(tempBuffer, 0, tempBuffer.Length);

                        requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                    }
                }

                using (WebResponse webResponse2 = httpWebRequest2.GetResponse())
                {
                    using (Stream stream2 = webResponse2.GetResponseStream())
                    {
                        StreamReader reader2 = new StreamReader(stream2);
                        string s = reader2.ReadToEnd();
                        if (!string.IsNullOrEmpty(successConfirm))
                        {
                            LastProcessSuccess = s.Contains(successConfirm);
                        }
                        else
                        {
                            LastProcessSuccess = false;

                        }
                        if (!LastProcessSuccess)
                        {
                            ErrorMessage = "Unable to confirm success with upload";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LastProcessSuccess = false;
                ErrorMessage = ex.Message;
            }

        }
    }
}
