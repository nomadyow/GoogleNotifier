using System;
using System.IO;
using System.Globalization;
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
        public class LanguageItem
        {
            public string Text { get; set; }
            public string Id { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public Grpc.Core.Channel authenticateGoogle()
        {
            Grpc.Core.Channel googleCloudChannel = null;
            if (File.Exists(Properties.Settings.Default.credentialsFile))
            {
                try
                {
                    GoogleCredential credential = GoogleCredential.FromFile(Properties.Settings.Default.credentialsFile);

                    googleCloudChannel = new Grpc.Core.Channel(TextToSpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
                }
                catch (Exception ex)
                { }
            }
            return googleCloudChannel;
        }
        public static Dictionary<string, LanguageItem> ListVoiceLanguages(Grpc.Core.Channel channel)
        {
            TextToSpeechClient client = TextToSpeechClient.Create(channel);

            Dictionary<string,LanguageItem> languages = new Dictionary<string,LanguageItem>();
            // Performs the list voices request
            var response = client.ListVoices(new ListVoicesRequest { });
            foreach (Voice voice in response.Voices)
            {
                foreach (var languageCode in voice.LanguageCodes)
                {
                    if (!languages.ContainsKey(languageCode.ToString()))
                    {
                        string displayName = languageCode + " | " + new CultureInfo($"{languageCode}").DisplayName;
                        LanguageItem newItem = new LanguageItem
                        {
                            Text = displayName,
                            Id = languageCode
                        };

                        languages.Add(languageCode, newItem);
                    }
                }
            }
            return languages;
        }
        public static int ListVoices(Grpc.Core.Channel channel, string desiredLanguageCode = "")
        {
            TextToSpeechClient client = TextToSpeechClient.Create(channel);

            // Performs the list voices request
            var response = client.ListVoices(new ListVoicesRequest
            {
                LanguageCode = desiredLanguageCode
            });

            foreach (Voice voice in response.Voices)
            {
                // Display the voices's name.
                Console.WriteLine($"Name: {voice.Name}");

                // Display the supported language codes for this voice.
                foreach (var languageCode in voice.LanguageCodes)
                {
                    Console.WriteLine($"Supported language(s): {languageCode}");
                    Console.WriteLine(new CultureInfo($"{languageCode}").DisplayName);
                }

                // Display the SSML Voice Gender
                Console.WriteLine("SSML Voice Gender: " +
                    (SsmlVoiceGender)voice.SsmlGender);

                // Display the natural sample rate hertz for this voice.
                Console.WriteLine("Natural Sample Rate Hertz: " +
                    voice.NaturalSampleRateHertz);
            }
            return 0;
        }

        public string text_to_mp3(string text, Grpc.Core.Channel channel)
        {
            TextToSpeechClient client = TextToSpeechClient.Create(channel);

            var input = new SynthesisInput
            {
                Text = text

            };

            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "USen",
                SsmlGender = SsmlVoiceGender.Female

            };
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };

            var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);

            string filename = Guid.NewGuid().ToString() + ".mp3";

            MemoryStream newTextToSpeech = new MemoryStream();
            response.AudioContent.WriteTo(newTextToSpeech);

            textToSpeechFiles[filename] = newTextToSpeech;

            return filename;
        }
    }
}
