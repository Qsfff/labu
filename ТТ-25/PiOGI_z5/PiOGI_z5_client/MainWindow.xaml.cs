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


namespace PiOGI_z5_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int port = 8888;
        string address = "127.0.0.1";
        TcpClient client = null;
        NetworkStream stream = null;
        string username = "";


        public MainWindow()
        {
            InitializeComponent();
        }
        void listen()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    if (message[0] == 'm')
                    {
                        message = message.Remove(0, 1);
                        Dispatcher.BeginInvoke(new Action(() => log.Items.Add("Сервер: " + message)));
                    }
                    if (message[0] == 'd')
                    {
                        stream.Close();
                        stream = null;
                        client.Close();
                        client = null;
                        break;
                    }
                    if (message[0] == 's')
                    {
                        Dispatcher.BeginInvoke(new Action(() => log.Items.Add("Сервер отключается")));
                        message = "d" + username;
                        data = Encoding.Unicode.GetBytes(message);
                        stream.Write(data, 0, data.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Items.Add(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
        private void con(object sender, RoutedEventArgs e)
        {
            if (name.Text != "")
            {
                username = name.Text;
                try
                {
                    client = new TcpClient(address, port);
                    stream = client.GetStream();
                    byte[] data = Encoding.Unicode.GetBytes(username);
                    stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    log.Items.Add(ex.Message);
                }
                Thread listenThread = new Thread(() => listen());
                listenThread.Start();
            }
            else MessageBox.Show("BBedite imya", "Ashipka");
        }

        private void nicon(object sender, RoutedEventArgs e)
        {
            if (stream != null)
            {
                string message = "d" + username;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            else MessageBox.Show("Not connected", "Ashipka");
        }

        private void msgg(object sender, RoutedEventArgs e)
        {
            if (stream != null)
            {
                string message = msg.Text;
                message = String.Format("{0}: {1}", username, message);
                message = "m" + message;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
           else MessageBox.Show("Not connected", "Ashipka");
        }
    }
}
