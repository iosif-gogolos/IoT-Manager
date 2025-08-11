using Avalonia.Controls;
using Avalonia.Interactivity;
using IoTPlanner.Shared;
using System;
using System.Threading.Tasks;

namespace IoTPlanner.Avalonia;

public partial class MainWindow : Window
{
    public IotViewModel ViewModel { get; }
    
    public MainWindow(IotViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = ViewModel;
        
        // Auto-connect on window load
        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object? sender, RoutedEventArgs e)
    {
        // Set the broker details and connect
        ViewModel.Host = "mqtt.myserver.com";
        ViewModel.Port = 1883;
        
        await ViewModel.ConnectAsync();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        // Ensure proper cleanup when window is closing
        _ = Task.Run(async () => await ViewModel.DisconnectAsync());
        base.OnClosing(e);
    }
}