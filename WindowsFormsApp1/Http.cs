using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Http
    {
        
        public static byte[] Post(string url, NameValueCollection pairs)
        {
          
            using (WebClient webClient = new WebClient()) 
            {
                return webClient.UploadValues(url, pairs);
            }
        }

    }
}
