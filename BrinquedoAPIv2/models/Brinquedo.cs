namespace BrinquedoAPIv2.Models
{
    public class Brinquedo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Classificacao { get; set; }
        public string Tamanho { get; set; }
        public decimal Preco { get; set; }
    }
}
