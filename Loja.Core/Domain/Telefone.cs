namespace Loja.Core.Domain
{
    public class Telefone
    {
        //Chave composta, verificar em telefoneConfiguration ClienteId + Numero
        public string Numero { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}