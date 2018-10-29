// MIT License - Copyright (c) 2016 Can Güney Aksakalli
// https://aksakalli.github.io/2014/02/24/simple-http-server-with-csparp.html

using System;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoogleNotifier
{
    public class SimpleHTTPServer
    {
        private Thread _serverThread;
        private HttpListener _listener;
        private int _port;

        public int Port
        {
            get { return _port; }
            private set { }
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="port">Port of the server.</param>
        public SimpleHTTPServer(int port)
        {
            this.Initialize(port);
        }

        /// <summary>
        /// Stop server and dispose all functions.
        /// </summary>
        public void Stop()
        {
            _serverThread.Abort();
            _listener.Stop();
        }

        private void Listen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            bool serverStarted = false;
            try
            {
                _listener.Start();
                serverStarted = true;
                
            }
            catch (Exception ex)
            {
                
            }

            while (serverStarted)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    Process(context);
                }
                catch (ThreadAbortException)
                {
                    // Web server is shutting down - don't bother to log this specifically
                }
                catch (Exception ex)
                { }
            }
        }

        private bool IsAuthorizedToken(string body)
        {
            Dictionary<string, dynamic> result = null;
            try
            {
                result = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(body);
            }
            catch
            {
                return false;
            }
            if (result != null && result.ContainsKey("token") && result["token"] == Properties.Settings.Default.authToken)
            {
                return true;
            }

            return false;
        }

        private void Process(HttpListenerContext context)
        {
            // Knock off the initial slash
            string url = context.Request.Url.AbsolutePath.Substring(1);
            // The first part of the remaining path tells us if this is a cast call or a command.   Split on that.
            if (url.Contains("/"))
            {
                string[] parts = url.Split(new char[] { '/' }, 2);
                switch (parts[0])
                {
                    case "command":
                        // Commands need to have an auth token supplied in the body
                        var body = new StreamReader(context.Request.InputStream).ReadToEnd();
                        if (!IsAuthorizedToken(body))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return;
                        }
                        else
                        {
                            switch (parts[1])
                            {
                                case "transparent":
                                   
                                    context.Response.ContentType = "text/html";
                                    context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                                    context.Response.AddHeader("Last-Modified", DateTime.Now.ToString("r"));
                                    context.Response.StatusCode = (int)HttpStatusCode.OK;

                                    string text = "Ok";
                                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);

                                    context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                                    context.Response.OutputStream.Flush();
                                    context.Response.OutputStream.Close();
                                    return;
                                default:
                                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                                    return;
                            }
                        }
                    case "cast":
                        string filename = parts[1];

                        if (string.IsNullOrEmpty(filename))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            context.Response.OutputStream.Flush();
                            context.Response.OutputStream.Close();
                            return;
                        }

                        if (FormGoogleNotifier.textToSpeechFiles.ContainsKey(filename))
                        {
                            try
                            {
                                Stream input = FormGoogleNotifier.textToSpeechFiles[filename];

                                input.Seek(0, 0);

                                //Adding permanent http response headers
                                context.Response.ContentType = "audio/mpeg";
                                context.Response.ContentLength64 = input.Length;
                                context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                                context.Response.AddHeader("Last-Modified", DateTime.Now.ToString("r"));

                                byte[] buffer = new byte[1024 * 16];
                                int nbytes;

                                while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    context.Response.OutputStream.Write(buffer, 0, nbytes);
                                }
                                input.Close();

                                context.Response.StatusCode = (int)HttpStatusCode.OK;
                                context.Response.OutputStream.Flush();
                                context.Response.OutputStream.Close();
                                // Dispose of the audio Stream
                                FormGoogleNotifier.textToSpeechFiles.Remove(filename);
                            }
                            catch (Exception ex)
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            }
                        }
                        break;
                    default:
                        string remoteIP = context.Request.RemoteEndPoint.Address.ToString();
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Response.OutputStream.Flush();
                context.Response.OutputStream.Close();
            }
        }

        private void Initialize(int port)
        {
            this._port = port;
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
        }
    }
}
