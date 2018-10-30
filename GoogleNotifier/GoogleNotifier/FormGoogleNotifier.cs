using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using GoogleCast;
using System.Collections.Generic;
using System.Drawing;
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
        private Grpc.Core.Channel googleCloudChannel = null;
        static public bool webServerListening;
        static public string webServerError = "";
        static public int webServerPort;

        private static List<VoiceItem> allVoices = new List<VoiceItem>();

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
            try
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
            catch { }
            
        }

        private void StartWebServer()
        {
            webServerError = "";
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

        private void updateVoiceDisplay()
        {
            comboBoxVoice.Items.Clear();
            LanguageItem currentLanguage = comboBoxVoiceLanguages.SelectedItem as LanguageItem;
            foreach(VoiceItem voiceItem in allVoices)
            {
                if (voiceItem.Gender == comboBoxGender.SelectedItem.ToString() && voiceItem.Language == currentLanguage.Id)
                {
                    int index = comboBoxVoice.Items.Add(voiceItem);
                    if (Properties.Settings.Default.defaultVoice == voiceItem.Name)
                    {
                        comboBoxVoice.SelectedIndex = index;
                    }
                }
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

            googleCloudChannel = authenticateGoogle();
            int index;
            Dictionary<string, LanguageItem> languages = ListVoiceLanguages(googleCloudChannel);

            foreach (KeyValuePair<string, LanguageItem> entry in languages)
            {
                index = comboBoxVoiceLanguages.Items.Add(entry.Value);
                if (Properties.Settings.Default.defaultLanguage == entry.Key)
                {
                    comboBoxVoiceLanguages.SelectedIndex = index;
                }
            }

            index = comboBoxGender.Items.Add("Male");
            string voiceGender = Properties.Settings.Default.defaultGender;
            if (voiceGender == "Male")
            {
                comboBoxGender.SelectedIndex = index;
            }
            index = comboBoxGender.Items.Add("Female");
            if (voiceGender == "Female")
            {
                comboBoxGender.SelectedIndex = index;
            }

            ListVoices(googleCloudChannel);

            allVoices = ListVoices(googleCloudChannel);

            updateVoiceDisplay();
        }

        private void FormGoogleNotifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webServerListening)
            {
                try
                {
                    simpleHTTPServer.Stop();
                }
                catch { }
            }
            GoogleReceiverItem item = comboBoxGoogleCastReceivers.SelectedItem as GoogleReceiverItem;
            if (item != null)
            {
                Properties.Settings.Default.defaultCastDevice = item.Id.ToString();
            }
            Properties.Settings.Default.webServerPort = Convert.ToInt32(numericUpDownPort.Value);
            Properties.Settings.Default.authToken = textBoxAuthToken.Text;
            Properties.Settings.Default.requireAuth = checkBoxRequireAuthToken.Checked;
            Properties.Settings.Default.remoteCommandsEnabled = checkBoxRemoteEnabled.Checked;
            if (comboBoxGender.SelectedIndex >= 0)
            {
                Properties.Settings.Default.defaultGender = comboBoxGender.SelectedItem.ToString();
            }
            if (comboBoxVoiceLanguages.SelectedIndex >= 0)
            {
                LanguageItem selectedLanguage = comboBoxVoiceLanguages.SelectedItem as LanguageItem;
                Properties.Settings.Default.defaultLanguage = selectedLanguage.Id;
            }

            if (comboBoxVoice.SelectedIndex >= 0)
            {
                VoiceItem selectedVoice = comboBoxVoice.SelectedItem as VoiceItem;
                Properties.Settings.Default.defaultVoice = selectedVoice.Name.ToString();
            }

            Properties.Settings.Default.Save();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int newWebServerPort = Convert.ToInt32(numericUpDownPort.Value);
            if (webServerPort != newWebServerPort)
            {
                Properties.Settings.Default.webServerPort = newWebServerPort;
                webServerPort = newWebServerPort;
                Properties.Settings.Default.Save();
                StartWebServer();
            }
        }

        private void timerWebServerWatchdog_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelWebServerStatus.Text = "Not Listening";
            toolStripStatusLabelWebServerStatus.ForeColor = Color.Maroon;
            if (webServerError == "failed to start")
            {
                webServerError = "";
                Form formWebServerNotification = new FormWebServerNotification();
                formWebServerNotification.ShowDialog();
            }
        }

        private void comboBoxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateVoiceDisplay();
        }

        private void comboBoxVoiceLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateVoiceDisplay();
        }
    }
}
