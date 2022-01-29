using FluentValidation;
using Furniture_Shop_Backend.ViewModels.Common;

namespace Furniture_Shop_Backend.Validations.Common
{
    public class ProductPagingRequestvalidator : AbstractValidator<GetProductPagingRequest>
    {
      public  ProductPagingRequestvalidator() 
        {
            RuleFor(x => x.Keyword).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.SortBy).NotNull();
            RuleFor(x => x.PageIndex).NotNull();
            RuleFor(x => x.PageSize).NotNull();
                
        }
    }
 
}
