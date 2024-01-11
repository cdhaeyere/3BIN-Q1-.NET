using DHAEYERE_CORENTIN.Models;

namespace DHAEYERE_CORENTIN.ViewModels
{
    public class ProductModel
    {
        private readonly Product _product;
        private int? _count;
        private string? _country;

        public ProductModel(int count, string country)
        {
            this._count = count;
            this._country = country;
        }

        public Product MyProduct
        {
            get { return _product; }
        }

        public ProductModel(Product product)
        {
            this._product = product;
        }

        public int ProductId
        {
            get { return _product.ProductId; }
            set
            {
                if (_product.ProductId != value)
                {
                    _product.ProductId = value;
                }
            }
        }

        public string ProductName
        {
            get { return _product.ProductName; }
            set
            {
                if (_product.ProductName != value)
                {
                    _product.ProductName = value;
                }
            }
        }

        public string Supplier
        {
            get { return _product.Supplier.ContactName; }
            set
            {
                if (_product.Supplier.ContactName != value)
                {
                    _product.Supplier.ContactName = value;
                }
            }
        }

        public string Category
        {
            get { return _product.Category.CategoryName; }
            set
            {
                if (_product.Category.CategoryName != value)
                {
                    _product.Category.CategoryName = value;
                }
            }
        }

        public int? Count { get => _count; set => _count = value; }

        public string? Country { get => _country; set => _country = value; }
    }
}
