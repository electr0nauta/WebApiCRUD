using AutoMapper;
using WebApiPortfolio.DTOs;
using WebApiPortfolio.Entidades;

namespace WebApiPortfolio.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Autor, AutorDTO>();
            CreateMap<LibroCreacionDTO, Libro>();
            CreateMap<Libro, LibroDTO>();
        }
    }
}
