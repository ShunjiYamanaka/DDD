using DDD.Domain;
using DDD.Domain.ValueObjects;
using DDD.WinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WinForm
{
    public partial class WeatherSavaView : Form
    {
        private WeatherSaveViewModel _viewModel
            = new WeatherSaveViewModel();
        public WeatherSavaView()
        {
            InitializeComponent();

            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId)); //viewmodelのAreaIdTextを紐づけ

            this.AreaIdComboBox.DataBindings.Add(
               "DataSource", _viewModel, nameof(_viewModel.Areas));

            //内部の値
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            //表示上の値
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTimeTextBox.DataBindings.Add(
                "Value", _viewModel,nameof(_viewModel.DataDateValue));

            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add(
                "SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition)); 
            this.ConditionComboBox.DataBindings.Add(
               "DataSource", _viewModel, nameof(_viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);

            TemperatureTextBox.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureText));

            UnitLabel.DataBindings.Add(
                "Text", _viewModel, nameof(_viewModel.TemperatureUnitName));

            SaveButton.Click += (_, __) =>
            {
                try
                {
                    _viewModel.Save();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            };

        }
    }
}
