using ApiBiblioteca.DTO;
using ApiBiblioteca.Entidades;
using AutoMapper;

namespace ApiBiblioteca.Utilitarios {
    public class ApplicationMapper : Profile {
        public ApplicationMapper() {
            CreateMap<Autor, AutorDTO>()
                .ForMember(dto => dto.NombresCompletos,
                src => src.MapFrom(x => $"{x.Nombres} {x.Apellidos}"));
            CreateMap<Libro, LibroDTO>();

            CreateMap<Autor, AutorConLibrosDTO>()
                .ForMember(dto => dto.NombresCompletos,
                src => src.MapFrom(x => $"{x.Nombres} {x.Apellidos}"));
            CreateMap<Libro, LibroDTO>();

        }
    }

}

