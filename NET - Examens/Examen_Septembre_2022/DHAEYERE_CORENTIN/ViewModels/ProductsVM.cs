using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ExamenSep2022.Models;
using ExamenSep2022.ViewModels;

internal class ProductsVM : INotifyPropertyChanged
{
    private NorthwindContext context = new NorthwindContext();
    private ObservableCollection<ProductModel>? _productsList;
    private ProductModel? _selectedProduct;

    public ProductsVM()
    {
        
    }

    public ObservableCollection<ProductModel>? ProductsList
    {
        get => _productsList ??= LoadProducts();
        set
        {
            if (_productsList != value)
            {
                _productsList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
        }
    }

    private ObservableCollection<ProductModel> LoadProducts()
    {
        ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
        foreach (var item in context.Products.Where(p => !p.Discontinued))
            localCollection.Add(new ProductModel(item));
        return localCollection;
    }

    public ProductModel? SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                SalesTotals = LoadSalesTotals();
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
    }

    private DelegateCommand? _updateCommand;

    public DelegateCommand UpdateCommand
    {
        get { return _updateCommand ??= new DelegateCommand(UpdateProduct); }
    }

    private void UpdateProduct()
    {
        if (_selectedProduct != null)
        {
            var productToUpdate = _productsList?.FirstOrDefault(p => p.ProductId == _selectedProduct.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = _selectedProduct.ProductName;
                productToUpdate.QuantityPerUnit = _selectedProduct.QuantityPerUnit;
                ProductsList = new ObservableCollection<ProductModel>(_productsList);
                context.SaveChanges();
                SalesTotals = LoadSalesTotals();
            }
        }
    }

    private ObservableCollection<ProductModel>? _salesTotals;

    public ObservableCollection<ProductModel>? SalesTotals
    {
        get => _salesTotals;
        set
        {
            if (_salesTotals != value)
            {
                _salesTotals = value;
                OnPropertyChanged(nameof(SalesTotals));
            }
        }
    }

    private ObservableCollection<ProductModel> LoadSalesTotals()
    {
        if (_selectedProduct != null)
        {
            List<OrderDetail> ordersList = _selectedProduct.OrderDetails?.ToList() ?? new List<OrderDetail>();
            ObservableCollection<OrderDetail> orders = new ObservableCollection<OrderDetail>(ordersList);
            ObservableCollection<ProductModel> salesTotals = new ObservableCollection<ProductModel>();
            foreach (var orderDetail in orders)
            {
                decimal totalSales = orderDetail.Quantity * orderDetail.UnitPrice;
                salesTotals.Add(new ProductModel(_selectedProduct.Product, totalSales));
            }
            return salesTotals;
        }
        return new ObservableCollection<ProductModel>();
    }

    private decimal CalculateTotalSales(int productId)
    {
        return context.OrderDetails
            .Where(od => od.ProductId == productId)
            .Sum(od => od.Quantity * od.UnitPrice);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
