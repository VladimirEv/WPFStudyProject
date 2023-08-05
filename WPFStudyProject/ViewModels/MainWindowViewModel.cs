using System.Windows;
using System.Windows.Input;
using WPFStudyProject.Infrastructure.Commands;
using WPFStudyProject.ViewModels.Base;


namespace WPFStudyProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
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
        }


    }
}
