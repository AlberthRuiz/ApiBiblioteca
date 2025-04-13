using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.DTO {
    public class AutorDTO {
        public int Id { get; set; }       
        public required string NombresCompletos { get; set; }
    }
}
