namespace APIOfertas.Models
{
    public class Oferta
    {
        [Key]
        public int OfertaId { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public int Precio { get; set; }
    }
}
