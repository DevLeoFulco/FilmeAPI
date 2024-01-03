﻿using FilmeAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }
    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes ()
    {
        return filmes;
    }

    [HttpGet("{id}")]
    public Filme? RecuperarFilmesPeloId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
 
