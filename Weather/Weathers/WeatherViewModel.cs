using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Service;

namespace Weather.Weathers
{
    public class WeatherViewModel: ViewModelBase
    {
        private readonly IOpenWeatherMapHelper _openWeatherMapHelper;

        public RelayCommand SearchCommand { get; }
        public RelayCommand ClearCommand { get; }

        public WeatherViewModel()
        {
            SearchCommand = new RelayCommand(OnSearch);
            ClearCommand = new RelayCommand(OnClear);
            _openWeatherMapHelper = new OpenWeatherMapHelper();
        }

        private void OnClear()
        {
            Keyword = string.Empty;
        }

        private void OnSearch()
        {
            var result = _openWeatherMapHelper.GetResult(Keyword);

            Name = result.Name;
            Humidity = result.Main.Humidity;
            Desc = result.Weather[0].Description;
            Temperature = result.Main.Temp;
        }

        public void Load()
        {
            Keyword = "11776";
            OnSearch();
            OnClear();
        }

        private string _keyword;

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                SetProperty(ref _keyword, value);
            }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set
            {
                SetProperty(ref _result, value);
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private float _temperature;

        public float Temperature
        {
            get { return _temperature; }
            set
            {
                SetProperty(ref _temperature, value);
            }
        }

        private int _humidity;

        public int Humidity
        {
            get { return _humidity; }
            set
            {
                SetProperty(ref _humidity , value);
            }
        }

        private string _desc;

        public string Desc
        {
            get { return _desc; }
            set
            {
                SetProperty(ref _desc, value);
            }
        }
    }
}
