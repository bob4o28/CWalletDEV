using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;

public class MainViewModel : INotifyPropertyChanged
{
    private ChartValues<double> _chartValues { get; set; }
    public ChartValues<double> ChartValues
    {
        get { return _chartValues; }
        set
        {
            _chartValues = value;
            OnPropertyChanged("ChartValues");
        }
    }
    private List<string> _labels;
    public List<string> Labels
    {
        get { return _labels; }
        set
        {
            _labels = value;
            OnPropertyChanged("Labels");
        }
    }


 

   //Pie chart DataBinding Values identify
    private ChartValues<double> _pieValuesCash;
    private ChartValues<double> _pieValuesBank;
    private ChartValues<double> _pieValuesDebit;
    private ChartValues<double> _pieValuesCredit;
    private ChartValues<double> _pieValuesSavings;
    private ChartValues<double> _pieValuesCrypto;

    public ChartValues<double> PieValuesCash
    {
        get { return _pieValuesCash; }
        set
        {
            _pieValuesCash = value;
            OnPropertyChanged("PieValuesCash");
        }
    }

    public ChartValues<double> PieValuesBank
    {
        get { return _pieValuesBank; }
        set
        {
            _pieValuesBank = value;
            OnPropertyChanged("PieValuesBank");
        }
    }

    public ChartValues<double> PieValuesDebit
    {
        get { return _pieValuesDebit; }
        set
        {
            _pieValuesDebit = value;
            OnPropertyChanged("PieValuesDebit");
        }
    }

    public ChartValues<double> PieValuesCredit
    {
        get { return _pieValuesCredit; }
        set
        {
            _pieValuesCredit = value;
            OnPropertyChanged("PieValuesCredit");
        }
    }

    public ChartValues<double> PieValuesSavings
    {
        get { return _pieValuesSavings; }
        set
        {
            _pieValuesSavings = value;
            OnPropertyChanged("PieValuesSavings");
        }
    }

    public ChartValues<double> PieValuesCrypto
    {
        get { return _pieValuesCrypto; }
        set
        {
            _pieValuesCrypto = value;
            OnPropertyChanged("PieValuesCrypto");
        }
    }


    public MainViewModel()
    {
        //ChartValues = new ChartValues<double> { 5.0, 3.0, 2.0, 7.0, 4.0, 78.0, 4.0 };
        //Labels = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" , "Saturday", "Sunday"};
        //PieValuesCash = new ChartValues<double> { 100.0 };
    }



    //Cash win DataBinding
    private ChartValues<double> _areaChartCash;

    public ChartValues<double> AreaChartCash
    {
        get { return _areaChartCash; }
        set
        {
            _areaChartCash = value;
            OnPropertyChanged("AreaChartCash");
        }
    }
    private List<string> _labelsCash;
    public List<string> LabelsCash
    {
        get { return _labelsCash; }
        set
        {
            _labelsCash = value;
            OnPropertyChanged("Labels");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
