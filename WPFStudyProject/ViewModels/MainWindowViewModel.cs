using OxyPlot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;
using System.Xaml.Schema;
using WPFStudyProject.Infrastructure.Commands;
using WPFStudyProject.Models;
using WPFStudyProject.ViewModels.Base;


namespace WPFStudyProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region TestDataPoints : IEnumerable<Test> - DESCRIPTION

        private IEnumerable<Models.DataPoint> _testDataPoints;

        public IEnumerable<Models.DataPoint> TestDataPoints { get => _testDataPoints; set => Set(ref _testDataPoints, value); }

        #endregion

        #region Заголовок окна
        private string _title = "Statistics analysis";

        public string Title
        {
            get => _title;
            // set
            // {
            //if(Equals(_title, value))return;
            // _title = value;
            // OnPropertyChanged();

            // Set(ref _title, value);
            // }
            set=>Set(ref _title, value);
        }
        #endregion

        #region Status : string - статус программы
        private string _status = "Ready !";

        public string Status
        {
            get => _status;
            // set
            // {
            //if(Equals(_status, value))return;
            // _status = value;
            // OnPropertyChanged();

            // Set(ref _status, value);
            // }
            set => Set(ref _status, value);
        }
        #endregion


        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object? parameter) => true;

        private void OnCloseApplicationCommandExecute(object parameter)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commads
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecute, CanCloseApplicationCommandExecute);
            #endregion

            var data_points = new List<Models.DataPoint>((int)(360/0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new Models.DataPoint { XValue = x, YValue = y});
            }

            TestDataPoints = data_points;
        }


    }
}
