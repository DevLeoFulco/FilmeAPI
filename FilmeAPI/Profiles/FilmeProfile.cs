using AutoMapper;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;

namespace FilmeAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmesDto, Filme>();
        CreateMap<UpdateFilmesDto, Filme>();
        CreateMap<Filme, UpdateFilmesDto>();

    }


}
