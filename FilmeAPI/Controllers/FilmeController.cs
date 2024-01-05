using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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

    /// <summary>
    /// Adiciona um novo filme.
    /// </summary>
    /// <returns>Retorna 201 Created se o filme foi adicionado com sucesso.</returns>
    public IActionResult AdicionaFilme([FromBody] CreateFilmesDto filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperarFilmesPeloId),new {id = filme.Id},filme);
    }
    [HttpGet]

    /// <summary>
    /// Recupera uma lista de filmes com opção de paginação.
    /// </summary>
    /// <returns>Retorna uma lista de filmes com status 200 OK.</returns>
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery]int skip =0, [FromQuery] int take=30)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]

    /// <summary>
    /// Recupera um filme específico pelo seu ID.
    /// </summary>
    /// <returns>Retorna 200 OK se o filme foi encontrado ou 404 Not Found se não foi encontrado.</returns>
    public IActionResult RecuperarFilmesPeloId(int id)
    {
        var Filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (Filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(Filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]

    /// <summary>
    /// Atualiza um filme existente pelo seu ID.
    /// </summary>
    /// <returns>Retorna 204 No Content se o filme foi atualizado com sucesso ou 404 Not Found se não foi encontrado.</returns>
    public IActionResult AtualizaFilme(int id ,[FromBody] UpdateFilmesDto filmesDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        _mapper.Map(filmesDto,filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    /// <summary>
    /// Atualiza parcialmente um filme existente pelo seu ID.
    /// </summary>
    /// <returns>Retorna 204 No Content se o filme foi atualizado com sucesso, 404 Not Found se não foi encontrado, ou 400 Bad Request se a validação do modelo falhou.</returns>
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmesDto>patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmesDto>(filme);
        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if(!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]

    /// <summary>
    /// Remove um filme existente pelo seu ID.
    /// </summary>
    /// <returns>Retorna 204 No Content se o filme foi removido com sucesso ou 404 Not Found se não foi encontrado.</returns>
    public IActionResult DeletaFilme (int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges(); 
        return NoContent();
    }
}
 
