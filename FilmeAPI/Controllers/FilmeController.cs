using FilmeAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperarFilmesPeloId),new {id = filme.Id},filme);
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip =0, [FromQuery] int take=30)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmesPeloId(int id)
    {
        var Filme =  filmes.FirstOrDefault(filme => filme.Id == id);
        if (Filme == null) return NotFound();
        return Ok(Filme);
    }
}
 
