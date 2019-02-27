using System;
using System.Collections.Generic;
using WebSocketSharp;

namespace poe.trade_live_search
{
    public abstract class WS
    {
        protected abstract List<ItemData> Get_Data(string host);
        protected WebSocket wsclient;
        protected MainForm senderForm;
        protected string link;
        protected string name;

        public string Link { get => link; set => link = value; }
        public string Name { get => name; set => name = value; }

        public WS(MainForm form, string link, string name)
        {
            this.link = link;
            this.name = name;
            this.senderForm = form;
        }

        protected void Process_Data(List<ItemData> list)
        {
            DataEventArgs args = new DataEventArgs();
            args.Items = list;
            OnDataAction(args);
        }

        protected void Start_WS(string url)
        {
            wsclient = new WebSocket(url);

            wsclient.OnOpen += (ss, ee) =>
            {
                this.OnOpenAction();
                //Task.Run(async () => await post_Request("http://poe.trade/search/" + poetradeLink.Text + "/live")).Wait();
                Get_Data(this.link);
            };

            wsclient.OnClose += (ss, ee) =>
                this.OnCloseAction();

            wsclient.OnError += (ss, ee) =>
                this.OnErrorAction(ee);

            wsclient.OnMessage += (ss, ee) =>
            {
                var data = Get_Data(this.link);
                Process_Data(data);
            };

            wsclient.ConnectAsync();
        }

        public void Stop_WS()
        {
            wsclient.Close();
        }

        public event EventHandler OnOpen;
        public event EventHandler OnClose;
        public event EventHandler<ErrorEventArgs> OnError;
        public event EventHandler<MessageEventArgs> OnMessage;
        public event EventHandler<DataEventArgs> OnData;

        protected virtual void OnOpenAction()
        {
            OnOpen?.Invoke(this, new EventArgs());
        }

        protected virtual void OnCloseAction()
        {
            OnClose?.Invoke(this, new EventArgs());
        }

        protected virtual void OnErrorAction(ErrorEventArgs e)
        {
            OnError?.Invoke(this, e);
        }

        protected virtual void OnMessageAction(MessageEventArgs e)
        {
            OnMessage?.Invoke(this, e);
        }

        protected virtual void OnDataAction(DataEventArgs e)
        {
            OnData?.Invoke(this, e);
        }

        ~WS()
        {
            wsclient.Close();
        }

    }

    public class DataEventArgs : EventArgs
    {
        public List<ItemData> Items { get; set; }
    }
}
