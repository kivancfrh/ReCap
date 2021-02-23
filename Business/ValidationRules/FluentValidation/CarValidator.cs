using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Ekranlara göre yada DTO lara göre de yapabiliriz <> kısmını
    public class CarValidator : AbstractValidator<Car>
    {
        //All Rules
        public CarValidator()
        {
            //p = <Car>
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(300).When(p => p.BrandId == 2);
            RuleFor(p => p.Description).Must(CharGreaterThen5).WithMessage("Açıklama boş olmayacaksa en az 5 karakter olabilir");
        }

        private bool CharGreaterThen5(string arg) //Arg -> Car.Description
        {
            if (arg.Length>=5 && arg!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
