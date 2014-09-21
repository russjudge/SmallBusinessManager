using RussLibrary.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnConnect(object sender, RoutedEventArgs e)
        {
          
            var values = new NameValueCollection
                    {
                        { "username", "russ" },
                        { "password", "1tennesseeb" },
                    };
            //string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            //string formDataHeaderTemplate = Environment.NewLine + "--" + boundary + Environment.NewLine +
            //    "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

            
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://test.deviumrocks.com/admin/index.php?route=common/login");
            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.UserAgent = "My goofy little User Agent (Russ Judge)";
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    foreach (string key in values.Keys)
            //    {
            //        byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format(formDataHeaderTemplate,
            //        key, values[key]));
            //        ms.Write(formItemBytes, 0, formItemBytes.Length);
            //    }
            //    ms.Position = 0;
            //    request.ContentLength = ms.Length;
            //    using (Stream reqStream = request.GetRequestStream())
            //    {
            //        byte[] buffer = new byte[1024];
            //        int bytesRead = ms.Read(buffer, 0, buffer.Length);
                    
                    
            //        while (bytesRead  >0)
            //        {
                        
            //            reqStream.Write(buffer, 0, bytesRead);
            //            bytesRead = ms.Read(buffer, 0, buffer.Length);
            //        }
                    
            //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    
            //        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            //        {
            //            string result = sr.ReadToEnd();
            //        }

            //    }
            //}


            //upload

            using (var client = new CookieWebClient())
            {

                byte[] b = client.UploadValues("http://test.deviumrocks.com/admin/index.php?route=common/login", values);

                string x = System.Text.ASCIIEncoding.UTF8.GetString(b);
                //token=686fc274c18ff279662a39bc57490c2f'

                int posstart = x.IndexOf("token=");
                int posend = x.IndexOf("'", posstart);
                string token = x.Substring(posstart, posend - posstart);
                // If the previous call succeeded we now have a valid authentication cookie
                // so we could download the protected page
                List<string> files = new List<string>();

                files.Add(@"E:\Users\Russ\SkyDrive\Fox One POS\TestExport_20140407.csv");


                UploadFilesToRemoteUrl(string.Format("http://test2.deviumrocks.com/admin/index.php?route=report/stock&{0}", token), files.ToArray(),
                    "uploadPos", "application/vnd.ms-excel", new NameValueCollection(), client.CookieContainer, "Upload was succesful");

                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://test.deviumrocks.com/admin/index.php?route=report/stock&{0}");
                //string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                //request.CookieContainer = client.CookieContainer;
                //request.Method = "POST";
                //request.ContentType = "multipart/form-data; boundary=" + boundary;

                //byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");


                //b = client.UploadFile(string.Format("http://test.deviumrocks.com/admin/index.php?route=report/stock&{0}", token), "");

                //string result = client.DownloadString(string.Format("http://test.deviumrocks.com/admin/index.php?route=report/stock&{0}&uploadPos={1}", token,));
            }

        }
        //return an object with both success/fail status and message if fail (exception, or confirmSuccess not matched).
        public static bool UploadFilesToRemoteUrl(string url, string[] files, string FormFileNameField, string contentType,
            NameValueCollection nvc, CookieContainer cookies, string successConfirm)
        {

            bool retval = true;
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

                    for (int i = 0; i < files.Length; i++)
                    {

                        //string header = string.Format(headerTemplate, "file" + i, files[i]);
                        string header = string.Format(headerTemplate, FormFileNameField, System.IO.Path.GetFileName(files[i]), contentType);

                        byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);

                        memStream.Write(headerbytes, 0, headerbytes.Length);


                        using (FileStream fileStream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1024];

                            int bytesRead = 0;

                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                            {
                                memStream.Write(buffer, 0, bytesRead);

                            }


                            memStream.Write(boundarybytes, 0, boundarybytes.Length);

                        }
                    }

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
                            retval = s.Contains(successConfirm);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                retval = false;
            }
            return retval;
        }

        void DownloadPOSUPdate()
        {
            var values = new NameValueCollection
                    {
                        { "username", "russ" },
                        { "password", "1tennesseeb" },
                    };
            using (var client = new CookieWebClient())
            {

                byte[] b = client.UploadValues("http://test.deviumrocks.com/admin/index.php?route=common/login", values);

                string x = System.Text.ASCIIEncoding.UTF8.GetString(b);
                //token=686fc274c18ff279662a39bc57490c2f'

                int posstart = x.IndexOf("token=");
                int posend = x.IndexOf("'", posstart);
                string token = x.Substring(posstart, posend - posstart);
                // If the previous call succeeded we now have a valid authentication cookie
                // so we could download the protected page
                string result = client.DownloadString(string.Format("http://test.deviumrocks.com/admin/index.php?route=report/stock&{0}&pos", token));
            }
        }
    }
}
