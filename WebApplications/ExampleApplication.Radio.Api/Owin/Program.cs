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
        /// The main method to start OWiN.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting {0}", IoCProvider.Resolve<ITitleProvider>().Title);

            const string BaseAddress = "http://localhost:9000/";

            // Start OWIN host
            using (WebApp.Start<Startup>(url: BaseAddress))
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