using System;
using System.Collections.Generic;
using System.Data;
using DDD.Domain;
using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DDDTest.Tesrs
{
    [TestClass]
    public class WeatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var watherMoc = new Mock<IWeatherRepository>();

            watherMoc.Setup(x => x.GetLatest(1))
                .Returns(new WeatherEntity(
                    1,
                    Convert.ToDateTime("2018/01/01 12:34:56"),
                    2,
                    12.3f));

            //watherMoc.Setup(x => x.GetLatest(2))
            //    .Returns(new WeatherEntity(
            //        2,
            //        Convert.ToDateTime("2019/05/01 0:00:00"),
            //        1,
            //        24.23f));

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            //areas.Add(new AreaEntity(2, "神戸"));
            areas.Add(new AreaEntity(3, "沖縄"));

            var areasMock = new Mock<IAreasRepository>();
            areasMock.Setup(x => x.GetData()).Returns(areas);

            //Objectの中にwatherMocのインスタンスがある
            var viewModel = new WeatherLatestViewModel(
                watherMoc.Object,
                areasMock.Object
                );
            //var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.IsNull(viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            //Assert.AreEqual(2, viewModel.Areas.Count);
            Assert.AreEqual(1, viewModel.Areas[0].AreaId);
            Assert.AreEqual("東京", viewModel.Areas[0].AreaName);

            viewModel.SelectedAreaId = 1;
            viewModel.Search();

            Assert.AreEqual(1, viewModel.SelectedAreaId);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.SelectedAreaId = 3;
            viewModel.Search();

            Assert.AreEqual(3, viewModel.SelectedAreaId);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

        }
    }

    //internal class WeatherMock : IWeatherRepository 
    //{
    //    public WeatherEntity GetLatest(int areaId) 
    //    {
    //        var entity = new WeatherEntity(1, 
    //            Convert.ToDateTime("2018/01/01 12:34:56"),
    //            2,
    //            12.3f);

    //        return entity;
    //    }
    //}
}
