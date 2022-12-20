using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Core.Shared.ModelViews
{
    public class ErrorResponseModelView
    {
        public string ErrorId { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }

        public ErrorResponseModelView(string id)
        {
            ErrorId = id;
            Data = DateTime.Now;
            Mensagem = "Erro inesperado.";
        }
    }
}
