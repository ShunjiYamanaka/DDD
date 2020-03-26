using System;
using System.Data;
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

            //Objectの中にwatherMocのインスタンスがある
            var viewModel = new WeatherLatestViewModel(watherMoc.Object);
            //var viewModel = new WeatherLatestViewModel(new WeatherMock());
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.Search();

            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 12:34:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

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
