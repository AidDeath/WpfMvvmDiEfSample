using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMvvmDiEfSample.Helpers;
using WpfMvvmDiEfSample.Helpers.Commands;
using WpfMvvmDiEfSample.Models;
using WpfMvvmDiEfSample.Services;
using WpfMvvmDiEfSample.Views;

namespace WpfMvvmDiEfSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRandomStringService _randStringService;
        private readonly BandService _bandService;
        private BackgroundValuesProvider _valuesProvider;

        public MainViewModel(IRandomStringService randStringService, BandService bandService, BackgroundValuesProvider valuesProvider)
        {
            _randStringService = randStringService;
            _bandService = bandService;
            _valuesProvider = valuesProvider;

            //Bands = bandService.GetAllBands();

            UpdateTextCommand = new RelayCommand(OnUpdateTextCommandExecute);
            ShowAllBandsCommand = new AsyncRelayCommand(ShowAllBandsExecuted, CanShowAllBandsExecute);

            ShowBandDetailsCommand = new RelayCommand(OnShowBandDetailsCommandExecuted, CanShowBandDetailsCommandExecute);

            OpenDialogCommand = new RelayCommand(OnOpenDialog);
        }

        private string _mainText = "Press button for generate new text";
        public string MainText
        {
            get => _mainText;
            set => SetProperty(ref _mainText, value);
        }

        public BackgroundValuesProvider ValuesProvider
        {
            get => _valuesProvider;
            set => SetProperty(ref _valuesProvider, value);
        }
       

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands 
        { 
            get => _bands; 
            set => SetProperty(ref _bands, value); 
        }

        
        private Band _selectedBand;
        public Band SelectedBand
        {
            get => _selectedBand;
            set => SetProperty(ref _selectedBand, value); 
        }

        public IRaisedCommand UpdateTextCommand { get; }
        private void OnUpdateTextCommandExecute(object obj)
        {
            MainText = _randStringService.GetRandomString();
        }

        public IRaisedCommand ShowAllBandsCommand { get;}
        private async Task ShowAllBandsExecuted(object obj)
        {
            Bands = await _bandService.GetAllBandsAsync();
        }

        private bool CanShowAllBandsExecute(object obj)
        {
            return Bands is null;
        }

        public IRaisedCommand ShowBandDetailsCommand { get; }

        private void OnShowBandDetailsCommandExecuted(object obj)
        {
            var wnd = new BandDetailsWindow();

            var a = wnd.ShowDialog();
        }

        private bool CanShowBandDetailsCommandExecute(object obj)
        {
            return SelectedBand is not null;
        }


        private ICommand openDialogCommand;
        public ICommand OpenDialogCommand
        {
            get => openDialogCommand;
            set => openDialogCommand = value;
        }

        private void OnOpenDialog(object obj)
        {

        }

    }
}
