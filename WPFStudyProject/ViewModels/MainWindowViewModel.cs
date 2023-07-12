using WPFStudyProject.ViewModels.Base;

namespace WPFStudyProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region
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

        #region
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

    }
}
