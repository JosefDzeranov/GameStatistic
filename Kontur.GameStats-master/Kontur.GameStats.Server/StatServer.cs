using Kontur.GameStats.Server.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server
{
    internal class StatServer : IDisposable
    {
        public StatServer()
        {
            listener = new HttpListener();
        }

        public void Start(string prefix)
        {
            lock (listener)
            {
                if (!isRunning)
                {
                    listener.Prefixes.Clear();
                    listener.Prefixes.Add(prefix);
                    listener.Start();

                    listenerThread = new Thread(Listen)
                    {
                        IsBackground = true,
                        Priority = ThreadPriority.Highest
                    };
                    listenerThread.Start();

                    isRunning = true;
                }
            }
        }

        public void Stop()
        {
            lock (listener)
            {
                if (!isRunning)
                    return;

                listener.Stop();

                listenerThread.Abort();
                listenerThread.Join();

                isRunning = false;
            }
        }

        public void Dispose()
        {
            if (disposed)
                return;

            disposed = true;

            Stop();

            listener.Close();
        }

        private void Listen()
        {
            while (true)
            {
                try
                {
                    if (listener.IsListening)
                    {
                        var context = listener.GetContext();

                        Task.Run(() => HandleContextAsync(context));
                    }
                    else Thread.Sleep(0);
                }
                catch (ThreadAbortException ex)
                {

                    return;
                }
                catch (Exception error)
                {
                    // TODO: log errors
                }
            }
        }

        private async Task HandleContextAsync(HttpListenerContext listenerContext)
        {
            // TODO: implement request handling
            using (var reader = new StreamReader(listenerContext.Request.InputStream,
                                    listenerContext.Request.ContentEncoding))
            {
                var text = reader.ReadToEnd();
            }
            //ThreadPool.QueueUserWorkItem((_) =>
            //{
            //    string methodName = listenerContext.Request.Url.Segments[1].Replace("/", "");
            //    string[] strParams = listenerContext.Request.Url
            //                            .Segments
            //                            .Skip(2)
            //                            .Select(s => s.Replace("/", ""))
            //                            .ToArray();


            //    var method = this.GetType().GetMethod(methodName);
            //    object[] @params = method.GetParameters()
            //                        .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
            //                        .ToArray();

            //    object ret = method.Invoke(this, @params);
            //    //string retstr = JsonConvert.SerializeObject(ret);
            //});

            var type = SelectType(listenerContext.Request.HttpMethod, listenerContext.Request.Url.ToString());
            //var handler = MapRequestHandler(type);
            //handler.RequestHanle(url, json);

            listenerContext.Response.StatusCode = (int)HttpStatusCode.OK;
            using (var writer = new StreamWriter(listenerContext.Response.OutputStream))
                writer.WriteLine("Hello, world!");
        }
        public IRequestHandler MapRequestHandler(int type)
        {
            switch (type)
            {
                case 1: return new AllInfoServers();
                default: return new AllInfoServers();
            }

        }
        public int SelectType(string httpMethod, string url)
        {
            if (url == "/servers/info")
                return 1;
            string[] segments = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (segments[0] == "servers" && segments[2] == "info" && httpMethod == "GET")
            {
                return 2;
            }
            if (segments[0] == "servers" && segments[2] == "info" && httpMethod == "POST")
            {
                return 2;
            }
            return 2;
        }

        private readonly HttpListener listener;

        private Thread listenerThread;
        private bool disposed;
        private volatile bool isRunning;
    }
}