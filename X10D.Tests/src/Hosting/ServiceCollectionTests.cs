using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using X10D.Hosting.DependencyInjection;

namespace X10D.Tests.Hosting;

[TestFixture]
internal class ServiceCollectionTests
{
    [Test]
    public void AddHostedSingleton_ShouldRegisterServiceAsSingletonAndAsHostedService()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton<TestService>();

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<TestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.Multiple(() =>
        {
            Assert.That(service, Is.Not.Null);
            Assert.That(hostedService, Is.Not.Null);
            Assert.IsAssignableFrom<TestService>(service);
            Assert.IsAssignableFrom<TestService>(hostedService);
            Assert.That(hostedService, Is.SameAs(service));
        });
    }

    [Test]
    public void AddHostedSingleton_ShouldRegisterServiceAsSingletonAndAsHostedService_GivenServiceAndImplTypes()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton<ITestService, TestService>();

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<ITestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.Multiple(() =>
        {
            Assert.That(service, Is.Not.Null);
            Assert.That(hostedService, Is.Not.Null);
            Assert.IsAssignableFrom<TestService>(service);
            Assert.IsAssignableFrom<TestService>(hostedService);
            Assert.That(hostedService, Is.SameAs(service));
        });
    }

    [Test]
    public void AddHostedSingleton_ShouldRegisterServiceTypeAsSingletonAndAsHostedService()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton(typeof(TestService));

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<TestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.Multiple(() =>
        {
            Assert.That(service, Is.Not.Null);
            Assert.That(hostedService, Is.Not.Null);
            Assert.IsAssignableFrom<TestService>(service);
            Assert.IsAssignableFrom<TestService>(hostedService);
            Assert.That(hostedService, Is.SameAs(service));
        });
    }

    [Test]
    public void AddHostedSingleton_ShouldRegisterServiceTypeAsSingletonAndAsHostedService_GivenServiceAndImplTypes()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton(typeof(ITestService), typeof(TestService));

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<ITestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.Multiple(() =>
        {
            Assert.That(service, Is.Not.Null);
            Assert.That(hostedService, Is.Not.Null);
            Assert.IsAssignableFrom<TestService>(service);
            Assert.IsAssignableFrom<TestService>(hostedService);
            Assert.That(hostedService, Is.SameAs(service));
        });
    }

    private interface ITestService
    {
        void Foo();
    }

    private sealed class TestService : ITestService, IHostedService
    {
        public void Foo()
        {
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
