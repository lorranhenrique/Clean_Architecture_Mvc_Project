namespace CleanArchMvc.Domain.Tests;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

public class CategoryUnitTest1
{
    [Fact(DisplayName = "Create category with a valid state")]
    public void CreateCategory_WithValidParameters_ResultObjetcValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create category with a valid Id")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id");
    }

    [Fact]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1,"C");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("This name is too short, please add a name with 4 or more characters.");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(1,"");
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name.Name is required.");
    }

    [Fact]
    public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Category(1, null!);
        action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }
}