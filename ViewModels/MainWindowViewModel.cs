using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfMvvmDiEfSample.Models;
using WpfMvvmDiEfSample.Services;

namespace WpfMvvmDiEfSample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRandomStringService _randStringService;
        private readonly BandService _bandService;

        public MainWindowViewModel(IRandomStringService randStringService, BandService bandService)
        {
            _randStringService = randStringService;
            _bandService = bandService;

            //Bands = bandService.GetAllBands();

            UpdateTextCommand = new Command(OnUpdateTextCommandExecute);
            ShowAllBandsCommand = new AsyncCommand(ShowAllBandsExecute);
        }

        private string _mainText = "Press button for generate new text";
        public string MainText
        {
            get => _mainText;
            set => SetProperty(ref _mainText, value);
        }

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands { get => _bands; set => SetProperty(ref _bands, value); }


        public Command UpdateTextCommand { get; }
        private void OnUpdateTextCommandExecute(object obj)
        {
            MainText = _randStringService.GetRandomString();
        }

        public AsyncCommand ShowAllBandsCommand { get;}
        private async Task ShowAllBandsExecute()
        {
            Bands = await _bandService.GetAllBandsAsync();
        }




    }
}
