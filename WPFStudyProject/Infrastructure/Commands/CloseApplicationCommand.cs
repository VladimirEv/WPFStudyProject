using System.Windows;
using WPFStudyProject.Infrastructure.Commands.Base;

namespace WPFStudyProject.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
