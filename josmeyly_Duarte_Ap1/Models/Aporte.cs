using System.ComponentModel.DataAnnotations;

namespace josmeyly_Duarte_Ap1.Models
{
    public class Aporte
    {
        [Key]
        public int AporteId { get; set; }

        public DateTime? Fecha {  get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage=" solo se permiten letras")]

        public string? Persona { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = " solo se permiten letras")]
        public string? Observacion{ get; set; } 

        [Required(ErrorMessage = "Campo obligatorio")]

        public double? Monto { get; set; }

        
       

       

    }
}
