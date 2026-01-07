namespace WorkerServiceExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Namespace: Microsoft.Extensions.Hosting
            // The 'Host' class provides methods for creating a host builder (an instance of IHostBuilder) with pre-configured defaults.
            // A Host is an object that encapsulates an app's resources, such as dependency injection, configuration, and logging.
            // 'IHostBuilder': for configuring and building a .NET Generic Host. (Classic/Older hosting style)
            // 'HostBuilder': concrete implementation of IHostBuilder.
            // 'IHostApplicationBuilder': for the modern, simplified hosting model. (Minimal hosting style)
            // 'HostApplicationBuilder': concrete implementation of IHostApplicationBuilder. Default builder for Worker Services and minimal apps
            var builder = Host.CreateApplicationBuilder(args);


            // Registering a hosted service (Worker custom class) with the dependency injection container.
            // The 'Services' property provides access to the IServiceCollection.
            // 'IServiceCollection': A collection of service descriptors for dependency injection.
            // 'AddHostedService<T>': Extension method to register a hosted service of type T. It is part of the Microsoft.Extensions.DependencyInjection namespace.
            // A hosted service means a service that is started when the host starts and stopped when the host stops.
            // 'IHostedService': Defines a contract for a service that is managed by the host.
            builder.Services.AddHostedService<Worker>();


            // Building the host.
            // The 'Build' method compiles the configured host into an IHost instance.
            // 'IHost': representing a running host.
            // 'Host': Static helper/factory class. Used to create and configure an IHost. Host builds an IHost; it is not an IHost.
            var host = builder.Build();


            // Running the host.
            host.Run();
        }
    }
}

// Amir Moeini Rad
// Date: January 2026