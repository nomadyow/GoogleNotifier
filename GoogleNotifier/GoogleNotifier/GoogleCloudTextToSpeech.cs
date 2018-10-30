using System;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Google.Cloud.TextToSpeech.V1;
using System.Windows.Forms;
using GoogleCast;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleNotifier
{
    public partial class FormGoogleNotifier : Form
    {
        public void authenticateGoogle()
        {
            if (File.Exists(Properties.Settings.Default.credentialsFile))
            {
                try
                {
                    GoogleCredential credential = GoogleCredential.FromFile(Properties.Settings.Default.credentialsFile);

                    googleCloudChannel = new Grpc.Core.Channel(TextToSpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
                }
                catch (Exception ex)
                {
                    googleCloudChannel = null;
                }
            }
        }
    }
}
