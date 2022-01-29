using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows;
using System.Threading;

namespace RegexTesterUI.Data
{
    public class Web : IData
    {
        public string Path { get; set; }
        public CancellationToken token;
        public Web(CancellationToken token,string path)
        {
            this.token = token;
            this.Path = path;
        }

        /// <summary>
        /// Returns string of html or other format from api's
        /// </summary>
        /// <returns></returns>
        public string DataFromSource()
        {
            string result = "";

            if (Uri.IsWellFormedUriString(Path, UriKind.Absolute))
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Path);

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        token.ThrowIfCancellationRequested();
                        if(response.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader reader = new StreamReader(response.GetResponseStream());
                            result = reader.ReadToEnd();
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }
            else
            {
                result = $"URL string is not formatted properly";

                return result;
            }
            return result;
        }

    }
}
