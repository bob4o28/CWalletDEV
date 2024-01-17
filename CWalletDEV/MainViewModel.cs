using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWalletDEV
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ChartValues<double> _areaChartValues;
        public ChartValues<double> AreaChartValues
        {
            get { return _areaChartValues; }
            set
            {
                _areaChartValues = value;
                OnPropertyChanged("AreaChartValues");
            }
        }

        private string[] _daysOfWeel;
        public string[] DaysOfWeel
        {
            get { return _daysOfWeel; }
            set
            {
                _daysOfWeel = value;
                OnPropertyChanged("DaysOfWeel");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
