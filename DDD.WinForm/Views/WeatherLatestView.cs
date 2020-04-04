using DDD.Domain;
using DDD.WinForm.ViewModels;
using DDD.WinForm.Views;
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

            this.AreasComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreasComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId)); //viewmodelのAreaIdTextを紐づけ

            this.AreasComboBox.DataBindings.Add(
               "DataSource", _viewModel, nameof(_viewModel.Areas));

            //内部の値
            this.AreasComboBox.ValueMember = nameof(AreaEntity.AreaId);
            //表示上の値
            this.AreasComboBox.DisplayMember = nameof(AreaEntity.AreaName);


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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherListView()) 
            {
                f.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var f = new WeatherSavaView())
            {
                f.ShowDialog();
            }
        }
    }
}
