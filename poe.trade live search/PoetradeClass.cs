//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace poe.trade_live_search
{
    class PoetradeClass : WS
    {
        int newId = -1;

        public PoetradeClass(string link, MainForm form, string name) : base(form, link, name)
        {
            Start_WS("ws://live.poe.trade/" + link);
        }

        protected override List<ItemData> Get_Data(string host)
        {
            Task<string> task = MainForm.post_Request("http://poe.trade/search/" + host + "/live", new Dictionary<string, string> { { "id", newId.ToString() } });
            task.Wait();

            JsonData jsonData = new JavaScriptSerializer().Deserialize<JsonData>(task.Result);
            //JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(task.Result);
            List<ItemData> itemDataList = new List<ItemData>();

            if (jsonData.Count > 0)
            {
                string parsedData = jsonData.Data.Substring(jsonData.Data.IndexOf("<tbody"));
                parsedData = parsedData.Remove(parsedData.LastIndexOf("</tbody>") + "</tbody>".Length);
                string[] parsedTextArray = parsedData.Split(new[] { "</tbody>" }, StringSplitOptions.None);

                for (int i = 0; i < jsonData.Count; i++)
                {
                    ItemData id = new ItemData();
                    string St = parsedTextArray[i];
                    id.Buyout = Regex.Match(St, @"data-buyout=""(.*?)""").Groups[1].Value;
                    id.Fixed = St.Contains("fixed");
                    id.Ign = Regex.Match(St, @"data-ign=""(.*?)""").Groups[1].Value;
                    id.League = Regex.Match(St, @"data-league=""(.*?)""").Groups[1].Value;
                    id.Name = Regex.Match(St, @"data-name=""(.*?)""").Groups[1].Value;
                    id.Tab = Regex.Match(St, @"data-tab=""(.*?)""").Groups[1].Value;
                    if (id.Tab != "")
                    {
                        id.X = Int32.Parse(Regex.Match(St, @"data-x=""(.*?)""").Groups[1].Value);
                        id.Y = Int32.Parse(Regex.Match(St, @"data-y=""(.*?)""").Groups[1].Value);
                    }
                    itemDataList.Add(id);
                }
            }
            newId = jsonData.Newid;
            return itemDataList;
        }
    }

    class JsonData
    {
        public int Count { get; set; }
        public string Data { get; set; }
        public int Newid { get; set; }
        public IList<string> Uniqs { get; set; }
        public override string ToString()
        {
            return "{Count: " + this.Count.ToString() + ",\r\nData: " + this.Data + ",\r\nNewid: " + this.Newid.ToString() + ",\r\nUniqs: " + this.Uniqs.Count + "}";
        }
    }
}