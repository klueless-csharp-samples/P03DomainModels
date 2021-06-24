# Using IStartup

What is the difference between ConfigureHostConfiguration() and ConfigureAppConfiguration()?

Host Configuration refers to any configuration needed when building the host itself such as current environment, environment variables, kestrel, content root. Everything else falls under App Configuration refers to any configuration the App needs (after the host is built) during its building process and while it is running. I've included both for example's sake, although if you only want to load appsettings.json, use one or the other.

#### ConfigureAppConfiguration

You can configure some configuration of the application, such as environment variables, etc

#### ConfigureServices

#### ConfigureContainer()
How to use ConfigureContainer() and UseServiceProviderFactory()

These helpers can be used to replace the default dependency injection, such as Autofac


### The IHost interface offers a number of benefits and features:

- Graceful shut down
- Dependency Injection
- Logging
- Configuration

These features are particularly important when developing complex data processing tasks in Docker containers. Especially graceful shutdown, as it helps to keep application state consistent.

The HostingHostBuilder provides extension methods to configure host services. The following extension available:

- ConfigureAppConfiguration – Application Configuration
- ConfigureContainer – Configure the instantiated dependency injection container
- ConfigureLogging – Configure Logging
- ConfigureServices – Adds services to the Dependency Injection container
- RunConsoleAsync – Enables console support
- UseConsoleLifetime – Listens for shutdown signals
- UseContentRoot – Specify the content root directory
- UseEnvironment – Specify the environment