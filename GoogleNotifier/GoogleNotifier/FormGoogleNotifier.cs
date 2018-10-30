using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using GoogleCast;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GoogleNotifier

{
    public partial class FormGoogleNotifier : Form
    {
        private IEnumerable<IReceiver> receivers;
        static public FormGoogleNotifier formGoogleNotifier;
        private SimpleHTTPServer simpleHTTPServer;
        static public Dictionary<string, MemoryStream> textToSpeechFiles = new Dictionary<string, MemoryStream>();
        private string localIP;
        static public bool webServerListening;
        static public string webServerError = "";
        static public int webServerPort;
        private class GoogleReceiverItem
        {
            public string Text { get; set; }
            public string Id { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public FormGoogleNotifier()
        {
            formGoogleNotifier = this;
            InitializeComponent();
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        private void buttonSelectJson_Click(object sender, EventArgs e)
        {
            if (openFileDialogCredentials.ShowDialog() == DialogResult.OK)
            {
                textBoxJsonCredendials.Text = openFileDialogCredentials.FileName;
                Properties.Settings.Default.credentialsFile = openFileDialogCredentials.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private async void findReceivers()
        {
            receivers = await new DeviceLocator().FindReceiversAsync();
            
            foreach (var receiver in receivers)
            {
                GoogleReceiverItem item = new GoogleReceiverItem
                {
                    Text = receiver.FriendlyName,
                    Id = receiver.Id
                };
                this.Invoke((MethodInvoker)delegate
                {
                    int index = comboBoxGoogleCastReceivers.Items.Add(item);
                    if (receiver.Id == Properties.Settings.Default.defaultCastDevice)
                    {
                        comboBoxGoogleCastReceivers.SelectedIndex = index;
                    }
                });
            }
            
        }

        private void StartWebServer()
        {
            try
            {
                simpleHTTPServer = new SimpleHTTPServer(Properties.Settings.Default.webServerPort);
                toolStripStatusLabelWebServerStatus.Text = "Listening";
                toolStripStatusLabelWebServerStatus.ForeColor = Color.ForestGreen;
            }
            catch
            {
                webServerListening = false;
            }
        }

        private void tick()
        {
            toolStripStatusLabelWebServerStatus.Text = "Not Listening";
            toolStripStatusLabelWebServerStatus.ForeColor = Color.Maroon;
            if (webServerError == "failed to start")
            {
                webServerError = "";
                // Show error form
            }
        }

        private void FormGoogleNotifier_Load(object sender, EventArgs e)
        {
            if (File.Exists(Properties.Settings.Default.credentialsFile))
            {
                textBoxJsonCredendials.Text = Properties.Settings.Default.credentialsFile;
            }
            Task task = new Task(new Action(findReceivers));
            task.Start();

            labelIPAddress.Text = GetLocalIPAddress();

            numericUpDownPort.Value = Properties.Settings.Default.webServerPort;
            textBoxAuthToken.Text = Properties.Settings.Default.authToken;
            checkBoxRequireAuthToken.Checked = Properties.Settings.Default.requireAuth;
            checkBoxRemoteEnabled.Checked = Properties.Settings.Default.remoteCommandsEnabled;

            StartWebServer();
        }

        private void FormGoogleNotifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            GoogleReceiverItem item = comboBoxGoogleCastReceivers.SelectedItem as GoogleReceiverItem;
            Properties.Settings.Default.defaultCastDevice = item.Id.ToString();
            Properties.Settings.Default.webServerPort = Convert.ToInt32(numericUpDownPort.Value);
            Properties.Settings.Default.authToken = textBoxAuthToken.Text;
            Properties.Settings.Default.requireAuth = checkBoxRequireAuthToken.Checked;
            Properties.Settings.Default.remoteCommandsEnabled = checkBoxRemoteEnabled.Checked;
            Properties.Settings.Default.Save();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int newWebServerPort = Convert.ToInt32(numbericUpDownPort.Value);
            if (webServerPort != newWebServerPort)
            {
                Properties.Settings.Default.webServerPort = newWebServerPort;
                webServerPort = newWebServerPort;
                Properties.Settings.Default.Save();
                StartWebServer();
            }
        }
    }
}
