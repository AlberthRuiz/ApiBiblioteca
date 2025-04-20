using ApiBiblioteca.DTO;
using ApiBiblioteca.Entidades;
using AutoMapper;

namespace ApiBiblioteca.Utilitarios {
    public class ApplicationMapper : Profile {
        public ApplicationMapper() {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dto => dto.NombresCompletos,
                src => src.MapFrom(x => $"{x.Nombres} {x.Apellidos}"));

            CreateMap<Autor, AutorConLibrosDTO>()
                .ForMember(dto => dto.NombresCompletos,
                src => src.MapFrom(x => $"{x.Nombres} {x.Apellidos}"));

            // Metodos post, put, delete
            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Autor, AutorCreacionDTO>();

            CreateMap<Libro, LibroDTO>();
            CreateMap<Libro, LibroConAutorDTO>();           
            

        }
    }

}

