using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
//using Newtonsoft.Json;
//using System.Text.RegularExpressions;
//using WebSocketSharp;
//using System.Configuration;
using System.Runtime.InteropServices;

namespace poe.trade_live_search
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        NotificationForm notificationForm = new NotificationForm();
        List<ItemData> PoetradeList = new List<ItemData>(), PoeList = new List<ItemData>();
        List<WS> SitesList = new List<WS>();
        List<ItemData> ItemsList = new List<ItemData>();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"notification.wav");

        IniFile configFile = new IniFile("Config.ini");

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            siteComboBox.SelectedIndex = 0;

            //double.TryParse(configFile.Read("poetradegooddealchaos"), out poetradeGoodDealChaos);
            //double.TryParse(configFile.Read("poetradegooddealexalted"), out poetradeGoodDealExalted);
        }

        public static async Task<string> post_Request(string host, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            var response = await httpClient.PostAsync(host, content);
            return await response.Content.ReadAsStringAsync();
        }

        //private bool good_Deal(ItemData item)
        //{
        //    if (item.Buyout.Contains("chaos"))
        //    {
        //        if (double.Parse(item.Buyout.Remove(item.Buyout.Length - " chaos".Length)) <= poetradeGoodDealChaos)
        //            return true;
        //    }
        //    else if (item.Buyout.Contains("exalted"))
        //    {
        //        if (double.Parse(item.Buyout.Remove(item.Buyout.Length - " exalted".Length)) <= poetradeGoodDealExalted)
        //            return true;
        //    }
        //    else if (String.IsNullOrEmpty(item.Buyout))
        //        return false;
        //    return false;
        //}

        public void create_Notification(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.create_Notification), text);
                //this.Invoke((Action)delegate { create_Notification(text); });
            }
            else
            {
                notificationForm.ShowForm(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void poetradeApplyDealButton_Click(object sender, EventArgs e)
        {
            configFile.Write("poetradegooddealchaos", poetradeCDealTextBox.Text);
            configFile.Write("poetradegooddealexalted", poetradeExDealTextBox.Text);

            //poetradeGoodDealExalted = Double.Parse(poetradeExDealTextBox.Text);
            //poetradeGoodDealChaos = Double.Parse(poetradeCDealTextBox.Text);
        }

        private void poetradeStopButton_Click(object sender, EventArgs e)
        {
            int[] arr = new int[linksListBox.CheckedIndices.Count];
            linksListBox.CheckedIndices.CopyTo(arr, 0);

            foreach (int i in arr)
            {
                SitesList[i].Stop_WS();
            }

            Array.Reverse(arr);
            foreach (int i in arr)
            {
                SitesList.RemoveAt(i);
                linksListBox.Items.RemoveAt(i);
            }
        }

        private void poetradeStartButton_Click(object sender, EventArgs e)
        {
            WS obj;
            string type;

            foreach (var item in SitesList)
            {
                if (item.Link == linkTextBox.Text)
                {
                    Log("duplicate");
                    return;
                }
            }

            if (siteComboBox.SelectedIndex == 0)
            {
                obj = new PoetradeClass(linkTextBox.Text, this, nameTextBox.Text);
                type = "poe.trade";
            }
            else
            {
                obj = new PoetradeClass(linkTextBox.Text, this, nameTextBox.Text);
                type = "pathofexile.com";
            }

            obj.OnData += (ss, ee) =>
            {
                player.Play();
                foreach (var item in ee.Items)
                {
                    bool appOpen = AppChecker.IsApplicationActivated("PathOfExile_x64Steam");
                    Add_Item_To_List(item, type, obj.Name, appOpen);
                }
            };

            obj.OnOpen += (ss, ee) =>
                Log(obj.Name + " - " + obj.Link + ": Connected");

            obj.OnClose += (ss, ee) =>
                Log(obj.Name + " - " + obj.Link + ": Disconnected");

            SitesList.Add(obj);
            linksListBox.Items.Add(type + " - " + obj.Name + ": " + obj.Link);
        }

        public void Add_Item_To_List(ItemData item, string site, string name, bool appOpen) {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<ItemData,string,string, bool>(this.Add_Item_To_List), item, site, name, appOpen);
            }
            else
            {
                ListBox listBox = itemsListBox;
                string fixedString = "";
                if (item.Fixed)
                    fixedString = "fixed ";
                if (appOpen)
                {
                    Item_to_Clipboard(item);
                    create_Notification(item.Ign + "; " + fixedString + item.Buyout);
                }
                listBox.Items.Insert(0, site + " - " + name + ": " + item.Ign + "; " + fixedString + item.Buyout);
                ItemsList.Add(item);
                //    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                //    wplayer.URL = "notification.wav";
                //    wplayer.controls.play();
                //    if (!String.IsNullOrEmpty(itemDataList[i].Buyout))
            }
        }

        private void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item_to_Clipboard(ItemsList[ItemsList.Count - 1 - itemsListBox.SelectedIndex]);
        }

        public void Log(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(this.Log), log);
            }
            else
            {
                logText.Text += log + "\r\n";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (WS ws in SitesList)
            {
                ws.Stop_WS();
            }
        }

        private void Item_to_Clipboard(ItemData item)
        {
            string clipText = "@" + item.Ign + " Hi, I would like to buy your " + item.Name + " listed for " + item.Buyout + " in " + item.League;
            if (item.Tab != "")
                clipText += " (stash tab \"" + item.Tab + "\"; position: left " + (item.X + 1) + ", top " + (item.Y + 1) + ")";
            Clipboard.SetText(clipText);
        }
    }

    public class ItemData
    {
        public string Buyout { get; set; }
        public bool Fixed { get; set; }
        public string Ign { get; set; }
        public string League { get; set; }
        public string Name { get; set; }
        public string Tab { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    class IniFile
    {
        readonly string Path;
        readonly string EXE = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new System.IO.FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
