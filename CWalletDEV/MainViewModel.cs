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


    private ChartValues<double> _areaChartSavings;

    public ChartValues<double> AreaChartSavings
    {
        get { return _areaChartSavings; }
        set
        {
            _areaChartSavings = value;
            OnPropertyChanged("AreaChartSavings");
        }
    }
    private List<string> _labelsSavings;
    public List<string> LabelsSavings
    {
        get { return _labelsSavings; }
        set
        {
            _labelsSavings = value;
            OnPropertyChanged("LabelsSavings");
        }
    }


    private ChartValues<double> _areaChartBank;

    public ChartValues<double> AreaChartBank
    {
        get { return _areaChartBank; }
        set
        {
            _areaChartBank = value;
            OnPropertyChanged("AreaChartBank");
        }
    }
    private List<string> _labelsBank;
    public List<string> LabelsBank
    {
        get { return _labelsBank; }
        set
        {
            _labelsBank = value;
            OnPropertyChanged("LabelsBank");
        }
    }


    private ChartValues<double> _areaChartCredit;

    public ChartValues<double> AreaChartCredit
    {
        get { return _areaChartCredit; }
        set
        {
            _areaChartCredit = value;
            OnPropertyChanged("AreaChartCredit");
        }
    }
    private List<string> _labelsCredit;
    public List<string> LabelsCredit
    {
        get { return _labelsCredit; }
        set
        {
            _labelsCredit = value;
            OnPropertyChanged("LabelsCredit");
        }
    }


    private ChartValues<double> _areaChartCrypto;

    public ChartValues<double> AreaChartCrypto
    {
        get { return _areaChartCrypto; }
        set
        {
            _areaChartCrypto = value;
            OnPropertyChanged("AreaChartCredit");
        }
    }
    private List<string> _labelsCrypto;
    public List<string> LabelsCrypto
    {
        get { return _labelsCrypto; }
        set
        {
            _labelsCrypto = value;
            OnPropertyChanged("LabelsCrypto");
        }
    }



    private ChartValues<double> _areaChartDebit;

    public ChartValues<double> AreaChartDebit
    {
        get { return _areaChartDebit; }
        set
        {
            _areaChartDebit = value;
            OnPropertyChanged("AreaChartDebit");
        }
    }
    private List<string> _labelsDebit;
    public List<string> LabelsDebit
    {
        get { return _labelsDebit; }
        set
        {
            _labelsDebit = value;
            OnPropertyChanged("LabelsDebit");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


}
