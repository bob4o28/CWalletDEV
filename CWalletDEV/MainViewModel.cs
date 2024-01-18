using LiveCharts;
using System.ComponentModel;

public class MainViewModel : INotifyPropertyChanged
{
    private ChartValues<double> _chartValues;
    public ChartValues<double> ChartValues
    {
        get { return _chartValues; }
        set
        {
            _chartValues = value;
            OnPropertyChanged("ChartValues");
        }
    }

    private string[] _labels;
    public string[] Labels
    {
        get { return _labels; }
        set
        {
            _labels = value;
            OnPropertyChanged("Labels");
        }
    }

    public MainViewModel()
    {
        ChartValues = new ChartValues<double> { 5, 3, 2, 7, 4, 78, 4 };
        Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" , "Saturday", "Sunday"};
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
