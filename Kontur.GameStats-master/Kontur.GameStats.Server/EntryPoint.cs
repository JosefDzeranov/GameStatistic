using System;
using Fclp;
using Kontur.GameStats.Server.Models;

namespace Kontur.GameStats.Server
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var commandLineParser = new FluentCommandLineParser<Options>();

            commandLineParser
                .Setup(options => options.Prefix)
                .As("prefix")
                .SetDefault("http://localhost:8080/")
                .WithDescription("HTTP prefix to listen on");

            commandLineParser
                .SetupHelp("h", "help")
                .WithHeader($"{AppDomain.CurrentDomain.FriendlyName} [--prefix <prefix>]")
                .Callback(text => Console.WriteLine(text));

            if (commandLineParser.Parse(args).HelpCalled)
                return;

            RunServer(commandLineParser.Object);
        }

        private static void RunServer(Options options)
        {
            using (var server = new StatServer(new RequestParser()))
            {
                server.Start(options.Prefix);

                Console.ReadKey(true);
            }
        }

        private class Options
        {
            public string Prefix { get; set; }
        }
    }
}
