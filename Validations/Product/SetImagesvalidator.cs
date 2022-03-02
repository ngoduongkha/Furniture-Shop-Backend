using FluentValidation;
using Furniture_Shop_Backend.ViewModels.Product;

namespace Furniture_Shop_Backend.Validations.Product
{
    public class SetImagesvalidator : AbstractValidator<ImagesCreate>
    {
        public SetImagesvalidator()
        {
            RuleFor(x => x.urlsImage).NotEmpty().WithMessage("List images is not empty");
            RuleFor(x => x.ProductBaseId).NotEmpty().WithMessage("Product base Id is not empty")
                                          .MaximumLength(50);
        }
    }
}
