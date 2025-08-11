using Avalonia.Controls;
using IoTPlanner.Shared;

namespace IoTPlanner.Avalonia;

public partial class MainWindow : Window
{
    public IotViewModel ViewModel { get; }
    
    public MainWindow(IotViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = ViewModel;
    }
}