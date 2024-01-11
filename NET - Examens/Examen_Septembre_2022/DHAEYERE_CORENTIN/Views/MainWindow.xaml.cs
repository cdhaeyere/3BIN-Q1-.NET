using System.Windows;
using ExamenSep2022.ViewModels;

namespace ExamenSep2022
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductsVM();
        }
    }
}