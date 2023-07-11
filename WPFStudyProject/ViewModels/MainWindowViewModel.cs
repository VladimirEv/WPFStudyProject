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
    }
}
