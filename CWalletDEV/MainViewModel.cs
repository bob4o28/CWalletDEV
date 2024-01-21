using LiveCharts;
using System;
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


    //Pie chart DataBinding Values identify
    private LiveCharts.ChartValues<double> _pieValuesCash;
    public LiveCharts.ChartValues<double> PieValuesCash
    {
        get { return _pieValuesCash; }
        set
        {
            _pieValuesCash = value;
            OnPropertyChanged("PieValuesCash");
        }
    }


    public MainViewModel()
    {
        ChartValues = new ChartValues<double> { 5.0, 3.0, 2.0, 7.0, 4.0, 78.0, 4.0 };
        Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" , "Saturday", "Sunday"};
        PieValuesCash = new ChartValues<double> { 100.0 };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
