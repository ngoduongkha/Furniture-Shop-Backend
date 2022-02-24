using FluentValidation;
using Furniture_Shop_Backend.ViewModels.Product;

namespace Furniture_Shop_Backend.Validations.Product {
    public class UpdateProductvalidator : AbstractValidator<ProductUpdateRequest> {
        public UpdateProductvalidator() {
            RuleFor(x => x.CategoryId).NotNull().WithMessage("CategoryId is not null. If you don't want update this field please set 0");
            RuleFor(x => x.BrandId).NotNull().WithMessage("BrnadId is not null. If you don't want update this field please set 0");
            RuleFor(x => x.MaterialId).NotNull().WithMessage("MaterialId is not null. If you don't want update this field please set 0");
            RuleFor(x => x.Size).NotNull().WithMessage("Size is not null. If you don't want update this field please set empty");
            RuleFor(x => x.Price).NotNull().WithMessage("Price is not null. If you don't want update this field please set empty")
                                 .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity is not null. If you don't want update this field please set empty")
                                    .GreaterThan(-1).WithMessage("Quantity must be greater than -1");
            RuleFor(x => x.Description).NotNull().WithMessage("Description is not null. If you don't want update this field please set empty");
        }
    }
}
