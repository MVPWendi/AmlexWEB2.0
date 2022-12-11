using Newtonsoft.Json;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmlexWebPlugin
{
    public static class Monitoring
    {
        public static string SendRequestJson(string methodName, object content)
        {
            // Сериализуем в JSON то что отправляем
            var stringPayload = JsonConvert.SerializeObject(content);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"{Plugin.Instance.Configuration.Instance.WebAddress}/{methodName}");
            req.ContentType = "application/json";
            req.Method = "POST";
            req.Headers.Add("Authorization", $"Basic {Plugin.Instance.Configuration.Instance.BasicAuth}");
            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                streamWriter.Write(stringPayload);
            }
            // try catch чтоб ловить 400 ошибку, например, полукостыль в общем
            try
            {
                using (WebResponse response = req.GetResponse())
                {
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        return text;
                    }
                }
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine($"ERROR IN  SENDREQUESTJSON Error code: {httpResponse.StatusCode}, Error message: {e.Message}");
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        return text;
                    }
                }
            }
        }
        public static Server GetServerInfo()
        {
            return new Server
            {
                CurrentPlayers = Provider.clients.Count(),
                MaxPlayers = Provider.maxPlayers,
                Enabled = true,
                IP = Plugin.Instance.Configuration.Instance.IP,
                Port = Provider.port.ToString(),
                Name = Plugin.Instance.Configuration.Instance.ServerName,
                Players = new List<UserMonitoring>()
            };
        }
    }
}
