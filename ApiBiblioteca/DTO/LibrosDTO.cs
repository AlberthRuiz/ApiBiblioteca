using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.DTO {
    public class LibrosDTO {
        public int Id { get; set; }        
        public required string Titulo { get; set; }
        public AutorDTO Autor { get; set; }
    }
}
