using SuperSocket.ClientEngine;
using System;
using System.Threading;
using WebSocket4Net;

namespace TaskManagerClient.BasicClasses
{
    class WSocClient
    {
        private AutoResetEvent messageReceiveEvent = new AutoResetEvent(false);
        private string lastMessageReceived;
        private WebSocket webSocket;

        private static WSocClient instance;

        public static WSocClient getInstance()
        {
            if (instance == null)
                instance = new WSocClient();
            return instance;
        }



        public WSocClient(string uri = "ws://localhost:8888")
        {
            Console.WriteLine("Initializing websocket. Uri: " + uri);
            webSocket = new WebSocket(uri);
            webSocket.Opened += new EventHandler(websocket_Opened);
            webSocket.Closed += new EventHandler(websocket_Closed);
            webSocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
            webSocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            webSocket.Open();

            while (webSocket.State == WebSocketState.Connecting) { };   
                                                                        
            if (webSocket.State != WebSocketState.Open)
            {
                throw new Exception("Connection is not opened.");
            }
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Websocket is opened.");
        }
        private void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }
        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("Websocket is closed.");
        }

        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine("Message received: " + e.Message);
            lastMessageReceived = e.Message;
            messageReceiveEvent.Set();
            ResponseWs response = new ResponseWs(e.Message);


        }

        public void Send(string str)
        {
            webSocket.Send(str);
        }



    }
}
