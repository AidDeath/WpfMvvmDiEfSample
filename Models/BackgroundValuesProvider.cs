namespace WpfMvvmDiEfSample.Models
{
    /// <summary>
    /// Class for value providing from background services to ViewModels or other
    /// </summary>
    public class BackgroundValuesProvider : ObservableObject
    {
        private string _stringValue = "Value hasn't changed yet";

        public string StringValue
        {
            get => _stringValue;
            set => SetProperty(ref _stringValue, value);
        }
    }
}
