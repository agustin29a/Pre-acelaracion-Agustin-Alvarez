using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.DTO;

namespace DB.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Personaje,PersonajeDTO>();
            CreateMap<Personaje, PersonajeDetailDTO>();
            CreateMap<Personaje, PersonajeInputDTO>();
            CreateMap<PersonajeInputDTO, Personaje>();
            CreateMap<Pelicula, PeliculaDTO>();
            CreateMap<Pelicula, PeliculaDetailDTO>();
            CreateMap<PeliculaInputDTO, Pelicula>();
            CreateMap<Pelicula, PeliculaInputDTO>();
            CreateMap<Genero, GeneroDTO>();
        }
    }

}
