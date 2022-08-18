namespace WpfMvvmDiEfSample.Models
{
    public class Band : ObservableObject
    {
        public int Id { get; set; }

        private string _name = "Unknown";
        public string Name 
        { 
            get => _name;
            set => SetProperty(ref _name, value); 
        }

        private string _genre = "Unknown";
        public string Genre 
        { 
            get => _genre;
            set => SetProperty(ref _genre, value); 
        } 


    }
}
