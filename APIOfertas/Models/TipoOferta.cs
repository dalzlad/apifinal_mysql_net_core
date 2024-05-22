namespace APIOfertas.Models
{
    public class TipoOferta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreTipoOferta { get; set;  }

        // Navigation property
        public ICollection<Oferta> ?Oferta { get; set; }
    }
}
