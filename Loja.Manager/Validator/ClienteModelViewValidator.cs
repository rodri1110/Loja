using FluentValidation;
using Loja.Core.Shared.ModelViews;
using System;

namespace Loja.Manager.Validator
{
    public class ClienteModelViewValidator : AbstractValidator<ClienteModelView>
    {
        public ClienteModelViewValidator()
        {
            RuleFor(c => c.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
            RuleFor(c => c.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(c => c.Documento).NotNull().NotEmpty().Length(4, 14);
            RuleFor(c => c.Telefones).NotNull().NotEmpty();
            RuleFor(c => c.Sexo).NotNull().NotEmpty().Must(IsMorF).WithMessage("Sexo deve ser M ou F");
            RuleFor(c => c.Endereco).SetValidator(new EnderecoModelViewValidator());
        }

        private bool IsMorF(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}
