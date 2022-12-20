using FluentValidation;
using Loja.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Manager.Validator
{
    public class AtualizarClienteModelViewValidator : AbstractValidator<AtualizarClienteModelView>
    {
        public AtualizarClienteModelViewValidator()
        {
            RuleFor(p => p.ClienteId).NotNull().NotEmpty().GreaterThan(0);
                Include(new ClienteModelViewValidator());
        }
    }
}
