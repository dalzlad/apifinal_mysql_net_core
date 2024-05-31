namespace APIOfertas.Models
{
    public class TipoOferta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El nombre no puede contener más de 20 caracteres.")]
        [MinLength(2, ErrorMessage = "El nombre no puede contener menos de 2 caracteres.")]
        public string NombreTipoOferta { get; set;  }

        // Navigation property
        public ICollection<Oferta> ?Oferta { get; set; }
    }
}
