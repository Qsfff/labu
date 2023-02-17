using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Markup;


namespace PiOGI_z5_server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int port = 8888;
        static TcpListener listener;
        const int Number = 30000;
        NetworkStream[] stream = new NetworkStream[Number];
        bool work = false;
        Thread listenThread;
        bool ip = false;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < Number; i++)
            {
                stream[i] = null;
            }
        }
        void listen()
        {
            if (!work) Thread.Sleep(Timeout.Infinite);
            for (int i = 0; (work) && (i < Number); i++)
            {
                TcpClient client = listener.AcceptTcpClient();
                stream[i] = null;
                stream[i] = client.GetStream();
                byte[] data = new byte[64];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream[i].Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream[i].DataAvailable);
                string message = builder.ToString();
                Dispatcher.BeginInvoke(new Action(() => log.Items.Add(builder.ToString() + " подключен.")));
                data = Encoding.Unicode.GetBytes("m" + builder.ToString() + " подключен.");
                stream[i].Write(data, 0, data.Length);
                Thread clientThread = new Thread(() => Process(client, stream[i]));
                clientThread.Start();
            }
        }
        public void Process(TcpClient tcpClient, NetworkStream strea)
        {
            TcpClient client = tcpClient;

            try
            {
                strea = client.GetStream();

                byte[] data = new byte[64];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = strea.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (strea.DataAvailable);
                    string message = builder.ToString();
                    if (message[0] == 'm')
                    {
                        message = message.Remove(0, 1);
                        Dispatcher.BeginInvoke(new Action(() => log.Items.Add(message)));
                        string back = new string(message.Remove(0, message.IndexOf(": ") + 2).Reverse().ToArray());
                        back = "m" + back;
                        data = Encoding.Unicode.GetBytes(back);
                        strea.Write(data, 0, data.Length);
                    }
                    if (message[0] == 'd') 
                    {
                        message = message.Remove(0, 1);
                        Dispatcher.BeginInvoke(new Action(() => log.Items.Add(message + " отключен.")));
                        string back = "m" + message;
                        data = Encoding.Unicode.GetBytes(back + " отключен.");
                        strea.Write(data, 0, data.Length);
                        data = Encoding.Unicode.GetBytes("d");
                        strea.Write(data, 0, data.Length);
                        strea.Close();
                        strea = null;
                        client.Close();
                        client = null;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(new Action(() => log.Items.Add(ex.Message)));
            }
            finally
            {
                if (strea != null)
                    strea.Close();
                if (client != null)
                    client.Close();
            }
        }

        private void strat(object sender, RoutedEventArgs e)
        {
            work = true;
            if (!ip)
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                ip = true;
            }
            listener.Start();
            listenThread = new Thread(() => listen());
            listenThread.Start();
            Dispatcher.BeginInvoke(new Action(() => log.Items.Add("Сервер подключен.")));
        }
        private void sotp(object sender, RoutedEventArgs e)
        {
            if (work)
            {
                byte[] data = new byte[64];
                data = Encoding.Unicode.GetBytes("s");
                for (int i = 0; i < Number; i++)
                {
                    if (stream[i] != null) stream[i].Write(data, 0, data.Length);
                }
                work = false;
                Dispatcher.BeginInvoke(new Action(() => log.Items.Add("Сервер отключен.")));
                listenThread.Suspend();
            }
        }
    }
}