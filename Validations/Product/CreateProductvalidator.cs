using FluentValidation;
using Furniture_Shop_Backend.ViewModels.Product;

namespace Furniture_Shop_Backend.Validations.Product {
    public class CreateProductvalidator : AbstractValidator<ProductCreateRequest> {
        public CreateProductvalidator() {
            RuleFor(x => x.BrandId).NotEmpty().WithMessage("Brand Id is required")
                                   .GreaterThan(0).WithMessage("Brand id must be greater than 0");
            RuleFor(x => x.ProductBasetId).NotEmpty().WithMessage("ProductBaseID is required")
                                          .MaximumLength(20).WithMessage("ProductBaseId is too long");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category Id is required")
                                   .GreaterThan(0).WithMessage("Category id must be greater than 0");
            RuleFor(x => x.MaterialId).NotEmpty().WithMessage("Material Id is required")
                                   .GreaterThan(0).WithMessage("Material id must be greater than 0");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(200).WithMessage("Name is too long");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description is too long");
        }
    }
}
