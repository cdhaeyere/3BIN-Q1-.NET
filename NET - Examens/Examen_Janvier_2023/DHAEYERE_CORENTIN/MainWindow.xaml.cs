using DHAEYERE_CORENTIN.ViewModels;
using System.Windows;

namespace DHAEYERE_CORENTIN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductsVM();
        }
    }
}