using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.Data;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel :ViewModelBase
    {
        private IWeatherRepository _weather;

        public WeatherLatestViewModel()
            :this(new WeatherSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather) 
        {
            _weather = weather;
        }

        private string _areaIdText = String.Empty;
        public string AreaIdText {
            get { return _areaIdText; }
            set 
            {
                //SetPropertyより不要
                ////if (_areaIdText == value) 
                ////{
                ////    return;
                ////}

                ////_areaIdText = value;
                //ViewModelBaseクラスにより不要
                //OnPropertyChanged(nameof(AreaIdText));
                SetProperty(ref _areaIdText, value);
            }
        }

        private string _dataDateText = String.Empty;
        public string DataDateText
        {
            get { return _dataDateText; }
            set
            {
                //if (_dataDateText == value)
                //{
                //    return;
                //}

                //_dataDateText = value;
                //OnPropertyChanged(nameof(DataDateText));
                SetProperty(ref _dataDateText, value);
            }
        }

        private string _conditionText = String.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                //if (_conditionText == value)
                //{
                //    return;
                //}

                //_conditionText = value;
                //OnPropertyChanged(nameof(ConditionText));
                SetProperty(ref _conditionText, value);
            }
        }

        private string _temperatureText = String.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                //if (_temperatureText == value)
                //{
                //    return;
                //}

                //_temperatureText = value;
                //OnPropertyChanged(nameof(TemperatureText));
                SetProperty(ref _temperatureText, value);
            }
        }
        //public string DataDateText { get; set; } = string.Empty;
        //public string ConditionText { get; set; } = string.Empty;
        //public string TemperatureText { get; set; } = string.Empty;

        //ViewModelBaseクラスにより不要
        //public event PropertyChangedEventHandler PropertyChanged;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                //TemperatureText =
                //    Common.CommonFunc.RoundString(entity.Temperature,
                //    Temperature.DECIMAL_POINT) + " " +
                //    Temperature.UNIT_NAME;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }
            ////ViewModelBaseクラスにより不要
            //OnPropertyChanged("");
        }

        ////ViewModelBaseクラスにより不要
        //public void OnPropertyChanged(string propertyName) 
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
