using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create product with a valid state")]
        public void CreatePruduct_WithValidParameters_ResultObjetcValidState()
        {
            Action action = () => new Product(1, "name", "description", 9, 5, "image");
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {

            Action action = () => new Product(-1, "name", "description", 9, 5, "image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "na", "description", 9, 5, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("This name is too short, please add a name with 4 or more characters.");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "description", 9, 5, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name.Name is required.");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null!, "description", 9, 5, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "name", "description", 9, 5, "imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid image. Image is too long.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_DomainExceptionWithNullImageName()
        {
            Action action = () => new Product(1, "name", "description", 9, 5, null!);
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "name", "description", 9, 5, null!);
            action.Should()
            .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_DomainExceptionWithEmptyImageName()
        {
            Action action = () => new Product(1, "nome", "description", 9, 5, "");
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "name", "description", 9, value, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("This stock is too low, please add 0 or higher stock");
        }

        [Theory]
        [InlineData(-10)]

        public void CreateProduct_InvalidPriceValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "name", "description", value, 10, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("this price is too low, please add 0 or higher price");
        }

        [Fact]

        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "name", "des", 9, 10, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("This description is too short, please add a description with 5 or more characters.");
        }

        [Fact]

        public void CreateProduct_EmptyDescriptionValue_DomainExceptionEmptyDescription()
        {
            Action action = () => new Product(1, "name", "", 9, 10, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid description.Description is required.");
        }

        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "name", null!, 9, 5, "image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

    }
}