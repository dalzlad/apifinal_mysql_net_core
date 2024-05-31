using System.ComponentModel.DataAnnotations.Schema;

namespace APIOfertas.Models
{
    public class Oferta
    {
        //https://learn.microsoft.com/es-es/aspnet/core/mvc/models/validation?view=aspnetcore-8.0
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El nombre no puede contener más de 20 caracteres.")]
        [MinLength(2, ErrorMessage = "El nombre no puede contener menos de 5 caracteres.")]
        [EmailAddress(ErrorMessage = "El nombre no es un email")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 1000, ErrorMessage = "El precio debe estar en el rango de 1 a 1000")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        //[ForeignKey("FK_TipoOferta")]
        public int TipoOfertaId { get; set; }   

        //Navegacion
        public TipoOferta? TipoOferta { get; set; }

    }
}
