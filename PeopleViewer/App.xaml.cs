﻿using PeopleViewer.Presentation;
using PersonDataReader.SQL;
using System.Windows;

namespace PeopleViewer;
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ComposeObjects();
        Current.MainWindow.Title = "With Dependeny Injection";
        Current.MainWindow.Show();
    }

    private static void ComposeObjects()
    {
        var reader = new SQLReader();
        var viewModel = new PeopleViewModel(reader);
        Current.MainWindow = new PeopleViewerWindow(viewModel);
    }
}