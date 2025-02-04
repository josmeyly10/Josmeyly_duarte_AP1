using System.ComponentModel.DataAnnotations;

namespace josmeyly_Duarte_Ap1.Models
{
    public class Modelo
    {
        [Key]
        public int ModeloId { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "solo se permiten Letras")]
        [Required(ErrorMessage = "Campo Obligatorio")]

        public string? Nombres { get; set; }

    }
}
