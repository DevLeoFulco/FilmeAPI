using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmesContext _context;
    private IMapper _mapper;

    public FilmeController(FilmesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmesDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarFilmesPeloId),new {id = filme.Id},filme);
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip =0, [FromQuery] int take=30)
    {
        return _context.Filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmesPeloId(int id)
    {
        var Filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (Filme == null) return NotFound();
        return Ok(Filme);
    }
}
 
