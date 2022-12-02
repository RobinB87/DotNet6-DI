using Autofac;
using Autofac.Features.ResolveAnything;
using PeopleViewer.Common;
using PeopleViewer.Presentation;
using PersonDataReader.CSV;
using PersonDataReader.Decorators;
using PersonDataReader.Service;
using PersonDataReader.SQL;
using System.Windows;

namespace PeopleViewer.Autofac;

public partial class App : Application
{
    IContainer Container;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ConfigureContainer();
        ComposeObjects();
        Current.MainWindow.Title = "With Dependency Injection - Autofac";
        Current.MainWindow.Show();
    }

    private void ConfigureContainer()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ServiceReader>()
            .As<IPersonReader>()
            .SingleInstance();

        builder.RegisterType<PeopleViewerWindow>()
            .InstancePerDependency(); // same as transient in ninject (instance per request)

        builder.RegisterType<PeopleViewModel>()
            .InstancePerDependency();

        Container = builder.Build();
    }

    private void ComposeObjects()
    {
        Current.MainWindow = 
            Container.Resolve<PeopleViewerWindow>();
    }
}
