using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuadradoAPI.Models
{
    public class Numero
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Numero")]
        public int Valor { get; set; }

        public int Cuadrado { get; set; }
    }
}