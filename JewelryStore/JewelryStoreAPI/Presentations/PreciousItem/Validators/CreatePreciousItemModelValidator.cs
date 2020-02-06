﻿using FluentValidation;

namespace JewelryStoreAPI.Presentations.PreciousItem.Validators
{
    public class CreatePreciousItemModelValidator : AbstractValidator<CreatePreciousItemModel>
    {
        public CreatePreciousItemModelValidator()
        {
            RuleFor(x => x.Name).MaximumLength(128).NotNull();
            RuleFor(x => x.BrandId).GreaterThan(0);
            RuleFor(x => x.CountryId).GreaterThan(0);
            RuleFor(x => x.Cost).GreaterThan(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PreciousItemTypeId).GreaterThan(0);
        }
    }
}
