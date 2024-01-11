using ExamenSep2022.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenSep2022.ViewModels
{
    internal class ProductModel : INotifyPropertyChanged
    {
        private readonly Product _product;
        private decimal _totalSales;

        public ProductModel(Product product)
        {
            _product = product;
        }

        public ProductModel(Product product, decimal totalSales)
        {
            _product = product;
            _totalSales = totalSales;
        }

        public int ProductId
        {
            get { return _product.ProductId; }
            set { _product.ProductId = value; }
        }

        public string ProductName
        {
            get { return _product.ProductName; }
            set { _product.ProductName = value; }
        }

        public string SupplierName
        {
            get { return _product.Supplier.ContactName; }
        }

        public string QuantityPerUnit { get { return _product.QuantityPerUnit; } set { _product.QuantityPerUnit = value; } }

        public decimal TotalSales
        {
            get { return _totalSales; }
            set
            {
                if (_totalSales != value)
                {
                    _totalSales = value;
                    OnPropertyChanged(nameof(TotalSales));
                }
            }
        }

        public ICollection<OrderDetail> OrderDetails
        {
            get { return _product.OrderDetails; }
        }

        public Product Product => _product;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
