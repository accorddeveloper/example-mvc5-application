namespace ExampleApplication.Radio.Api.Owin
{
    using ExampleApplication.Radio.Api.Providers;
    using ExampleApplication.Utilities;
    using Microsoft.Owin.Hosting;
    using System;
    using System.Diagnostics;

    /// <summary>
    /// The Radio API application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method to start OWIN.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            var baseAddress = AppSettings.ProvideValue<string>("Address");

            Console.WriteLine("Starting {0} at {1}", IoCProvider.Resolve<ITitleProvider>().Title, baseAddress);

            // Start OWIN host
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                PauseOnDebug();
            }
        }

        /// <summary>
        /// Stops the console when the app is running in DEBUG inside Visual Studio
        /// </summary>
        [Conditional("DEBUG")]
        private static void PauseOnDebug()
        {
            Console.ReadKey();
        }
    }
}