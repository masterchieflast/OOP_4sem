using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04_05
{
    internal class Product
    {
        private string _name;
        private ProductType _productType;
        private string _productDescription;
        private string _photoUrl;
        private string _description;
        private int _cost;
        private Guid _id;


        public Product(string name, ProductType ProductType, string photoUrl, string description, int cost)
        {
            Name = name;
            _productType = ProductType;

            ProductTypeString = _productType switch
            {
                ProductType.Ready => "Готово",
                ProductType.OnRequest => "Под заказ",
                _ => ProductTypeString
            };

            PhotoUrl = photoUrl;
            Description = description;
            Cost = cost;
            Id = new Guid();
        }

        public string Name { get => _name; set => _name = value; }
        public string PhotoUrl { get => _photoUrl; set => _photoUrl = value; }
        public string Description { get => _description; set => _description = value; }
        public int Cost { get => _cost; set => _cost = value; }
        public Guid Id { get => _id; set => _id = value; }
        public string ProductTypeString { get => _productDescription; set => _productDescription = value; }

        public ProductType ProductType
        {
            get => _productType;
            set => _productType = value;
        }
    }
}
