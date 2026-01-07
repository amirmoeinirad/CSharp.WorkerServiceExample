using Microsoft.Extensions.Hosting.WindowsServices;


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
                                  
            
            // Only enable Windows Service integration on Windows
            if (OperatingSystem.IsWindows())
            {
                // 'AddSingleton<>()': Registers a service as a singleton in the dependency injection container.
                // 'IHostLifetime': Defines the contract for managing the lifetime of a host.
                // 'WindowsServiceLifetime': An implementation of IHostLifetime that allows the host to run as a Windows Service.
                // When this is added, .NET will manage the application lifecycle according to Windows Service rules (start, stop, pause, etc.),
                // ensuring it runs properly as a service.
                builder.Services.AddSingleton<IHostLifetime, WindowsServiceLifetime>();
            }


            // Building the host.
            // The 'Build' method compiles the configured host into an IHost instance.
            // 'IHost': representing a running host.
            // 'Host': Static helper/factory class. Used to create and configure an IHost. Host builds an IHost; it is not an IHost.
            var app = builder.Build();


            // Running the host.
            app.Run();
        }
    }
}

// Amir Moeini Rad
// Date: January 7, 2026