using DDD.WinForm.ViewModels;
using System;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherLatestView : Form
    {
        private WeatherLatestViewModel _viewModel
            = new WeatherLatestViewModel();

        public WeatherLatestView()
        {
            InitializeComponent();
            //ﾃﾞｰﾀﾊﾞｲﾝﾄﾞ
            //ﾃﾞｰﾀﾊﾞｲﾝﾄﾞすることでSearchしたら_viewModelのテキストエリアが変わるので
            //勝手に値が反映される
            this.AreaIdTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.AreaIdText)); //viewmodelのAreaIdTextを紐づけ

            this.DataDateLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.DataDateText));
            this.ConditionLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.ConditionText));
            this.TemperatureLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));


        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _viewModel.Search();
        }

        
    }
}
