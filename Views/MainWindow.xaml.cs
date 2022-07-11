using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using WpfMvvmDiEfSample.Services;

namespace WpfMvvmDiEfSample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IRandomStringService? randomStringService = App.Current.Services.GetService<IRandomStringService>();
            TextBlock.Text = randomStringService?.GetRandomString();
        }
    }
}
