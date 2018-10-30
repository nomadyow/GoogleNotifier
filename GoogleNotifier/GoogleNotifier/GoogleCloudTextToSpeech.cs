using System;
using System.IO;
using System.Globalization;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Google.Cloud.TextToSpeech.V1;
using System.Windows.Forms;
using System.Collections.Generic;


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

        public class VoiceItem
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Language { get; set; }

            public override string ToString()
            {
                return Name;
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

        public static List<VoiceItem> ListVoices(Grpc.Core.Channel channel)
        {
            TextToSpeechClient client = TextToSpeechClient.Create(channel);

            // Performs the list voices request
            var response = client.ListVoices(new ListVoicesRequest
            { });

            List<VoiceItem> voices = new List<VoiceItem>();

            foreach (Voice voice in response.Voices)
            {
                foreach (var languageCode in voice.LanguageCodes)
                {
                    VoiceItem voiceItem = new VoiceItem
                    {
                        Name = voice.Name,
                        Gender = voice.SsmlGender.ToString(),
                        Language = languageCode,
                    };
                    voices.Add(voiceItem);
                }
            }
            return voices;
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
