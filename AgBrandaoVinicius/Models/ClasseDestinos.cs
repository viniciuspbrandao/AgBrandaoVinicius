using System.ComponentModel.DataAnnotations;

namespace AgBrandaoVinicius.Models
{
    public class ClasseDestinos
    {
        [Key]
        public int Id { get; set; }
        public string Pacote { get; set; } //PACOTE VAI SER A FOREIGN KEY
        public string Destino { get; set; }
        public string Regiao { get; set; }
        public string Preco { get; set; }
    }
}
