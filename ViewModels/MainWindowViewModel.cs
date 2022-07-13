using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using WpfMvvmDiEfSample.Services;

namespace WpfMvvmDiEfSample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRandomStringService _randStringService;

        public MainWindowViewModel(IRandomStringService randStringService)
        {
            _randStringService = randStringService;
            UpdateTextCommand = new Command(OnUpdateTextCommandExecute);
        }

        private string _mainText = "Press button for generate new text";
        public string MainText
        {
            get => _mainText;
            set => SetProperty(ref _mainText, value);
        }



        public Command UpdateTextCommand { get; }
        private void OnUpdateTextCommandExecute(object obj)
        {
            MainText = _randStringService.GetRandomString();
        }


    }
}
