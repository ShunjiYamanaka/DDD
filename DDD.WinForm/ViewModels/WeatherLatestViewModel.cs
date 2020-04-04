using DDD.Domain;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.Data;
using DDD.Infrastructure.SQLite;
using System;
using System.ComponentModel;

namespace DDD.WinForm.ViewModels
{
    public class WeatherLatestViewModel :ViewModelBase
    {
        private IWeatherRepository _weather;
        IAreasRepository _areas;

        public WeatherLatestViewModel()
            :this(new WeatherSQLite(), new AreasSQLite())
        {
        }

        public WeatherLatestViewModel(IWeatherRepository weather,
            IAreasRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in _areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        private object _selectedAreaId;
        public Object SelectedAreaId {
            get { return _selectedAreaId; }
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
                SetProperty(ref _selectedAreaId, value);
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

        //同期をとるためBidingList
        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        //public string DataDateText { get; set; } = string.Empty;
        //public string ConditionText { get; set; } = string.Empty;
        //public string TemperatureText { get; set; } = string.Empty;

        //ViewModelBaseクラスにより不要
        //public event PropertyChangedEventHandler PropertyChanged;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));
            if (entity == null) 
            {
                DataDateText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            }
            else
            {
                DataDateText = entity.DataDate.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
                //TemperatureText =
                //    Common.CommonFunc.RoundString(entity.Temperature,
                //    Temperature.DECIMAL_POINT) + " " +
                //    Temperature.UNIT_NAME;
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
