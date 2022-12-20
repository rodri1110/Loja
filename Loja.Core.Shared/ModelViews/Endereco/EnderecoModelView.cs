using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Core.Shared.ModelViews
{
    public class EnderecoModelView
    {
        /// <example>14800000</example>
        public string CEP { get; set; }

        /// <example>SP</example>
        public string Estado { get; set; }

        /// <example>Araraquara</example>
        public string Cidade { get; set; }

        ///<example>Av/Rua Sete</example>
        public string Logradouro { get; set; }

        /// <example>1000</example>
        public string Numero { get; set; }

        /// <example>Ao lado da praça</example>
        public string Complemento { get; set; }
    }
}
