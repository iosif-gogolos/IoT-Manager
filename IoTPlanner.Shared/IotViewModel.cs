using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IoTPlanner.Shared;

public class IotViewModel : INotifyPropertyChanged
{
    private string _title = "IoT Planner";
    private string _status = "Ready";

    public string Title
    {
        get => _title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}