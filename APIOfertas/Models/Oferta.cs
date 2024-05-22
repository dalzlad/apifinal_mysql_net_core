namespace APIOfertas.Models
{
    public class Oferta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public int Precio { get; set; }

        public int TipoOfertaId { get; set; }   

        //Navegacion
        public TipoOferta TipoOferta { get; set; }

    }
}
