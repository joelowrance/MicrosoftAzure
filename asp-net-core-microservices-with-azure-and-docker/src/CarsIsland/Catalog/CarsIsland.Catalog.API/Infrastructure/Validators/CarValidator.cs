using CarsIsland.Catalog.Domain.Model;
using FluentValidation;

namespace CarsIsland.Catalog.API.Infrastructure.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Brand).NotNull().NotEmpty();
            RuleFor(x => x.Model).NotNull().NotEmpty();
            RuleFor(x => x.PricePerDay).InclusiveBetween(200, 25000);
            RuleFor(x => x.PricePerWeek).InclusiveBetween(200, 25000);
            RuleFor(x => x.PricePerMonth).InclusiveBetween(200, 25000);
        }
    }
}
