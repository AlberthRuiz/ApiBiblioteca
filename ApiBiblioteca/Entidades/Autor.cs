using System.ComponentModel.DataAnnotations;

namespace ApiBiblioteca.Entidades {
    public class Autor {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0}, debe conteneder informacion")]
        [StringLength(80, ErrorMessage = "El campo {0}, no debe contener mas de {1} caracteres")]
        public required string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0}, debe conteneder informacion")]
        [StringLength(120, ErrorMessage = "El campo {0}, no debe contener mas de {1} caracteres")]
        public required string Apellidos { get; set; }

        [StringLength(11, ErrorMessage = "El campo {0}, no debe contener mas de {1} caracteres")]
        public string? Identificacion { get; set; }

        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
