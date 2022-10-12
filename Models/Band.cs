using System.ComponentModel.DataAnnotations;

namespace WpfMvvmDiEfSample.Models
{
    public class Band : ValidatingObservableObject//ObservableObject
    {
        public int Id { get; set; }

        private string _name = "Unknown";
        [Required(ErrorMessage = "REQUIRED!!")]
        [MaxLength(3, ErrorMessage ="TOO LONG!!")]
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
