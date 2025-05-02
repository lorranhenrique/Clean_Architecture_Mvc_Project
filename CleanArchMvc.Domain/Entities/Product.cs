using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            ValidationDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = CategoryId;
        }

        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description is required.");
            DomainExceptionValidation.When(name.Length < 3, "This name is too short, please add a name with 4 or more characters.");
            DomainExceptionValidation.When(description.Length < 5, "This description is too short, please add a description with 5 or more characters.");
            DomainExceptionValidation.When(price < 0, "this price is too low, please add 0 or higher price");
            DomainExceptionValidation.When(stock < 0, "This stock is too low, please add 0 or higher stock");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image. Image is too long.");

            Description = description;
            Image = image;
            Stock = stock;
            Price = price;
            Name = name;

        }

    }
}
