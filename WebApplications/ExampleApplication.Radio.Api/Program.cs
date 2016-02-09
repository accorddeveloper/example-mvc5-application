namespace ExampleApplication.Radio.Api
{
    using System;

    using ExampleApplication.Radio.Api.Owin;
    using ExampleApplication.Radio.Api.Providers;
    using ExampleApplication.Utilities;

    using Microsoft.Owin.Hosting;

    /// <summary>
    /// The Radio API application.
    /// </summary>
    public class Program
    {
        private static ISettingsProvider Settings => IoCProvider.Resolve<ISettingsProvider>();

        /// <summary>
        /// The main method to start the API.
        /// </summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting {0} at {1}", Settings.Title, Settings.Address);

            using (WebApp.Start<Startup>(url: Settings.Address))
            {
                PauseToProcessRequests();
            }
        }

        /// <summary>
        /// Pauses the application to wait for incoming requests.
        /// </summary>
        private static void PauseToProcessRequests()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}