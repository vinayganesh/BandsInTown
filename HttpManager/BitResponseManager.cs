using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Microsoft.VisualBasic;

namespace HttpManager
{
    public class BitResponseManager
    {
        public static async Task<string> ReadResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var jsonMessage = new StreamReader(responseStream).ReadToEnd();
                    return jsonMessage;
                }
            }
            else
            {
                Debug.WriteLine(response.StatusCode);
            }
            return null;
        }
    }
}
