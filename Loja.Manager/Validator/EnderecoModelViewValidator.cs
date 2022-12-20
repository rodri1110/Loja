using FluentValidation;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Manager.Validator
{
    public class EnderecoModelViewValidator : AbstractValidator<EnderecoModelView>
    {
        public EnderecoModelViewValidator()
        {
            RuleFor(c => c.CEP).NotNull().NotEmpty().Length(8);
            RuleFor(c => c.Estado).NotNull().NotEmpty().Length(2);
            RuleFor(c => c.Cidade).NotNull().NotEmpty().MinimumLength(4).MaximumLength(50);
            RuleFor(c => c.Logradouro).NotNull().NotEmpty().Length(1, 14);
            RuleFor(c => c.Numero).NotNull().NotEmpty().Length(1, 10);
            RuleFor(c => c.Complemento).MaximumLength(100).WithMessage("Ao lado da padaria.");
        }
    }
}
