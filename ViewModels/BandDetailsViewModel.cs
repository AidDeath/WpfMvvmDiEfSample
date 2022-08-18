using System.Windows;
using WpfMvvmDiEfSample.Helpers.Commands;
using WpfMvvmDiEfSample.Models;

namespace WpfMvvmDiEfSample.ViewModels
{
    internal class BandDetailsViewModel : BaseViewModel
    {
        public BandDetailsViewModel()
        {
            SubmitChangesCommand = new RelayCommand(OnSubmitChangesCommandExecuted, CanSubmitChangesCommandExecute);
        }
        private Band _band;
        public Band Band
        {
            get => _band;
            set => SetProperty(ref _band, value);
        }

        public IRaisedCommand SubmitChangesCommand { get; }

        private void OnSubmitChangesCommandExecuted(object obj)
        {
            MessageBox.Show("Okay! =)");
        }

        private bool CanSubmitChangesCommandExecute(object obj)
        {
            return true;
        }
    }
}
