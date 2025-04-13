using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.DTO {
    public class AutorCreacionDTO {        
        public required string Nombres { get; set; }
        
        public required string Apellidos { get; set; }
        
        public string? Identificacion { get; set; }

    }
}
