using DHAEYERE_CORENTIN.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using WpfApplication1.ViewModels;

namespace DHAEYERE_CORENTIN.ViewModels
{
    public class ProductsVM : INotifyPropertyChanged
    {
        private NorthwindContext db = new NorthwindContext();

        private ObservableCollection<ProductModel> _products;
        private ObservableCollection<ProductModel> _dataList;
        private ProductModel _selectedProduct;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                }
            }
        }

        public ObservableCollection<ProductModel> Products
        {
            get
            {
                if (_products == null)
                {
                    _products = loadProducts();
                }

                return _products;
            }
        }

        private ObservableCollection<ProductModel> loadProducts()
        {
            ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();
            foreach (Product product in db.Products.Where((p) => p.Discontinued == false))
            {
                products.Add(new ProductModel(product));
            }

            return products;
        }

        private DelegateCommand _abandonCommand;

        public DelegateCommand AbandonCommand
        {
            get
            {
                return _abandonCommand = _abandonCommand ?? new DelegateCommand(AbandonProduct);
            }
        }

        private void AbandonProduct()
        {
            if (SelectedProduct == null)
            {
                return;
            }
            Product product = db.Products.Where((p) => p.ProductId == SelectedProduct.ProductId).FirstOrDefault();

            if (product != null)
            {
                if (product.Discontinued == true)
                {
                    MessageBox.Show("Product already discontinued");
                    return;
                }
                product.Discontinued = true;
                Products.Remove(SelectedProduct);
                OnPropertyChanged("Products");
            }

            db.SaveChanges();
            MessageBox.Show("Product discontinued");
        }

        public ObservableCollection<ProductModel> DataList
        {
            get
            {
                return _dataList ?? loadDataList();
            }
        }

        private ObservableCollection<ProductModel> loadDataList()
        {
            ObservableCollection<ProductModel> result = new ObservableCollection<ProductModel>();

            var countriesWithSales = db.OrderDetails.Select(od => od.Product.Supplier.Country).Distinct().ToList();
            foreach (var country in countriesWithSales)
            {
                var productCount = db.OrderDetails.Where(od => od.Product.Supplier.Country == country)
                    .Select(od => od.ProductId).Distinct().Count();
                result.Add(new ProductModel(productCount, country));
            }

            return new ObservableCollection<ProductModel>(result.OrderByDescending(x => x.Count));
        }
    }
}