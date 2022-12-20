using FluentValidation;
using Loja.Core.Shared.ModelViews;
using System;

namespace Loja.Manager.Validator
{
    public class TelefoneModelViewValidator : AbstractValidator<TelefoneModelView>
    {
        public TelefoneModelViewValidator()
        {            
            RuleFor(c => c.Numero).NotNull().NotEmpty().Matches("[1-9]{9}").WithMessage("O telefone deve ter formato [1-9]{10}");            
        }
    }
}
